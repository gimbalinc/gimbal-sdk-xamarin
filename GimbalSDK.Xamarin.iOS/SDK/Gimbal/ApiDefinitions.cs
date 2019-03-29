using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace GimbalSDK_iOS
{
	// @interface GMBLApplicationStatus : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLApplicationStatus
	{
		[Wrap ("WeakDelegate")]
		GMBLApplicationStatusDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GMBLApplicationStatusDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(GMBLLocationStatus)locationStatus;
		[Static]
		[Export ("locationStatus")]
		[Verify (MethodToProperty)]
		GMBLLocationStatus LocationStatus { get; }

		// +(GMBLBluetoothStatus)bluetoothStatus;
		[Static]
		[Export ("bluetoothStatus")]
		[Verify (MethodToProperty)]
		GMBLBluetoothStatus BluetoothStatus { get; }

		// +(NSString *)statusDescription;
		[Static]
		[Export ("statusDescription")]
		[Verify (MethodToProperty)]
		string StatusDescription { get; }
	}

	// @protocol GMBLApplicationStatusDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GMBLApplicationStatusDelegate
	{
		// @optional -(void)applicationStatus:(GMBLApplicationStatus *)applicationStatus didChangeLocationStatus:(GMBLLocationStatus)locationStatus;
		[Export ("applicationStatus:didChangeLocationStatus:")]
		void DidChangeLocationStatus (GMBLApplicationStatus applicationStatus, GMBLLocationStatus locationStatus);

		// @optional -(void)applicationStatus:(GMBLApplicationStatus *)applicationStatus didChangeBluetoothStatus:(GMBLBluetoothStatus)bluetoothStatus;
		[Export ("applicationStatus:didChangeBluetoothStatus:")]
		void DidChangeBluetoothStatus (GMBLApplicationStatus applicationStatus, GMBLBluetoothStatus bluetoothStatus);
	}

	// @interface GMBLAttributes : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLAttributes : INSCopying, INSSecureCoding
	{
		// -(NSArray *)allKeys;
		[Export ("allKeys")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AllKeys { get; }

		// -(NSString *)stringForKey:(NSString *)key;
		[Export ("stringForKey:")]
		string StringForKey (string key);
	}

	// @interface GMBLBeacon : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLBeacon : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSString * identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic) NSString * uuid;
		[Export ("uuid")]
		string Uuid { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSString * iconURL;
		[Export ("iconURL")]
		string IconURL { get; }

		// @property (readonly, nonatomic) GMBLBatteryLevel batteryLevel;
		[Export ("batteryLevel")]
		GMBLBatteryLevel BatteryLevel { get; }

		// @property (readonly, nonatomic) NSInteger temperature;
		[Export ("temperature")]
		nint Temperature { get; }
	}

	// @interface GMBLBeaconManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLBeaconManager
	{
		[Wrap ("WeakDelegate")]
		GMBLBeaconManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GMBLBeaconManagerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)startListening;
		[Export ("startListening")]
		void StartListening ();

		// -(void)stopListening;
		[Export ("stopListening")]
		void StopListening ();
	}

	// @protocol GMBLBeaconManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GMBLBeaconManagerDelegate
	{
		// @required -(void)beaconManager:(GMBLBeaconManager *)manager didReceiveBeaconSighting:(GMBLBeaconSighting *)sighting;
		[Abstract]
		[Export ("beaconManager:didReceiveBeaconSighting:")]
		void DidReceiveBeaconSighting (GMBLBeaconManager manager, GMBLBeaconSighting sighting);
	}

	// @interface GMBLBeaconSighting : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLBeaconSighting : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSInteger RSSI;
		[Export ("RSSI")]
		nint RSSI { get; }

		// @property (readonly, nonatomic) NSDate * date;
		[Export ("date")]
		NSDate Date { get; }

		// @property (readonly, nonatomic) GMBLBeacon * beacon;
		[Export ("beacon")]
		GMBLBeacon Beacon { get; }
	}

	// @interface GMBLCircle : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLCircle : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) CLLocationCoordinate2D center;
		[Export ("center")]
		CLLocationCoordinate2D Center { get; }

		// @property (readonly, nonatomic) CLLocationDistance radius;
		[Export ("radius")]
		double Radius { get; }
	}

	// @interface GMBLCommunication : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLCommunication : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSString * identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, nonatomic) NSString * descriptionText;
		[Export ("descriptionText")]
		string DescriptionText { get; }

		// @property (readonly, nonatomic) NSString * URL;
		[Export ("URL")]
		string URL { get; }

		// @property (readonly, nonatomic) NSDate * deliveryDate;
		[Export ("deliveryDate")]
		NSDate DeliveryDate { get; }

		// @property (readonly, nonatomic) NSDate * expiryDate;
		[Export ("expiryDate")]
		NSDate ExpiryDate { get; }

		// @property (readonly, nonatomic) NSNumber * renderWebView;
		[Export ("renderWebView")]
		NSNumber RenderWebView { get; }

		// @property (readonly, nonatomic) GMBLAttributes * attributes;
		[Export ("attributes")]
		GMBLAttributes Attributes { get; }
	}

	// @interface GMBLCommunicationManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLCommunicationManager
	{
		[Wrap ("WeakDelegate")]
		GMBLCommunicationManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GMBLCommunicationManagerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(void)startReceivingCommunications;
		[Static]
		[Export ("startReceivingCommunications")]
		void StartReceivingCommunications ();

		// +(void)stopReceivingCommunications;
		[Static]
		[Export ("stopReceivingCommunications")]
		void StopReceivingCommunications ();

		// +(BOOL)isReceivingCommunications;
		[Static]
		[Export ("isReceivingCommunications")]
		[Verify (MethodToProperty)]
		bool IsReceivingCommunications { get; }

		// +(GMBLCommunication *)communicationForRemoteNotification:(NSDictionary *)userInfo __attribute__((availability(ios, introduced=4_0, deprecated=10_0)));
		[Introduced (PlatformName.iOS, 4, 0, message: "Use UserNotifications in iOS 10 and above")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "Use UserNotifications in iOS 10 and above")]
		[Static]
		[Export ("communicationForRemoteNotification:")]
		GMBLCommunication CommunicationForRemoteNotification (NSDictionary userInfo);

		// +(GMBLCommunication *)communicationForLocalNotification:(UILocalNotification *)notification __attribute__((availability(ios, introduced=4_0, deprecated=10_0)));
		[Introduced (PlatformName.iOS, 4, 0, message: "Use UserNotifications in iOS 10 and above")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "Use UserNotifications in iOS 10 and above")]
		[Static]
		[Export ("communicationForLocalNotification:")]
		GMBLCommunication CommunicationForLocalNotification (UILocalNotification notification);

		// +(GMBLCommunication *)communicationForNotificationResponse:(UNNotificationResponse *)notificationResponse;
		[Static]
		[Export ("communicationForNotificationResponse:")]
		GMBLCommunication CommunicationForNotificationResponse (UNNotificationResponse notificationResponse);
	}

	// @protocol GMBLCommunicationManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GMBLCommunicationManagerDelegate
	{
		// @optional -(NSArray *)communicationManager:(GMBLCommunicationManager *)manager presentLocalNotificationsForCommunications:(NSArray *)communications forVisit:(GMBLVisit *)visit;
		[Export ("communicationManager:presentLocalNotificationsForCommunications:forVisit:")]
		[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
		NSObject[] CommunicationManager (GMBLCommunicationManager manager, NSObject[] communications, GMBLVisit visit);

		// @optional -(UILocalNotification *)communicationManager:(GMBLCommunicationManager *)manager prepareNotificationForDisplay:(UILocalNotification *)notification forCommunication:(GMBLCommunication *)communication __attribute__((availability(ios, introduced=4_0, deprecated=10_0)));
		[Introduced (PlatformName.iOS, 4, 0, message: "Use UserNotifications in iOS 10 and above")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "Use UserNotifications in iOS 10 and above")]
		[Export ("communicationManager:prepareNotificationForDisplay:forCommunication:")]
		UILocalNotification CommunicationManager (GMBLCommunicationManager manager, UILocalNotification notification, GMBLCommunication communication);

		// @optional -(UNMutableNotificationContent *)communicationManager:(GMBLCommunicationManager *)manager prepareNotificationContentForDisplay:(UNMutableNotificationContent *)notificationContent forCommunication:(GMBLCommunication *)communication __attribute__((availability(ios, introduced=4_0, deprecated=10_0)));
		[Introduced (PlatformName.iOS, 4, 0, message: "Use communicationManager:prepareNotificationContentForDisplay:forCommunication:forVisit:")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "Use communicationManager:prepareNotificationContentForDisplay:forCommunication:forVisit:")]
		[Export ("communicationManager:prepareNotificationContentForDisplay:forCommunication:")]
		UNMutableNotificationContent CommunicationManager (GMBLCommunicationManager manager, UNMutableNotificationContent notificationContent, GMBLCommunication communication);

		// @optional -(UNMutableNotificationContent *)communicationManager:(GMBLCommunicationManager *)manager prepareNotificationContentForDisplay:(UNMutableNotificationContent *)notificationContent forCommunication:(GMBLCommunication *)communication forVisit:(GMBLVisit *)visit;
		[Export ("communicationManager:prepareNotificationContentForDisplay:forCommunication:forVisit:")]
		UNMutableNotificationContent CommunicationManager (GMBLCommunicationManager manager, UNMutableNotificationContent notificationContent, GMBLCommunication communication, GMBLVisit visit);
	}

	// @interface GMBLDebugger : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLDebugger
	{
		// +(void)enableBeaconSightingsLogging;
		[Static]
		[Export ("enableBeaconSightingsLogging")]
		void EnableBeaconSightingsLogging ();

		// +(void)disableBeaconSightingsLogging;
		[Static]
		[Export ("disableBeaconSightingsLogging")]
		void DisableBeaconSightingsLogging ();

		// +(BOOL)isBeaconSightingsEnabled;
		[Static]
		[Export ("isBeaconSightingsEnabled")]
		[Verify (MethodToProperty)]
		bool IsBeaconSightingsEnabled { get; }

		// +(void)enableDebugLogging;
		[Static]
		[Export ("enableDebugLogging")]
		void EnableDebugLogging ();

		// +(void)disableDebugLogging;
		[Static]
		[Export ("disableDebugLogging")]
		void DisableDebugLogging ();

		// +(BOOL)isDebugEnabled;
		[Static]
		[Export ("isDebugEnabled")]
		[Verify (MethodToProperty)]
		bool IsDebugEnabled { get; }
	}

	// @interface GMBLDeviceAttributesManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLDeviceAttributesManager
	{
		// -(NSDictionary *)getDeviceAttributes;
		[Export ("getDeviceAttributes")]
		[Verify (MethodToProperty)]
		NSDictionary DeviceAttributes { get; }

		// -(Boolean)setDeviceAttributes:(NSDictionary *)attributes;
		[Export ("setDeviceAttributes:")]
		byte SetDeviceAttributes (NSDictionary attributes);
	}

	// @interface GMBLEstablishedLocation : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLEstablishedLocation : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) double score;
		[Export ("score")]
		double Score { get; }

		// @property (readonly, nonatomic) GMBLCircle * boundary;
		[Export ("boundary")]
		GMBLCircle Boundary { get; }
	}

	// @interface GMBLEstablishedLocationManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLEstablishedLocationManager
	{
		// +(void)startMonitoring;
		[Static]
		[Export ("startMonitoring")]
		void StartMonitoring ();

		// +(void)stopMonitoring;
		[Static]
		[Export ("stopMonitoring")]
		void StopMonitoring ();

		// +(BOOL)isMonitoring;
		[Static]
		[Export ("isMonitoring")]
		[Verify (MethodToProperty)]
		bool IsMonitoring { get; }

		// +(NSArray *)establishedLocations;
		[Static]
		[Export ("establishedLocations")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] EstablishedLocations { get; }
	}

	// @interface GMBLPlace : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLPlace : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSString * identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) GMBLAttributes * attributes;
		[Export ("attributes")]
		GMBLAttributes Attributes { get; }
	}

	// @interface GMBLPlaceManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLPlaceManager
	{
		[Wrap ("WeakDelegate")]
		GMBLPlaceManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GMBLPlaceManagerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(BOOL)isMonitoring;
		[Static]
		[Export ("isMonitoring")]
		[Verify (MethodToProperty)]
		bool IsMonitoring { get; }

		// +(void)startMonitoring;
		[Static]
		[Export ("startMonitoring")]
		void StartMonitoring ();

		// +(void)stopMonitoring;
		[Static]
		[Export ("stopMonitoring")]
		void StopMonitoring ();

		// -(NSArray *)currentVisits;
		[Export ("currentVisits")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] CurrentVisits { get; }
	}

	// @protocol GMBLPlaceManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GMBLPlaceManagerDelegate
	{
		// @optional -(void)placeManager:(GMBLPlaceManager *)manager didBeginVisit:(GMBLVisit *)visit;
		[Export ("placeManager:didBeginVisit:")]
		void DidBeginVisit (GMBLPlaceManager manager, GMBLVisit visit);

		// @optional -(void)placeManager:(GMBLPlaceManager *)manager didBeginVisit:(GMBLVisit *)visit withDelay:(NSTimeInterval)delayTime;
		[Export ("placeManager:didBeginVisit:withDelay:")]
		void DidBeginVisit (GMBLPlaceManager manager, GMBLVisit visit, double delayTime);

		// @optional -(void)placeManager:(GMBLPlaceManager *)manager didReceiveBeaconSighting:(GMBLBeaconSighting *)sighting forVisits:(NSArray *)visits;
		[Export ("placeManager:didReceiveBeaconSighting:forVisits:")]
		[Verify (StronglyTypedNSArray)]
		void DidReceiveBeaconSighting (GMBLPlaceManager manager, GMBLBeaconSighting sighting, NSObject[] visits);

		// @optional -(void)placeManager:(GMBLPlaceManager *)manager didEndVisit:(GMBLVisit *)visit;
		[Export ("placeManager:didEndVisit:")]
		void DidEndVisit (GMBLPlaceManager manager, GMBLVisit visit);

		// @optional -(void)placeManager:(GMBLPlaceManager *)manager didDetectLocation:(CLLocation *)location;
		[Export ("placeManager:didDetectLocation:")]
		void DidDetectLocation (GMBLPlaceManager manager, CLLocation location);
	}

	// @interface GMBLPrivacyManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GMBLPrivacyManager
	{
		// +(GDPRConsentRequirement)gdprConsentRequirement;
		[Static]
		[Export ("gdprConsentRequirement")]
		[Verify (MethodToProperty)]
		GDPRConsentRequirement GdprConsentRequirement { get; }

		// +(void)setUserConsentFor:(GMBLConsentType)consentType toState:(GMBLConsentState)consentState;
		[Static]
		[Export ("setUserConsentFor:toState:")]
		void SetUserConsentFor (GMBLConsentType consentType, GMBLConsentState consentState);

		// +(GMBLConsentState)userConsentFor:(GMBLConsentType)consentType;
		[Static]
		[Export ("userConsentFor:")]
		GMBLConsentState UserConsentFor (GMBLConsentType consentType);
	}

	// @interface GMBLVisit : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface GMBLVisit : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSDate * arrivalDate;
		[Export ("arrivalDate")]
		NSDate ArrivalDate { get; }

		// @property (readonly, nonatomic) NSTimeInterval dwellTime;
		[Export ("dwellTime")]
		double DwellTime { get; }

		// @property (readonly, nonatomic) NSDate * departureDate;
		[Export ("departureDate")]
		NSDate DepartureDate { get; }

		// @property (readonly, nonatomic) GMBLPlace * place;
		[Export ("place")]
		GMBLPlace Place { get; }

		// @property (readonly, nonatomic) NSString * visitID;
		[Export ("visitID")]
		string VisitID { get; }
	}

	// @interface Gimbal : NSObject
	[BaseType (typeof(NSObject))]
	interface Gimbal
	{
		// +(void)setAPIKey:(NSString *)APIKey options:(NSDictionary *)options;
		[Static]
		[Export ("setAPIKey:options:")]
		void SetAPIKey (string APIKey, NSDictionary options);

		// +(void)start;
		[Static]
		[Export ("start")]
		void Start ();

		// +(void)stop;
		[Static]
		[Export ("stop")]
		void Stop ();

		// +(BOOL)isStarted;
		[Static]
		[Export ("isStarted")]
		[Verify (MethodToProperty)]
		bool IsStarted { get; }

		// +(NSString *)applicationInstanceIdentifier;
		[Static]
		[Export ("applicationInstanceIdentifier")]
		[Verify (MethodToProperty)]
		string ApplicationInstanceIdentifier { get; }

		// +(void)resetApplicationInstanceIdentifier;
		[Static]
		[Export ("resetApplicationInstanceIdentifier")]
		void ResetApplicationInstanceIdentifier ();

		// +(void)setPushDeviceToken:(NSData *)deviceToken;
		[Static]
		[Export ("setPushDeviceToken:")]
		void SetPushDeviceToken (NSData deviceToken);
	}
}
