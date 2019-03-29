using System;
using ObjCRuntime;

namespace GimbalSDK_iOS
{
	[Native]
	public enum GMBLLocationStatus : nint
	{
		Ok,
		AdminRestricted,
		NotAuthorizedAlways
	}

	[Native]
	public enum GMBLBluetoothStatus : nint
	{
		Ok,
		AdminRestricted,
		PoweredOff
	}

	[Native]
	public enum GMBLBatteryLevel : nint
	{
		Low = 0,
		MediumLow,
		MediumHigh,
		High
	}

	[Native]
	public enum GDPRConsentRequirement : nint
	{
		RequirementUnknown = 1,
		NotRequired = 2,
		Required = 3
	}

	[Native]
	public enum GMBLConsentType : nint
	{
		GMBLPlacesConsent = 1
	}

	[Native]
	public enum GMBLConsentState : nint
	{
		Unknown = 0,
		Granted = 1,
		Refused = 2
	}
}
