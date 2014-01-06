using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TechTalk.SpecFlow.Infrastructure;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using XUnit.OptionallyIgnore;
using XUnit.OptionallyIgnore.SpecFlowPlugin;

[assembly: AssemblyTitle("SpecFlow Xunit tags to ignore tests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("challenger.com.au")]
[assembly: AssemblyProduct("XUnit.OptionallyIgnore")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("df299e37-61c9-4716-8902-f50014897b26")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: GeneratorPlugin(typeof(CustomGeneratorPlugin))]
[assembly: RuntimePlugin(typeof(CustomGeneratorPlugin))]