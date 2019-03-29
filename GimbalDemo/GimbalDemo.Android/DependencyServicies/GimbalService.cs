using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Locations;
using Android.Support.V4.Content;
using Com.Gimbal.Android;
using GimbalDemo.Droid;
using GimbalDemo.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(GimbalService))]
namespace GimbalDemo.Droid
{
    public class GimbalService : IGimbalService
    {
        GPlaceEventListener placeEventListener;
        GCommunicationListener communicationListener;
        public void Initialize(Action<string> statusAction)
        {
            placeEventListener = new GPlaceEventListener(statusAction);
            PlaceManager.Instance.AddListener(placeEventListener);

            communicationListener = new GCommunicationListener(statusAction);
            CommunicationManager.Instance.AddListener(communicationListener);
        }

        public void Start()
        {
            Gimbal.Start();
            CommunicationManager.Instance.StartReceivingCommunications();

            Gimbal.EnablePushMessaging(true);
        }

        public void Stop()
        {
            Gimbal.Stop();
            PlaceManager.Instance.RemoveListener(placeEventListener);
            CommunicationManager.Instance.RemoveListener(communicationListener);
        }
    }

    public class GPlaceEventListener : PlaceEventListener
    {
        Action<string> statusAction;

        public GPlaceEventListener(Action<string> statusAction)
        {
            this.statusAction = statusAction;
        }

        public override void OnVisitEnd(Visit visit)
        {
            statusAction(visit.Place.Name);
            Console.WriteLine(visit.Place.Name);
        }

        public override void OnVisitStart(Visit visit)
        {
            statusAction(visit.Place.Name);
            Console.WriteLine(visit.Place.Name);
        }

        public override void OnVisitStartWithDelay(Visit visit, int delayTimeInSeconds)
        {
            if (delayTimeInSeconds > 0)
            {
                statusAction(visit.Place.Name);
                Console.WriteLine(visit.Place.Name);
            }
        }

        public override void LocationDetected(Location p0)
        {
            statusAction(String.Format("CLLocation = {0}", p0));
            Console.WriteLine(p0);
        }

    }

    public class GCommunicationListener : CommunicationListener
    {
        Action<string> statusAction;

        public GCommunicationListener(Action<string> statusAction)
        {
            this.statusAction = statusAction;
        }

        public override Notification.Builder PrepareCommunicationForDisplay(Communication communication, Push p1, int p2)
        {
            string description = String.Format("{0} CONTENT_DELIVERED", communication.Description);
            statusAction(description);
            Console.WriteLine(description);
            return null;
        }

        public override Notification.Builder PrepareCommunicationForDisplay(Communication communication, Visit p1, int p2)
        {
            string description = String.Format("{0} CONTENT_DELIVERED", communication.Description);
            statusAction(description);
            Console.WriteLine(description);
            return null;
        }

        public override void OnNotificationClicked(IList<Communication> p0)
        {
            Console.WriteLine(p0);
            base.OnNotificationClicked(p0);
        }

        public override ICollection<Communication> PresentNotificationForCommunications(ICollection<Communication> p0, Push p1)
        {
            Console.WriteLine(p1.ToString());
            return base.PresentNotificationForCommunications(p0, p1);
        }
    }
}
