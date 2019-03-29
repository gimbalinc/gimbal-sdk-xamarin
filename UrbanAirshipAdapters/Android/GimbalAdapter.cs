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
using Com.Gimbal.Android;
using Android.Util;

namespace YourNamespace
{
    /// <summary>
    /// Gimbal adapter for hooking gimbal location events and routing them to Urban Airship
    /// https://github.com/urbanairship/ua-extensions/blob/master/GimbalAdapters/Android/GimbalAdapter.java
    /// <seealso cref="GimbalAdapterPlaceEventListener"/>
    /// </summary>
    public class GimbalAdapter
    {

        private static String TAG = "GimbalAdapter ";

        private static GimbalAdapter instance = new GimbalAdapter();

        private static String SOURCE = "Gimbal";

        private bool isStarted = false;

        private PlaceEventListener placeEventListener = new GimbalAdapterPlaceEventListener();

        GimbalAdapter()
        {

        }

        public static GimbalAdapter Shared()
        {
            return instance;
        }

        public void Start()
        {
            if (this.isStarted)
            {
                return;
            }

            this.isStarted = true;
            PlaceManager.Instance.AddListener(this.placeEventListener);
            PlaceManager.Instance.StartMonitoring();
            Log.Info(TAG, "Adapter Started");
        }

        public void Stop()
        {
            if (!this.isStarted)
            {
                return;
            }

            this.isStarted = false;
            PlaceManager.Instance.StopMonitoring();
            PlaceManager.Instance.RemoveListener(this.placeEventListener);
            Log.Info(TAG, "Adapter Stopped");
        }
    }
}