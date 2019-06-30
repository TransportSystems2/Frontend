#addin nuget:?package=Cake.XunitDeviceTestReceiver&version=1.0.2

var target = Argument("target", "Default");
var configuration = Argument("config", "Debug");

Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Build")
  .IsDependentOn("Tests")
  .Does(() =>
{
});
Task("Clean")
    .Does(() =>
{
  StartProcess("msbuild", $"./MobileApp/Android/Tests/TransportSystems.Frontend.MobileApp.Droid.Tests/ /p:Configuration={configuration} /t:Clean");
});
Task("Uninstall")
    .Does(() =>
{
  StartProcess("adb", "uninstall TransportSystems.Frontend.MobileApp.Droid.Tests");
});
Task("Install")
    .Does(() =>
{
  StartProcess("adb",
    "install -g /Users/aleksandr/Projects/TS2/Frontend/MobileApp/Android/Tests/" +
    $"TransportSystems.Frontend.MobileApp.Droid.Tests/bin/{configuration}/TransportSystems.Frontend.MobileApp.Droid.Tests-Signed.apk");
});
Task("Build")
    .Does(() =>
{
  StartProcess("msbuild", $"./MobileApp/Android/Tests/TransportSystems.Frontend.MobileApp.Droid.Tests/ /p:Configuration={configuration} /t:Install");
});
Task("Tests")
  .Does(async () =>
{
  var allTestsPassed = LaunchEmbeddedTestsReceiver(port:7777);
  StartProcess("adb",  "shell am start -a android.intent.action.MAIN -c android.intent.category.LAUNCHER -n TransportSystems.Frontend.MobileApp.Droid.Tests/.MainActivity");
  if (!await allTestsPassed)
  {
      const string message = "Not all tests passed";
      Error(message);

      throw new Exception(message);
  }
  Information("All tests passed");
});

RunTarget(target);