using System;
using ObjCRuntime;

namespace GimbalSDK_iOS
{
    public enum GMBLLocationStatus : int
    {
        Ok,
        AdminRestricted,
        NotAuthorizedAlways
    }

    public enum GMBLBluetoothStatus : int
    {
        Ok,
        AdminRestricted,
        PoweredOff
    }

    public enum GMBLBatteryLevel : int
    {
        Low = 0,
        MediumLow,
        MediumHigh,
        High
    }

    public enum GDPRConsentRequirement : int
    {
        RequirementUnknown = 1,
        NotRequired = 2,
        Required = 3
    }

    public enum GMBLConsentType : int
    {
        GMBLPlacesConsent = 1
    }

    public enum GMBLConsentState : int
    {
        Unknown = 0,
        Granted = 1,
        Refused = 2
    }
}
