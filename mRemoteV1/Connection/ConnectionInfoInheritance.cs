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
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameAll"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionAll"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EverythingInherited
        {
            get { return EverythingIsInherited(); }
            set { SetAllValues(value); }
        }

        #endregion

        #region Display

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay", 2),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameDescription"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionDescription"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Description { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay", 2),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameIcon"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionIcon"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Icon { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay", 2),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNamePanel"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionPanel"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Panel { get; set; }

        #endregion

        #region Connection

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 3),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameUsername"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionUsername"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        [Browsable(true)]
        public bool Username { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 3),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNamePassword"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionPassword"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        [Browsable(true)]
        public bool Password { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 3),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameDomain"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionDomain"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        [Browsable(true)]
        public bool Domain { get; set; }

        #endregion

        #region Protocol

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("Protocol"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionProtocol"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Protocol { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameExternalTool"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionExternalTool"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool ExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNamePort"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionPort"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Port { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNamePuttySession"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionPuttySession"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool PuttySession { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameEncryptionStrength"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionEncryptionStrength"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool ICAEncryptionStrength { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameAuthenticationLevel"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionAuthenticationLevel"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDPAuthenticationLevel { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDPMinutesToIdleTimeout"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRDPMinutesToIdleTimeout"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDPMinutesToIdleTimeout { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDPAlertIdleTimeout"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRDPAlertIdleTimeout"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDPAlertIdleTimeout { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameLoadBalanceInfo"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionLoadBalanceInfo"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool LoadBalanceInfo { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRenderingEngine"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRenderingEngine"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RenderingEngine { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameUseConsoleSession"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionUseConsoleSession"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseConsoleSession { get; set; }

        [LocalizedAttributes.LocalizedCategory("Protocol", 4),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameUseCredSsp"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionUseCredSsp"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseCredSsp { get; set; }

        #endregion

        #region RD Gateway

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDGatewayUsageMethod"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRDGatewayUsageMethod"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayUsageMethod { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDGatewayHostname"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRDGatewayHostname"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayHostname { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDGatewayUseConnectionCredentials"),
         LocalizedAttributes.LocalizedDescriptionInherit(
             "strPropertyDescriptionRDGatewayUseConnectionCredentials"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayUseConnectionCredentials { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDGatewayUsername"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRDGatewayUsername"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayUsername { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDGatewayPassword"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRDGatewayPassword"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayPassword { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 5),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRDGatewayDomain"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRDGatewayDomain"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RDGatewayDomain { get; set; }

        #endregion

        #region Appearance

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameResolution"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionResolution"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Resolution { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameAutomaticResize"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionAutomaticResize"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool AutomaticResize { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameColors"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionColors"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool Colors { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameCacheBitmaps"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionCacheBitmaps"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool CacheBitmaps { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameDisplayWallpaper"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionDisplayWallpaper"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayWallpaper { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameDisplayThemes"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionDisplayThemes"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayThemes { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameEnableFontSmoothing"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionEnableFontSmoothing"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableFontSmoothing { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 6),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameEnableDesktopComposition"),
         LocalizedAttributes.LocalizedDescriptionInherit("strPropertyDescriptionEnableEnableDesktopComposition"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableDesktopComposition { get; set; }

        #endregion

        #region Redirect

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRedirectKeys"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRedirectKeys"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectKeys { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRedirectDrives"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRedirectDrives"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectDiskDrives { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRedirectPrinters"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRedirectPrinters"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPrinters { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRedirectClipboard"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRedirectClipboard"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectClipboard { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRedirectPorts"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRedirectPorts"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPorts { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRedirectSmartCards"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRedirectSmartCards"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectSmartCards { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameRedirectSounds"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionRedirectSounds"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectSound { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 7),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameSoundQuality"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionSoundQuality"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool SoundQuality { get; set; }

        #endregion

        #region Misc

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameExternalToolBefore"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionExternalToolBefore"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool PreExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameExternalToolAfter"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionExternalToolAfter"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool PostExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameMACAddress"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionMACAddress"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool MacAddress { get; set; }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 8),
         LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameUser1"),
         LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionUser1"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UserField { get; set; }

        #endregion

        #region VNC
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameCompression"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionCompression"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCCompression {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameEncoding"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionEncoding"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCEncoding {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryConnection", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameAuthenticationMode"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionAuthenticationMode"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCAuthMode {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameVNCProxyType"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionVNCProxyType"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyType {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameVNCProxyAddress"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionVNCProxyAddress"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyIP {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameVNCProxyPort"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionVNCProxyPort"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyPort {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameVNCProxyUsername"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionVNCProxyUsername"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyUsername {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryProxy", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameVNCProxyPassword"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionVNCProxyPassword"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCProxyPassword {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameColors"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionColors"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCColors {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameSmartSizeMode"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionSmartSizeMode"), 
		TypeConverter(typeof(MiscTools.YesNoTypeConverter))]public bool VNCSmartSizeMode {get; set;}
				
		[LocalizedAttributes.LocalizedCategory("CategoryAppearance", 9), 
		LocalizedAttributes.LocalizedDisplayNameInherit("PropertyNameViewOnly"), 
		LocalizedAttributes.LocalizedDescriptionInherit("PropertyDescriptionViewOnly"), 
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