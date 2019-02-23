using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using mRemoteNG.Tools;

namespace mRemoteNG.Connection
{
    public class ConnectionInfoInheritance
    {
        private ConnectionInfoInheritance _tempInheritanceStorage;

        #region Public Properties

        #region General

        [LocalizedAttributes.LocalizedCategory("CategoryGeneral"),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameAll"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionAll"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EverythingInherited
        {
            get { return EverythingIsInherited(); }
            set { SetAllValues(value); }
        }

        #endregion

        #region Display

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay", 2),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameDescription"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionDescription"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Description { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay", 2),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameIcon"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionIcon"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Icon { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay", 2),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNamePanel"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionPanel"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Panel { get; set; }

        #endregion

        #region Connection

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 3),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameUsername"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionUsername"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        [Browsable(true)]
        public bool Username { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 3),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNamePassword"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionPassword"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        [Browsable(true)]
        public bool Password { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 3),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameDomain"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionDomain"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        [Browsable(true)]
        public bool Domain { get; set; }

        #endregion

        #region Protocol

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameProtocol"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionProtocol"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Protocol { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameExternalTool"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionExternalTool"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool ExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNamePort"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionPort"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Port { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNamePuttySession"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionPuttySession"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool PuttySession { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameEncryptionStrength"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionEncryptionStrength"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool ICAEncryptionStrength { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameAuthenticationLevel"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionAuthenticationLevel"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDPAuthenticationLevel { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDPMinutesToIdleTimeout"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRDPMinutesToIdleTimeout"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDPMinutesToIdleTimeout { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDPAlertIdleTimeout"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRDPAlertIdleTimeout"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDPAlertIdleTimeout { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameLoadBalanceInfo"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionLoadBalanceInfo"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool LoadBalanceInfo { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRenderingEngine"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRenderingEngine"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RenderingEngine { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameUseConsoleSession"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionUseConsoleSession"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseConsoleSession { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryProtocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameUseCredSsp"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionUseCredSsp"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseCredSsp { get; set; }

        #endregion

        #region RD Gateway

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDGatewayUsageMethod"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRDGatewayUsageMethod"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayUsageMethod { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDGatewayHostname"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRDGatewayHostname"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayHostname { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDGatewayUseConnectionCredentials"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute(
             "strPropertyDescriptionRDGatewayUseConnectionCredentials"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayUseConnectionCredentials { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDGatewayUsername"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRDGatewayUsername"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayUsername { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDGatewayPassword"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRDGatewayPassword"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayPassword { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRDGatewayDomain"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRDGatewayDomain"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayDomain { get; set; }

        #endregion

        #region Appearance

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameResolution"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionResolution"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Resolution { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameAutomaticResize"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionAutomaticResize"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool AutomaticResize { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameColors"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionColors"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Colors { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameCacheBitmaps"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionCacheBitmaps"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool CacheBitmaps { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameDisplayWallpaper"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionDisplayWallpaper"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayWallpaper { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameDisplayThemes"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionDisplayThemes"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayThemes { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameEnableFontSmoothing"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionEnableFontSmoothing"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableFontSmoothing { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameEnableDesktopComposition"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute(
             "strPropertyDescriptionEnableEnableDesktopComposition"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableDesktopComposition { get; set; }

        #endregion

        #region Redirect

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRedirectKeys"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRedirectKeys"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectKeys { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRedirectDrives"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRedirectDrives"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectDiskDrives { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRedirectPrinters"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRedirectPrinters"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPrinters { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRedirectClipboard"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRedirectClipboard"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectClipboard { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRedirectPorts"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRedirectPorts"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPorts { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRedirectSmartCards"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRedirectSmartCards"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectSmartCards { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameRedirectSounds"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionRedirectSounds"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectSound { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameSoundQuality"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionSoundQuality"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool SoundQuality { get; set; }

        #endregion

        #region Misc

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameExternalToolBefore"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionExternalToolBefore"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool PreExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameExternalToolAfter"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionExternalToolAfter"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool PostExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameMACAddress"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionMACAddress"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool MacAddress { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameUser1"),
         LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionUser1"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UserField { get; set; }

        #endregion

        #region VNC
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameCompression"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionCompression"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCCompression {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameEncoding"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionEncoding"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCEncoding {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryConnection", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameAuthenticationMode"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionAuthenticationMode"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCAuthMode {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameVNCProxyType"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionVNCProxyType"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyType {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameVNCProxyAddress"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionVNCProxyAddress"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyIP {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameVNCProxyPort"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionVNCProxyPort"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyPort {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameVNCProxyUsername"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionVNCProxyUsername"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyUsername {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameVNCProxyPassword"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionVNCProxyPassword"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyPassword {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameColors"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionColors"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCColors {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameSmartSizeMode"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionSmartSizeMode"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCSmartSizeMode {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInheritAttribute("PropertyNameViewOnly"), 
		LocalizedAttributes.LocalizedDescriptionInheritAttribute("PropertyDescriptionViewOnly"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCViewOnly {get; set;}
        #endregion

        [Browsable(false)] public object Parent { get; set; }

        #endregion


        public ConnectionInfoInheritance(object parent, bool ignoreDefaultInheritance = false)
        {
            Parent = parent;
            if (!ignoreDefaultInheritance)
                SetAllValues(DefaultConnectionInheritance.Instance);
        }


        public ConnectionInfoInheritance Clone()
        {
            var newInheritance = (ConnectionInfoInheritance)MemberwiseClone();
            newInheritance._tempInheritanceStorage = null;
            return newInheritance;
        }

        public void EnableInheritance()
        {
            if (_tempInheritanceStorage != null)
                UnstashInheritanceData();
        }

        private void UnstashInheritanceData()
        {
            SetAllValues(_tempInheritanceStorage);
            _tempInheritanceStorage = null;
        }

        public void DisableInheritance()
        {
            StashInheritanceData();
            TurnOffInheritanceCompletely();
        }

        private void StashInheritanceData()
        {
            _tempInheritanceStorage = Clone();
        }

        public void TurnOnInheritanceCompletely()
        {
            SetAllValues(true);
        }

        public void TurnOffInheritanceCompletely()
        {
            SetAllValues(false);
        }

        private bool EverythingIsInherited()
        {
            var inheritanceProperties = GetProperties();
            var everythingInherited = inheritanceProperties.All((p) => (bool)p.GetValue(this, null));
            return everythingInherited;
        }

        public IEnumerable<PropertyInfo> GetProperties()
        {
            var properties = typeof(ConnectionInfoInheritance).GetProperties();
            var filteredProperties = properties.Where(FilterProperty);
            return filteredProperties;
        }

        private bool FilterProperty(PropertyInfo propertyInfo)
        {
            var exclusions = new[] {"EverythingInherited", "Parent"};
            var valueShouldNotBeFiltered = !exclusions.Contains(propertyInfo.Name);
            return valueShouldNotBeFiltered;
        }

        private void SetAllValues(bool value)
        {
            var properties = GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType.Name == typeof(bool).Name)
                    property.SetValue(this, value, null);
            }
        }

        private void SetAllValues(ConnectionInfoInheritance otherInheritanceObject)
        {
            var properties = GetProperties();
            foreach (var property in properties)
            {
                var newPropertyValue = property.GetValue(otherInheritanceObject, null);
                property.SetValue(this, newPropertyValue, null);
            }
        }
    }
}