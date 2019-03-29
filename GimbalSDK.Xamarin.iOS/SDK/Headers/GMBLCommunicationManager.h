/*
 * Copyright (C) 2015 Gimbal, Inc. All rights reserved.
 *
 * This software is the confidential and proprietary information of Gimbal, Inc.
 *
 * The following sample code illustrates various aspects of the Gimbal SDK.
 *
 * The sample code herein is provided for your convenience, and has not been
 * tested or designed to work on any particular system configuration. It is
 * provided AS IS and your use of this sample code, whether as provided or
 * with any modification, is at your own risk. Neither Gimbal, Inc.
 * nor any affiliate takes any liability nor responsibility with respect
 * to the sample code, and disclaims all warranties, express and
 * implied, including without limitation warranties on merchantability,
 * fitness for a specified purpose, and against infringement.
 */
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <UserNotifications/UserNotifications.h>

@class GMBLCommunication;
@class GMBLVisit;
@class GMBLPlace;

@protocol GMBLCommunicationManagerDelegate;

/*!
 The GMBLCommunicationManager defines the interface for delivering communication events to your Gimbal enabled
 application.
 
 In order to receive communications associated to place entry and exit events, you must assign a class that conforms to
 the GMBLCommunicationManagerDelegate protocol to the delegate property of GMBLCommunicationManager.
 */
@interface GMBLCommunicationManager : NSObject

/// The delegate object to receive communication events.
@property (weak, nonatomic) id<GMBLCommunicationManagerDelegate> delegate;

/// Enables the Communication Manager to receive Gimbal Communications from Gimbal Manager
/// and deliver them to end users
+ (void)startReceivingCommunications;

/// Stops all Communication delivery to end users
+ (void)stopReceivingCommunications;

/// Returns whether Communications are being delivered to end users
+ (BOOL)isReceivingCommunications;

/*!
 @deprecated This method is deprecated starting in iOS 10
 @note Please use UserNotifications communicationForNotificationResponse:
 
 Used to parse a Gimbal Communication from a remote notification userInfo
 @param userInfo The userInfo object representing the remote notification
 */
+ (GMBLCommunication *)communicationForRemoteNotification:(NSDictionary *)userInfo NS_DEPRECATED_IOS(4_0, 10_0, "Use UserNotifications in iOS 10 and above");

/*!
 @deprecated This method is deprecated starting in iOS 10
 @note Please use UserNotifications communicationForNotificationResponse:

 Used to parse a Gimbal Communication from a local notification
 @param notification The local notification
 */
+ (GMBLCommunication *)communicationForLocalNotification:(UILocalNotification *)notification NS_DEPRECATED_IOS(4_0, 10_0, "Use UserNotifications in iOS 10 and above");


/*!
 For use with UserNotifications in iOS 10 and above.
 
 Used to parse a Gimbal Communication from a User Notification Response
 @param notificationResponse The user notification response
 */
+ (GMBLCommunication *)communicationForNotificationResponse:(UNNotificationResponse *)notificationResponse;

@end

/*!
 The GMBLCommunicationManagerDelegate protocol defines the methods used to receive events for the
 GMBLCommunicationManager object.
 */
@protocol GMBLCommunicationManagerDelegate <NSObject>

@optional

/*!
 Called when a Gimbal Event (for instance Place Arrival) triggers a Gimbal Communication. The communications returned in the array
 will be scheduled by Gimbal, while others will be ignored.
 
 Please note that frequency limit and delay are not honored for communications not returned.
 
 @param manager Communication manager sending the event
 @param communications Communications retrieved from the Gimbal Manager
 @param visit The visit that triggered the communication
 @return An array containing all the GMBLCommunication objects you would like Gimbal to post a UILocalNotification
 */
- (NSArray *)communicationManager:(GMBLCommunicationManager *)manager presentLocalNotificationsForCommunications:(NSArray *)communications forVisit:(GMBLVisit *)visit;

/*!
 @deprecated This method is deprecated starting in iOS 10
 @note Please use UserNotifications communicationManager:prepareNotificationContentForDisplay:forCommunication:forVisit:
 
 Called when a Gimbal Event (for instance Place Arrival) results in Gimbal Communications. Returned UILocalNotification
 will be scheduled for display. If nil is returned, a default Notification will be displayed using the GMBLCommunication.
 
 @param manager Communication manager sending the event
 @param notification Default notification for the received communication
 @param communication The communication received creating the notification
 @return The notification to be scheduled
 */
- (UILocalNotification *)communicationManager:(GMBLCommunicationManager *)manager prepareNotificationForDisplay:(UILocalNotification *)notification forCommunication:(GMBLCommunication *)communication NS_DEPRECATED_IOS(4_0, 10_0, "Use UserNotifications in iOS 10 and above");


/*!
 @deprecated This method is depricated in favor of a more complete version
 @note Please use communicationManager:prepareNotificationContentForDisplay:forCommunication:forVisit:
 
 Called when a Gimbal Event (for instance Place Arrival) results in Gimbal Communications. Returned UNMutableNotificationContent
 will be scheduled for display. If nil is returned, a default Notification will be displayed using the GMBLCommunication.
 
 @param manager Communication manager sending the event
 @param notificationContent Default notification content for the received communication
 @param communication The communication received creating the notification
 
 @return notificationContent to be added to scheduled UserNotification
 */
- (UNMutableNotificationContent *)communicationManager:(GMBLCommunicationManager *)manager prepareNotificationContentForDisplay:(UNMutableNotificationContent *)notificationContent forCommunication:(GMBLCommunication *)communication NS_DEPRECATED_IOS(4_0, 10_0, "Use communicationManager:prepareNotificationContentForDisplay:forCommunication:forVisit:");


/*!
 For use with UserNotifications in iOS 10 and above.
 
 Called when a Gimbal Event (for instance Place Arrival) results in Gimbal Communications. Returned UNMutableNotificationContent
 will be scheduled for display. If nil is returned, a default Notification will be displayed using the GMBLCommunication.
 
 @param manager Communication manager sending the event
 @param notificationContent Default notification content for the received communication
 @param communication The communication received creating the notification
 @param visit The visit triggering the event
 
 @return notificationContent to be added to scheduled UserNotification
 */
- (UNMutableNotificationContent *)communicationManager:(GMBLCommunicationManager *)manager
                  prepareNotificationContentForDisplay:(UNMutableNotificationContent *)notificationContent
                                      forCommunication:(GMBLCommunication *)communication
                                              forVisit:(GMBLVisit *)visit;

@end
