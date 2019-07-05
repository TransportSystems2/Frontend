using System.Reflection;

using Android.App;
using Android.OS;
using Xunit.Runners.UI;
using Xunit.Sdk;
using System;
using System.Linq;

namespace TransportSystems.Frontend.MobileApp.Droid.Tests
{
    [Activity(
        Name = "TransportSystems.Frontend.MobileApp.Droid.Tests.MainActivity",
        Label = "xUnit Android Runner",
        MainLauncher = true,
        Theme = "@android:style/Theme.Material.Light")]
    public class MainActivity : RunnerActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // tests can be inside the main assembly
            AddTestAssembly(Assembly.GetExecutingAssembly());

            AddExecutionAssembly(typeof(ExtensibilityPointFactory).Assembly);

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var sortedAssemblies =
                from assembly in assemblies
                where assembly.FullName.Contains("UnitTest")
                select assembly;

            foreach (var assembly in sortedAssemblies)
            {
                AddTestAssembly(assembly);
            }

            // or in any assembly that you load (since JIT is available)

#if true
			// you can use the default or set your own custom writer (e.g. save to web site and tweet it ;-)
			Writer = new TcpTextWriter ("10.0.2.2", 7777);
			// start running the test suites as soon as the application is loaded
			AutoStart = true;
			// crash the application (to ensure it's ended) and return to springboard
			TerminateAfterExecution = true;
#endif
            // you cannot add more assemblies once calling base
            base.OnCreate(bundle);
        }
    }
}