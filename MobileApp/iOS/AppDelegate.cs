using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.Ios
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App.Application>, App.Application>
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            return result;
        }
    }
}