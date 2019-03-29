/**
 * Copyright (C) 2017 Gimbal, Inc. All rights reserved.
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

/**
 *
 * The GMBLDeviceManager class will store attributes associated to the specific user of
 * the application. 
 *
 */
@interface GMBLDeviceAttributesManager : NSObject

/*!
 * Returns a dictionary of all the attributes currenty associated with a user.
 */
- (NSDictionary*)getDeviceAttributes;


/*!
 * Overwrites current attributes with the passed in dictionary.
 * Passing nil or an empty dictionary will remove all current attributes from the app.
 *
 * @param attributes The new desired attributes for a user
 */
- (Boolean)setDeviceAttributes:(NSDictionary*)attributes;

@end
