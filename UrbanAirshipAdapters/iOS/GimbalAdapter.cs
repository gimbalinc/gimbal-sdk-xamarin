using Foundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourNamespace
{
    /// <summary>
    /// Gimbal adapter for hooking gimbal location events and routing them to Urban Airship
    /// https://github.com/urbanairship/ua-extensions/tree/master/GimbalAdapters/iOS
    /// </summary>
    public class GimbalAdapter : GimbalFramework.GMBLPlaceManagerDelegate, IDisposable
    {
        string kSource = @"Gimbal";

        private bool started;
        private GimbalFramework.GMBLPlaceManager placeManager;

        private GimbalAdapter()
        {
            this.placeManager = new GimbalFramework.GMBLPlaceManager();
            this.placeManager.Delegate = this;

            if (NSUserDefaults.StandardUserDefaults.ValueForKey((NSString)@"gmbl_hide_bt_power_alert_view") == null)
                NSUserDefaults.StandardUserDefaults.SetBool(true,(NSString)@"gmbl_hide_bt_power_alert_view");
        }

        private void Dispose()
        {
            this.placeManager.Delegate = null;
        }

        private static readonly Lazy<GimbalAdapter> lazy = new Lazy<GimbalAdapter>(() => new GimbalAdapter());
        public static GimbalAdapter Shared
        {
            get
            {
                return lazy.Value;
            }
        }

        public bool IsBluetoothPoweredOffAlertEnabled
        {
            get
            {
                return !NSUserDefaults.StandardUserDefaults.BoolForKey(@"gmbl_hide_bt_power_alert_view");
            }
        }

        void SetBluetoothPoweredOffAlertEnabled(bool bluetoothPoweredOffAlertEnabled)
        {
            NSUserDefaults.StandardUserDefaults.SetBool(!bluetoothPoweredOffAlertEnabled, @"gmbl_hide_bt_power_alert_view");
        }

        public void StartAdapter()
        {
            if (this.started)
                return;

            GimbalFramework.GMBLPlaceManager.StartMonitoring();

            this.started = true;

            
        }

        public void StopAdapter()
        {
            if (this.started)
            {
                GimbalFramework.GMBLPlaceManager.StopMonitoring();
                this.started = false;
            }
        }

        void ReportPlaceEventToAnalytics(GimbalFramework.GMBLPlace place, UrbanAirship.UABoundaryEvent boundaryEvent)
        {
            var customBoundaryEvent = UrbanAirship.UARegionEvent.RegionEvent(place.Identifier, kSource, boundaryEvent);
            UrbanAirship.UAirship.Shared.Analytics.AddEvent(customBoundaryEvent);
        }

        public override void DidBeginVisit(GimbalFramework.GMBLPlaceManager manager, GimbalFramework.GMBLVisit visit)
        {
            this.ReportPlaceEventToAnalytics(visit.Place, UrbanAirship.UABoundaryEvent.Enter);
        }

        public override void DidEndVisit(GimbalFramework.GMBLPlaceManager manager, GimbalFramework.GMBLVisit visit)
        {
            this.ReportPlaceEventToAnalytics(visit.Place, UrbanAirship.UABoundaryEvent.Exit);
        }


        public override void DidDetectLocation(GimbalFramework.GMBLPlaceManager manager, CoreLocation.CLLocation location)
        {
        }


        public override void DidReceiveBeaconSighting(GimbalFramework.GMBLPlaceManager manager, GimbalFramework.GMBLBeaconSighting sighting, NSObject[] visits)
        {
        }

        
    }
}
