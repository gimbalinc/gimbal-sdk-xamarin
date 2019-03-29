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

#ifndef GMBLPrivacyManager_h
#define GMBLPrivacyManager_h

/*!
 * Indicates the requirement for user consent for SDK operation under the GDPR
 */
typedef NS_ENUM(NSInteger, GDPRConsentRequirement) {
    /// GDPR user consent status is not yet known - The Gimbal SDK has not yet been able to contact its server
    GMBLGDPRConsentRequirementUnknown = 1,
    /// GDPR user consent is not required at this location - it may be required at a different location
    GMBLGDPRConsentNotRequired = 2,
    /// GDPR user consent is required at this location
    GMBLGDPRConsentRequired = 3,
};

/*!
 * The Gimbal SDK feature that may be consented to
 */
typedef NS_ENUM(NSInteger, GMBLConsentType) {
    /// Indicates a choice for consent to Place Monitoring functionality
    GMBLPlacesConsent = 1,
};

/*!
 * Indicates the consent chosen by the user
 */
typedef NS_ENUM(NSInteger, GMBLConsentState) {
    /// Consent is unknown -- typically because the user has not yet been asked for consent
    GMBLConsentUnknown = 0,
    /// Consent has been granted by the user
    GMBLConsentGranted = 1,
    /// Consent has been refused by the user
    GMBLConsentRefused = 2,
};

/*!
 * Provides methods for managing a user's privacy, e.g. consent requirement(s) and opt-ins for
 * protected features and functionality
 */
@interface GMBLPrivacyManager : NSObject

/*!
 * Returns whether the user must give consent to the Gimbal SDK to process location information
 * in accordance with the GDPR. If the SDK is running in a country subject to the GDPR,
 * this will indicate that the user is <code>GMBLGDPRConsentRequired</code> to give consent for the SDK
 * to operate fully. If not running in these countries, consent is
 * <code>GMBLGDPRConsentNotRequired</code>. If the SDK has not yet registered with the Gimbal
 * platform, the result is <code>GMBLGDPRConsentRequirementUnknown</code>.
 *
 * @return a <code>GdprConsentRequirement</code> indicating whether the user must give
 * consent to the SDK to operate in countries subject to the GDPR.
 */
+ (GDPRConsentRequirement)gdprConsentRequirement;

/*!
 * Informs the SDK of the user's consent for the specified feature type
 * @param consentType the SDK feature or functionality to consent to
 * @param consentState whether consent is granted or refused
 */
+ (void)setUserConsentFor:(GMBLConsentType) consentType toState:(GMBLConsentState) consentState;

/*!
 * Returns the user's current consent value for the specified feature type. If a consent value
 * was not previously set for the feature type, <code>GMBLConsentUnknown</code> is returned.
 * @param consentType the SDK feature or functionality to consent to
 * @return whether consent was previously granted or refused
 */
+ (GMBLConsentState) userConsentFor:(GMBLConsentType) consentType;

@end

#endif /* GMBLPrivacyManager_h */
