using System;
using ObjCRuntime;

namespace GimbalSDK_iOS
{
    public enum GMBLForegroundBehavior : int
    {
        GMBLForegroundBehaviorUnknown,
        GMBLForegroundBehaviorNOOP,
        GMBLForegroundBehaviorNotify,
        GMBLForegroundBehaviorDialog,
        GMBLForegroundBehaviorDisplay,
        GMBLForegroundBehaviorPlay
    }

    public enum GMBLActionType : int
    {
        GMBLActionTypeUnknown,
        GMBLActionTypeWebView,
        GMBLActionTypeCarousel,
        GMBLActionTypeImage,
        GMBLActionTypeVideo,
        GMBLActionTypeAudio
    }

    public enum GMBLLocationStatus : long
    {
        Ok,
        AdminRestricted,
        NotAuthorizedAlways
    }


    public enum GMBLBluetoothStatus : long
    {
        Ok,
        AdminRestricted,
        PoweredOff
    }


    public enum GMBLBatteryLevel : long
    {
        Low = 0,
        MediumLow,
        MediumHigh,
        High
    }
}
