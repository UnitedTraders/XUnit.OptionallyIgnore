using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKeltCustom.SpecflowPlugin;
using TechTalk.SpecFlow.Infrastructure;

[assembly: RuntimePlugin(typeof(CustomRunTimePlugin))]
namespace McKeltCustom.SpecflowPlugin
{
    public class CustomRunTimePlugin : IRuntimePlugin
    {
    }
}
