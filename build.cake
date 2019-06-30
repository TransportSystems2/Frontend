#addin nuget:?package=Cake.XunitDeviceTestReceiver&version=1.0.2

var target = Argument("target", "Default");
Task("Default")
  .IsDependentOn("Build")
  .IsDependentOn("Tests")
  .Does(() =>
{
});
Task("Tests")
  .Does(async () =>
{
  sh 'msbuild ./MobileApp/Android /p:Configuration=Debug /t:Install'
  var allTestsPassed = LaunchEmbeddedTestsReceiver(port:7777);
  sh 'adb shell am start -a android.intent.action.MAIN -n ru.transportsystems.TransportSystems/.SplashScreen'
  if (!await allTestsPassed)
  {
      const string message = "Not all tests passed";
      Error(message);

      throw new Exception(message);
  }
  Information("All tests passed");
});
Task("Build")
    .Does(() =>
{
});

RunTarget(target);