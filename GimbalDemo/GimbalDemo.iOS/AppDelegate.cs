using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using GimbalSDK_iOS;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace GimbalDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUNUserNotificationCenterDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            var dict = NSDictionary.FromObjectAndKey((NSString)"MANAGE_PERMISSIONS", NSNumber.FromBoolean(false));
            Gimbal.SetAPIKey("5fba002a-5a07-424e-8fa2-decf01fa96d3", dict);

            if (options != null && options.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey))
            {
                ProcessRemoteNotification(options[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary);
            }

            if (options !=null && options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
            {
                ProcessLocalNotification(options[UIApplication.LaunchOptionsLocationKey] as UILocalNotification, UIApplication.SharedApplication.ApplicationState);
            }

            RegisterForNotifications(app);

            return base.FinishedLaunching(app, options);
        }

        //Remote notification support
        private void RegisterForNotifications(UIApplication application)
        {
            if (application.IsRegisteredForRemoteNotifications)
            {
                var types = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                var settings = UIUserNotificationSettings.GetSettingsForTypes(types, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }
            else
            {
                application.RegisterForRemoteNotificationTypes(UIRemoteNotificationType.Badge | UIRemoteNotificationType.Alert | UIRemoteNotificationType.Sound);
            }

            UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            center.Delegate = this;

            center.RequestAuthorization(UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Alert, (success, error) => { 
                if (error != null)
                {
                    Debug.WriteLine(String.Format("Error registering for UserNotifications {0}", error));
                }
                else
                {
                    Debug.WriteLine("Registered for UserNotifications");
                }
            });
        }

        public override void DidRegisterUserNotificationSettings(UIApplication application, UIUserNotificationSettings notificationSettings)
        {
            UIApplication.SharedApplication.RegisterForRemoteNotifications();
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            Gimbal.SetPushDeviceToken(deviceToken);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            Debug.WriteLine(String.Format("Registeration for remote notifications failed with error {0}", error.Description));
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            ProcessRemoteNotification(userInfo);
        }

        //GMBLCommunicationManager Delegate Callback for legacy notification
        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            var state = application.ApplicationState;
            ProcessLocalNotification(notification, state);
        }

        [Export("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
        public void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            processNotificationResponse(response);
            completionHandler();
        }

        [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
        public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            completionHandler(UNNotificationPresentationOptions.Alert);
        }

        //Notification Helper Methods
        private void ProcessRemoteNotification(NSDictionary userInfo)
        {
            GMBLCommunication communication = GMBLCommunicationManager.CommunicationForRemoteNotification(userInfo);
            if (communication != null)
            {
                //[self storeCommunication:communication];
                Debug.WriteLine(String.Format("ProcessRemoteNotification communication {0}", communication));
            }
        }


        private void processNotificationResponse(UNNotificationResponse response)
        {
            GMBLCommunication communication = GMBLCommunicationManager.CommunicationForNotificationResponse(response);
            if (communication != null)
            {
                //[self storeCommunication:communication];
                Debug.WriteLine(String.Format("processNotificationResponse communication {0}", communication));
            }    
        }

        private void ProcessLocalNotification(UILocalNotification notification, UIApplicationState state)
        {
            GMBLCommunication communication = GMBLCommunicationManager.CommunicationForLocalNotification(notification);

            if (communication != null)
            {
                UIApplication.SharedApplication.CancelLocalNotification(notification);
                //[self storeCommunication:communication];
                Debug.WriteLine(String.Format("ProcessLocalNotification communication {0}", communication));
            }
        }

        private void StoreCommunication(GMBLCommunication communication)
        {
            //    UINavigationController *nv = (UINavigationController *)self.window.rootViewController;
            //    if ([nv.topViewController isKindOfClass:[ViewController class]])
            //    {
            //        ViewController* vc = (ViewController*)nv.topViewController;
            //[vc addCommunication:communication];
            //}

            Debug.WriteLine(String.Format("StoreCommunication communication {0}", communication));
        }
    }
}
