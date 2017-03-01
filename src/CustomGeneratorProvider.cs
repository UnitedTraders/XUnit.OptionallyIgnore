using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Parser.SyntaxElements;
using TechTalk.SpecFlow.Utils;
using Xunit;
using Xunit.Extensions;

namespace XUnit.OptionallyIgnore.SpecFlowPlugin
{
    /// <summary>
    /// http://blog.jessehouwing.nl/2013/04/creating-custom-unit-test-generator.html
    /// </summary>
    public class CustomGeneratorProvider : IUnitTestGeneratorProvider
    {
        private const string FeatureTitlePropertyName = "FeatureTitle";
        private const string DescriptionPropertyName = "Description";

        private readonly string ignorableFactAttribute = typeof (OptionallyIgnoreTestFactAttribute).FullName;
        private readonly string factAttribute = typeof (FactAttribute).FullName;
        private readonly string theoryAttribute = typeof(TheoryAttribute).FullName;
        private readonly string inlinedataAttribute = typeof(InlineDataAttribute).FullName;
        private readonly string traitAttribute = typeof(TraitAttribute).FullName;
        private readonly string iusefixtureInterface = typeof(IUseFixture<>).FullName;

        private CodeTypeDeclaration currentFixtureDataTypeDeclaration;

        protected CodeDomHelper CodeDomHelper { get; set; }

        public bool SupportsRowTests { get { return true; } }
        public bool SupportsAsyncTests { get { return false; } }

        public CustomGeneratorProvider(CodeDomHelper codeDomHelper)
        {
            CodeDomHelper = codeDomHelper;
        }

        public void SetTestClass(TestClassGenerationContext generationContext, string featureTitle, string featureDescription)
        {
            // xUnit does not use an attribute for the TestFixture, all public classes are potential fixtures
        }

        public void SetTestClassCategories(TestClassGenerationContext generationContext, IEnumerable<string> featureCategories)
        {
            // xUnit does not support caregories
        }

        public void SetTestClassInitializeMethod(TestClassGenerationContext generationContext)
        {
            // xUnit uses IUseFixture<T> on the class
            // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
            generationContext.TestClassInitializeMethod.Attributes |= MemberAttributes.Static;

            currentFixtureDataTypeDeclaration = CodeDomHelper.CreateGeneratedTypeDeclaration("FixtureData");
            generationContext.TestClass.Members.Add(currentFixtureDataTypeDeclaration);

            CodeTypeReference fixtureDataType =
                CodeDomHelper.CreateNestedTypeReference(generationContext.TestClass, currentFixtureDataTypeDeclaration.Name);

            CodeTypeReference useFixtureType = new CodeTypeReference(iusefixtureInterface, fixtureDataType);
            CodeDomHelper.SetTypeReferenceAsInterface(useFixtureType);

            generationContext.TestClass.BaseTypes.Add(useFixtureType);

            // public void SetFixture(T) { } // explicit interface implementation for generic interfaces does not work with codedom
            CodeMemberMethod setFixtureMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = "SetFixture"
            };
            setFixtureMethod.Parameters.Add(new CodeParameterDeclarationExpression(fixtureDataType, "fixtureData"));
            setFixtureMethod.ImplementationTypes.Add(useFixtureType);

            generationContext.TestClass.Members.Add(setFixtureMethod);

            // public <_currentFixtureTypeDeclaration>() { <fixtureSetupMethod>(); }
            CodeConstructor ctorMethod = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            currentFixtureDataTypeDeclaration.Members.Add(ctorMethod);
            ctorMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    new CodeTypeReferenceExpression(new CodeTypeReference(generationContext.TestClass.Name)),
                    generationContext.TestClassInitializeMethod.Name));
        }

        public void SetTestClassCleanupMethod(TestClassGenerationContext generationContext)
        {
            // xUnit uses IUseFixture<T> on the class
            // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
            generationContext.TestClassCleanupMethod.Attributes |= MemberAttributes.Static;

            currentFixtureDataTypeDeclaration.BaseTypes.Add(typeof(IDisposable));

            // void IDisposable.Dispose() { <fixtureTearDownMethod>(); }
            CodeMemberMethod disposeMethod = new CodeMemberMethod
            {
                PrivateImplementationType = new CodeTypeReference(typeof (IDisposable)),
                Name = "Dispose"
            };

            currentFixtureDataTypeDeclaration.Members.Add(disposeMethod);

            disposeMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    new CodeTypeReferenceExpression(new CodeTypeReference(generationContext.TestClass.Name)),
                    generationContext.TestClassCleanupMethod.Name));
        }

        public void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            SetProperty(testMethod, FeatureTitlePropertyName, generationContext.Feature.Title);
            SetDescription(testMethod, scenarioTitle);

            foreach (Scenario scenario in generationContext.Feature.Scenarios.Where(a=>a.Title == scenarioTitle))
            {
                if (scenario.Tags == null)
                {
                    CodeDomHelper.AddAttribute(testMethod, factAttribute);
                    return;
                }

                foreach (Tag tag in scenario.Tags)
                {
                    if (tag.Name == "OptionallyIgnore")
                    {
                        CodeDomHelper.AddAttribute(testMethod, ignorableFactAttribute);
                    }
                    else
                    {
                        CodeDomHelper.AddAttribute(testMethod, factAttribute);
                    }
                }
            }
        }

        public void SetRowTest(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            CodeDomHelper.AddAttribute(testMethod, theoryAttribute);

            SetProperty(testMethod, FeatureTitlePropertyName, generationContext.Feature.Title);
            SetDescription(testMethod, scenarioTitle);
        }

        public void SetRow(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, IEnumerable<string> arguments, IEnumerable<string> tags, bool isIgnored)
        {
            //TODO: better handle "ignored"
            if (isIgnored)
            {
                return;
            }

            List<CodeAttributeArgument> args = arguments
                .Select(arg => new CodeAttributeArgument(new CodePrimitiveExpression(arg)))
                .ToList();

            args.Add(
                new CodeAttributeArgument(
                    new CodeArrayCreateExpression(typeof(string[]), tags.Select(t => new CodePrimitiveExpression(t)).ToArray())));

            CodeDomHelper.AddAttribute(testMethod, inlinedataAttribute, args.ToArray());
        }

        public void SetTestMethodCategories(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, IEnumerable<string> scenarioCategories)
        {
            // xUnit does not support caregories
        }

        public void SetTestInitializeMethod(TestClassGenerationContext generationContext)
        {
            // xUnit uses a parameterless constructor
            // public <_currentTestTypeDeclaration>() { <memberMethod>(); }
            CodeConstructor ctorMethod = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };

            generationContext.TestClass.Members.Add(ctorMethod);

            ctorMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(),
                    generationContext.TestInitializeMethod.Name));
        }

        public void SetTestCleanupMethod(TestClassGenerationContext generationContext)
        {
            // xUnit supports test tear down through the IDisposable interface
            generationContext.TestClass.BaseTypes.Add(typeof(IDisposable));

            // void IDisposable.Dispose() { <memberMethod>(); }
            CodeMemberMethod disposeMethod = new CodeMemberMethod
            {
                PrivateImplementationType = new CodeTypeReference(typeof (IDisposable)),
                Name = "Dispose"
            };

            generationContext.TestClass.Members.Add(disposeMethod);

            disposeMethod.Statements.Add(
                new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(),
                    generationContext.TestCleanupMethod.Name));
        }

        public void SetTestClassIgnore(TestClassGenerationContext generationContext)
        {
            //TODO: how to do class level ignore?
        }

        public void SetTestMethodIgnore(TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
        }

        private void SetProperty(CodeTypeMember codeTypeMember, string name, string value)
        {
            CodeDomHelper.AddAttribute(codeTypeMember, traitAttribute, name, value);
        }

        private void SetDescription(CodeTypeMember codeTypeMember, string description)
        {
            // xUnit doesn't have a DescriptionAttribute so using a TraitAttribute instead
            SetProperty(codeTypeMember, DescriptionPropertyName, description);
        }

        public virtual void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            CodeDomHelper.AddCommentStatement(generationContext.TestClassInitializeMethod.Statements, "Some other functionallity avaliable on");
            CodeDomHelper.AddCommentStatement(generationContext.TestClassInitializeMethod.Statements, "https://github.com/chrismckelt/XUnit.OptionallyIgnore");
        }

        public void SetTestMethodAsRow(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle, string exampleSetName, string variantName, IEnumerable<KeyValuePair<string, string>> arguments)
        {
            // doing nothing since we support RowTest
        }
    }
}
