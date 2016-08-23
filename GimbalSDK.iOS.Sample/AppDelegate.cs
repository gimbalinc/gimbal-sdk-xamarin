using CoreLocation;
using Foundation;
using UIKit;

namespace GimbalSDK.iOS.Sample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public override UIWindow Window
        {
            get;
            set;
        }

        private GimbalManager gimbalManager;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
			Window.RootViewController = new Table();

            // make the window visible
            Window.MakeKeyAndVisible();

            //GIMBAL - encapsulate gimbal service management and ios location into following class
            gimbalManager = new GimbalManager();
            //need an empty dictionary for the overload...just doesn't seem right, does it?
            var dict = NSDictionary.FromObjectAndKey((NSString)"nada", (NSString)"nidi");
            //sub out your api key here
            GimbalFramework.Gimbal.SetAPIKey("YOUR_API_KEY_HERE", dict);
            //if app was previously authorized, start up gimbal services
            if (CLLocationManager.Status == CLAuthorizationStatus.AuthorizedAlways)
            {
                gimbalManager.Start();
            }

            //request always auth for location - need a listener since this happens async on start esp on first run
            CLLocationManager manager = new CLLocationManager();
            manager.Delegate = gimbalManager;
            manager.RequestAlwaysAuthorization();

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}


