using System;
using System.Diagnostics;
using CoreLocation;
using Foundation;
using GimbalDemo.Interface;
using GimbalDemo.iOS;
using GimbalSDK_iOS;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(GimbalService))]
namespace GimbalDemo.iOS
{
    public class GimbalService : IGimbalService
    {
        GMBLPlaceManager placeManager;
        GMBLCommunicationManager communicationManager;

        public void Initialize(Action<string> statusAction)
        {
            placeManager = new GMBLPlaceManager();
            placeManager.Delegate = new BLPlaceManagerDelegate(statusAction);

            communicationManager = new GMBLCommunicationManager();
            communicationManager.Delegate = new BLCommunicationManager(statusAction);
        }

        public void Start()
        {
            Gimbal.Start();
        }

        public void Stop()
        {
            Gimbal.Stop();
        }
    }

    public class BLPlaceManagerDelegate : GMBLPlaceManagerDelegate
    {
        Action<string> statusAction;

        public BLPlaceManagerDelegate(Action<string> statusAction)
        {
            this.statusAction = statusAction;
        }

        public override void DidBeginVisit(GMBLPlaceManager manager, GMBLVisit visit)
        {
            statusAction(visit.Place.Description);
            Debug.WriteLine(visit.Place.Description);
        }

        public override void DidReceiveBeaconSighting(GMBLPlaceManager manager, GMBLBeaconSighting sighting, NSObject[] visits)
        {
            statusAction(String.Format("Visits count = {0}", visits.Length));
        }

        public override void DidEndVisit(GMBLPlaceManager manager, GMBLVisit visit)
        {
            statusAction(visit.Place.Description);
        }

        public override void DidDetectLocation(GMBLPlaceManager manager, CLLocation location)
        {
            statusAction(String.Format("CLLocation = {0}", location));
        }
    }

    public class BLCommunicationManager : GMBLCommunicationManagerDelegate
    {
        Action<string> statusAction;
        public BLCommunicationManager(Action<string> statusAction)
        {
            this.statusAction = statusAction;
        }

        public override UILocalNotification CommunicationManager(GMBLCommunicationManager manager, UILocalNotification notification, GMBLCommunication communication)
        {
            string description = String.Format("{0} CONTENT_DELIVERED", communication.DescriptionText);
            statusAction(description);
            return notification;
        }

        public override UNMutableNotificationContent CommunicationManager(GMBLCommunicationManager manager, UNMutableNotificationContent notificationContent, GMBLCommunication communication)
        {
            string description = String.Format("{0} CONTENT_DELIVERED", communication.DescriptionText);
            statusAction(description);
            return notificationContent;
        }
    }
}
