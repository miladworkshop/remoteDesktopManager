using System;
using System.Collections.Generic;
using System.ComponentModel;
using mRemoteNG.Connection.Protocol;
using mRemoteNG.Connection.Protocol.Http;
using mRemoteNG.Connection.Protocol.ICA;
using mRemoteNG.Connection.Protocol.RDP;
using mRemoteNG.Connection.Protocol.VNC;
using mRemoteNG.Tools;


namespace mRemoteNG.Connection
{
    [Obsolete("Valid for mRemoteNG v1.75 (confCons v2.6) or earlier")]
    public abstract class AbstractConnectionRecord : INotifyPropertyChanged
    {
        #region Properties

        #region Display

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryDisplay)),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameName)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionName))]
        public virtual string Name { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryDisplay)),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameDescription)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionDescription))]
        public virtual string Description { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryDisplay)),
         TypeConverter(typeof(ConnectionIcon)),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameIcon)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionIcon))]
        public virtual string Icon { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryDisplay)),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNamePanel)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionPanel))]
        public virtual string Panel { get; set; }

        #endregion

        #region Connection

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryConnection), 2),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameAddress)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionAddress))]
        public virtual string Hostname { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryConnection), 2),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameUsername)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionUsername))]
        public virtual string Username { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryConnection), 2),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNamePassword)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionPassword)),
         PasswordPropertyText(true)]
        public virtual string Password { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryConnection), 2),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameDomain)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionDomain))]
        public string Domain { get; set; }

        #endregion

        #region Protocol

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.Protocol)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionProtocol)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public virtual ProtocolType Protocol { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameExternalTool)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionExternalTool)),
         TypeConverter(typeof(ExternalToolsTypeConverter))]
        public string ExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNamePort)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionPort))]
        public virtual int Port { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNamePuttySession)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionPuttySession)),
         TypeConverter(typeof(Config.Putty.PuttySessionsManager.SessionList))]
        public virtual string PuttySession { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameEncryptionStrength)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionEncryptionStrength)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public IcaProtocol.EncryptionStrength ICAEncryptionStrength { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameUseConsoleSession)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionUseConsoleSession)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseConsoleSession { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameAuthenticationLevel)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionAuthenticationLevel)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.AuthenticationLevel RDPAuthenticationLevel { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDPMinutesToIdleTimeout)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRDPMinutesToIdleTimeout))]
        public virtual int RDPMinutesToIdleTimeout
        {
            get => Settings.Default.ConDefaultRDPMinutesToIdleTimeout;
            set 
            {
                if (value < 0)
                    value = 0;
                else if (value > 240)
                    value = 240;
                Settings.Default.ConDefaultRDPMinutesToIdleTimeout = value;
            }
        }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDPAlertIdleTimeout)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRDPAlertIdleTimeout))]
        public bool RDPAlertIdleTimeout { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameLoadBalanceInfo)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionLoadBalanceInfo))]
        public string LoadBalanceInfo { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRenderingEngine)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRenderingEngine)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public HTTPBase.RenderingEngine RenderingEngine { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(mRemoteNG.Language.Protocol), 3),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameUseCredSsp)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionUseCredSsp)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseCredSsp { get; set; }

        #endregion
        
        #region RD Gateway

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryGateway), 4),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDGatewayUsageMethod)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRDGatewayUsageMethod)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDGatewayUsageMethod RDGatewayUsageMethod { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryGateway), 4),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDGatewayHostname)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRDGatewayHostname))]
        public string RDGatewayHostname { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryGateway), 4),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDGatewayUseConnectionCredentials)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRDGatewayUseConnectionCredentials)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDGatewayUseConnectionCredentials RDGatewayUseConnectionCredentials { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryGateway), 4),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDGatewayUsername)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRDGatewayUsername))]
        public string RDGatewayUsername { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryGateway), 4),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDGatewayPassword)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyNameRDGatewayPassword)),
         PasswordPropertyText(true)]
        public string RDGatewayPassword { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryGateway), 4),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRDGatewayDomain)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRDGatewayDomain))]
        public string RDGatewayDomain { get; set; }

        #endregion

        #region Appearance

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameResolution)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionResolution)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPResolutions Resolution { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameAutomaticResize)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionAutomaticResize)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool AutomaticResize { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameColors)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionColors)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPColors Colors { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameCacheBitmaps)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionCacheBitmaps)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool CacheBitmaps { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameDisplayWallpaper)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionDisplayWallpaper)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayWallpaper { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameDisplayThemes)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionDisplayThemes)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayThemes { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameEnableFontSmoothing)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionEnableFontSmoothing)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableFontSmoothing { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameEnableDesktopComposition)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionEnableDesktopComposition)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableDesktopComposition { get; set; }

        #endregion

        #region Redirect

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRedirectKeys)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRedirectKeys)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectKeys { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRedirectDrives)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRedirectDrives)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectDiskDrives { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRedirectPrinters)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRedirectPrinters)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPrinters { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRedirectClipboard)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRedirectClipboard)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectClipboard { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRedirectPorts)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRedirectPorts)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPorts { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRedirectSmartCards)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRedirectSmartCards)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectSmartCards { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameRedirectSounds)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionRedirectSounds)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPSounds RedirectSound { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryRedirect), 6),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameSoundQuality)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionSoundQuality)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPSoundQuality SoundQuality { get; set; }

        #endregion

        #region Misc

        [Browsable(false)] public string ConstantID { get; /*set;*/ }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryMiscellaneous), 7),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameExternalToolBefore)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionExternalToolBefore)),
         TypeConverter(typeof(ExternalToolsTypeConverter))]
        public virtual string PreExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryMiscellaneous), 7),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameExternalToolAfter)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionExternalToolAfter)),
         TypeConverter(typeof(ExternalToolsTypeConverter))]
        public virtual string PostExtApp { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryMiscellaneous), 7),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameMACAddress)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionMACAddress))]
        public virtual string MacAddress { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryMiscellaneous), 7),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameUser1)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionUser1))]
        public virtual string UserField { get; set; }

        #endregion

        #region VNC

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameCompression)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionCompression)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.Compression VNCCompression { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameEncoding)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionEncoding)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.Encoding VNCEncoding { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryConnection), 2),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameAuthenticationMode)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionAuthenticationMode)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.AuthMode VNCAuthMode { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryProxy), 7),
        Browsable(false),
        LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameVNCProxyType)),
        LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionVNCProxyType)),
        TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.ProxyType VNCProxyType { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryProxy), 7),
        Browsable(false),
        LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameVNCProxyAddress)),
        LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionVNCProxyAddress))]
        public string VNCProxyIP { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryProxy), 7),
        Browsable(false),
        LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameVNCProxyPort)),
        LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionVNCProxyPort))]
        public int VNCProxyPort { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryProxy), 7),
        Browsable(false),
        LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameVNCProxyUsername)),
        LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionVNCProxyUsername))]
        public string VNCProxyUsername { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryProxy), 7),
        Browsable(false),
        LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameVNCProxyPassword)),
        LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionVNCProxyPassword)),
        PasswordPropertyText(true)]
        public string VNCProxyPassword { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameColors)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionColors)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.Colors VNCColors { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameSmartSizeMode)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionSmartSizeMode)),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.SmartSizeMode VNCSmartSizeMode { get; set; }

        [LocalizedAttributes.LocalizedCategory(nameof(Language.CategoryAppearance), 5),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PropertyNameViewOnly)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionViewOnly)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool VNCViewOnly { get; set; }

        #endregion

        #endregion

        protected AbstractConnectionRecord(string uniqueId)
        {
            ConstantID = uniqueId.ThrowIfNullOrEmpty(nameof(uniqueId));
        }

        protected virtual TPropertyType GetPropertyValue<TPropertyType>(string propertyName, TPropertyType value)
        {
            return (TPropertyType)GetType().GetProperty(propertyName)?.GetValue(this, null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent(object sender, PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(args.PropertyName));
        }

        protected void SetField<T>(ref T field, T value, string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            RaisePropertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}