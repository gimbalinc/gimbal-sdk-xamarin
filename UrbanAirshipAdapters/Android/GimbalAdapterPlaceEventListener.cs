using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
//using Android.Text.Format;
using ElectricSheep.Extensions;
using UrbanAirship.Location;

namespace YourNamespace
{
    /// <summary>
    /// Port for in-place overridden PlaceEventListener from https://github.com/urbanairship/ua-extensions/blob/master/GimbalAdapters/Android/GimbalAdapter.java
    /// <seealso cref="GimbalAdapter"/>
    /// </summary>
    class GimbalAdapterPlaceEventListener : Com.Gimbal.Android.PlaceEventListener
    {
        private static String TAG = "GimbalAdapterPlaceEventListener ";

        private static String SOURCE = "Gimbal";

        public override void OnVisitStart(Com.Gimbal.Android.Visit visit)
        {
            Log.Info(TAG, "Entered place: " + visit.Place.Name + "Entrance date: " + visit.ArrivalTimeInMillis.FromUnixTime().GetValueOrDefault().ToString("O"));
            RegionEvent enter = new RegionEvent(visit.Place.Identifier, SOURCE, RegionEvent.BoundaryEventEnter);
            UrbanAirship.UAirship.Shared().Analytics.AddEvent(enter);
        }

        public override void OnVisitEnd(Com.Gimbal.Android.Visit visit)
        {
            Log.Info(TAG, "Exited place: " + visit.Place.Name + "Entrance date: "
                    + visit.ArrivalTimeInMillis.FromUnixTime().GetValueOrDefault().ToString("O")
                    + "Exit date:"
                    + visit.DepartureTimeInMillis.FromUnixTime().GetValueOrDefault().ToString("O"));
            RegionEvent exit = new RegionEvent(visit.Place.Identifier, SOURCE, RegionEvent.BoundaryEventExit);
            UrbanAirship.UAirship.Shared().Analytics.AddEvent(exit);
        }
    }
}