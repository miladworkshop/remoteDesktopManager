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
        #region Fields

        private string _name;
        private string _description;
        private string _icon;
        private string _panel;

        private string _hostname;
        private string _username = "";
        private string _password = "";
        private string _domain = "";

        private ProtocolType _protocol;
        private string _extApp;
        private int _port;
        private string _puttySession;
        private IcaProtocol.EncryptionStrength _icaEncryption;
        private bool _useConsoleSession;
        private RdpProtocol.AuthenticationLevel _rdpAuthenticationLevel;
        private int _rdpMinutesToIdleTimeout;
        private bool _rdpAlertIdleTimeout;
        private string _loadBalanceInfo;
        private HTTPBase.RenderingEngine _renderingEngine;
        private bool _useCredSsp;

        private RdpProtocol.RDGatewayUsageMethod _rdGatewayUsageMethod;
        private string _rdGatewayHostname;
        private RdpProtocol.RDGatewayUseConnectionCredentials _rdGatewayUseConnectionCredentials;
        private string _rdGatewayUsername;
        private string _rdGatewayPassword;
        private string _rdGatewayDomain;

        private RdpProtocol.RDPResolutions _resolution;
        private bool _automaticResize;
        private RdpProtocol.RDPColors _colors;
        private bool _cacheBitmaps;
        private bool _displayWallpaper;
        private bool _displayThemes;
        private bool _enableFontSmoothing;
        private bool _enableDesktopComposition;

        private bool _redirectKeys;
        private bool _redirectDiskDrives;
        private bool _redirectPrinters;
        private bool _redirectClipboard;
        private bool _redirectPorts;
        private bool _redirectSmartCards;
        private RdpProtocol.RDPSounds _redirectSound;
        private RdpProtocol.RDPSoundQuality _soundQuality;

        private string _preExtApp;
        private string _postExtApp;
        private string _macAddress;
        private string _userField;

        private ProtocolVNC.Compression _vncCompression;
        private ProtocolVNC.Encoding _vncEncoding;
        private ProtocolVNC.AuthMode _vncAuthMode;
        private ProtocolVNC.ProxyType _vncProxyType;
        private string _vncProxyIp;
        private int _vncProxyPort;
        private string _vncProxyUsername;
        private string _vncProxyPassword;
        private ProtocolVNC.Colors _vncColors;
        private ProtocolVNC.SmartSizeMode _vncSmartSizeMode;
        private bool _vncViewOnly;

        #endregion

        #region Properties

        #region Display

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay"),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameName"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionName")]
        public virtual string Name
        {
            get => _name;
            set => SetField(ref _name, value, "Name");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay"),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameDescription"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionDescription")]
        public virtual string Description
        {
            get => GetPropertyValue("Description", _description);
            set => SetField(ref _description, value, "Description");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay"),
         TypeConverter(typeof(ConnectionIcon)),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameIcon"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionIcon")]
        public virtual string Icon
        {
            get => GetPropertyValue("Icon", _icon);
            set => SetField(ref _icon, value, "Icon");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryDisplay"),
         LocalizedAttributes.LocalizedDisplayName("PropertyNamePanel"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionPanel")]
        public virtual string Panel
        {
            get => GetPropertyValue("Panel", _panel);
            set => SetField(ref _panel, value, "Panel");
        }

        #endregion

        #region Connection

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 2),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameAddress"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionAddress")]
        public virtual string Hostname
        {
            get => _hostname.Trim();
            set => SetField(ref _hostname, value?.Trim(), "Hostname");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 2),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameUsername"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionUsername")]
        public virtual string Username
        {
            get => GetPropertyValue("Username", _username);
            set => SetField(ref _username, value?.Trim(), "Username");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 2),
         LocalizedAttributes.LocalizedDisplayName("PropertyNamePassword"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionPassword"),
         PasswordPropertyText(true)]
        public virtual string Password
        {
            get => GetPropertyValue("Password", _password);
            set => SetField(ref _password, value, "Password");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 2),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameDomain"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionDomain")]
        public string Domain
        {
            get => GetPropertyValue("Domain", _domain).Trim();
            set => SetField(ref _domain, value?.Trim(), "Domain");
        }

        #endregion

        #region Protocol

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("Protocol"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionProtocol"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public virtual ProtocolType Protocol
        {
            get => GetPropertyValue("Protocol", _protocol);
            set => SetField(ref _protocol, value, "Protocol");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameExternalTool"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionExternalTool"),
         TypeConverter(typeof(ExternalToolsTypeConverter))]
        public string ExtApp
        {
            get => GetPropertyValue("ExtApp", _extApp);
            set => SetField(ref _extApp, value, "ExtApp");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNamePort"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionPort")]
        public virtual int Port
        {
            get => GetPropertyValue("Port", _port);
            set => SetField(ref _port, value, "Port");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNamePuttySession"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionPuttySession"),
         TypeConverter(typeof(Config.Putty.PuttySessionsManager.SessionList))]
        public virtual string PuttySession
        {
            get => GetPropertyValue("PuttySession", _puttySession);
            set => SetField(ref _puttySession, value, "PuttySession");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameEncryptionStrength"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionEncryptionStrength"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public IcaProtocol.EncryptionStrength ICAEncryptionStrength
        {
            get => GetPropertyValue("ICAEncryptionStrength", _icaEncryption);
            set => SetField(ref _icaEncryption, value, "ICAEncryptionStrength");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameUseConsoleSession"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionUseConsoleSession"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseConsoleSession
        {
            get => GetPropertyValue("UseConsoleSession", _useConsoleSession);
            set => SetField(ref _useConsoleSession, value, "UseConsoleSession");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameAuthenticationLevel"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionAuthenticationLevel"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.AuthenticationLevel RDPAuthenticationLevel
        {
            get => GetPropertyValue("RDPAuthenticationLevel", _rdpAuthenticationLevel);
            set => SetField(ref _rdpAuthenticationLevel, value, "RDPAuthenticationLevel");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDPMinutesToIdleTimeout"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRDPMinutesToIdleTimeout")]
        public virtual int RDPMinutesToIdleTimeout
        {
            get => GetPropertyValue("RDPMinutesToIdleTimeout", _rdpMinutesToIdleTimeout);
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > 240)
                    value = 240;
                SetField(ref _rdpMinutesToIdleTimeout, value, "RDPMinutesToIdleTimeout");
            }
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDPAlertIdleTimeout"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRDPAlertIdleTimeout")]
        public bool RDPAlertIdleTimeout
        {
            get => GetPropertyValue("RDPAlertIdleTimeout", _rdpAlertIdleTimeout);
            set => SetField(ref _rdpAlertIdleTimeout, value, "RDPAlertIdleTimeout");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameLoadBalanceInfo"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionLoadBalanceInfo")]
        public string LoadBalanceInfo
        {
            get => GetPropertyValue("LoadBalanceInfo", _loadBalanceInfo).Trim();
            set => SetField(ref _loadBalanceInfo, value?.Trim(), "LoadBalanceInfo");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRenderingEngine"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRenderingEngine"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public HTTPBase.RenderingEngine RenderingEngine
        {
            get => GetPropertyValue("RenderingEngine", _renderingEngine);
            set => SetField(ref _renderingEngine, value, "RenderingEngine");
        }

        [LocalizedAttributes.LocalizedCategory("Protocol", 3),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameUseCredSsp"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionUseCredSsp"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool UseCredSsp
        {
            get => GetPropertyValue("UseCredSsp", _useCredSsp);
            set => SetField(ref _useCredSsp, value, "UseCredSsp");
        }

        #endregion

        #region RD Gateway

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 4),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDGatewayUsageMethod"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRDGatewayUsageMethod"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDGatewayUsageMethod RDGatewayUsageMethod
        {
            get => GetPropertyValue("RDGatewayUsageMethod", _rdGatewayUsageMethod);
            set => SetField(ref _rdGatewayUsageMethod, value, "RDGatewayUsageMethod");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 4),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDGatewayHostname"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRDGatewayHostname")]
        public string RDGatewayHostname
        {
            get => GetPropertyValue("RDGatewayHostname", _rdGatewayHostname).Trim();
            set => SetField(ref _rdGatewayHostname, value?.Trim(), "RDGatewayHostname");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 4),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDGatewayUseConnectionCredentials"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRDGatewayUseConnectionCredentials"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDGatewayUseConnectionCredentials RDGatewayUseConnectionCredentials
        {
            get => GetPropertyValue("RDGatewayUseConnectionCredentials", _rdGatewayUseConnectionCredentials);
            set => SetField(ref _rdGatewayUseConnectionCredentials, value, "RDGatewayUseConnectionCredentials");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 4),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDGatewayUsername"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRDGatewayUsername")]
        public string RDGatewayUsername
        {
            get => GetPropertyValue("RDGatewayUsername", _rdGatewayUsername).Trim();
            set => SetField(ref _rdGatewayUsername, value?.Trim(), "RDGatewayUsername");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 4),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDGatewayPassword"),
         LocalizedAttributes.LocalizedDescription("PropertyNameRDGatewayPassword"),
         PasswordPropertyText(true)]
        public string RDGatewayPassword
        {
            get => GetPropertyValue("RDGatewayPassword", _rdGatewayPassword);
            set => SetField(ref _rdGatewayPassword, value, "RDGatewayPassword");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryGateway", 4),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRDGatewayDomain"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRDGatewayDomain")]
        public string RDGatewayDomain
        {
            get => GetPropertyValue("RDGatewayDomain", _rdGatewayDomain).Trim();
            set => SetField(ref _rdGatewayDomain, value?.Trim(), "RDGatewayDomain");
        }

        #endregion

        #region Appearance

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameResolution"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionResolution"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPResolutions Resolution
        {
            get => GetPropertyValue("Resolution", _resolution);
            set => SetField(ref _resolution, value, "Resolution");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameAutomaticResize"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionAutomaticResize"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool AutomaticResize
        {
            get => GetPropertyValue("AutomaticResize", _automaticResize);
            set => SetField(ref _automaticResize, value, "AutomaticResize");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameColors"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionColors"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPColors Colors
        {
            get => GetPropertyValue("Colors", _colors);
            set => SetField(ref _colors, value, "Colors");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameCacheBitmaps"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionCacheBitmaps"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool CacheBitmaps
        {
            get => GetPropertyValue("CacheBitmaps", _cacheBitmaps);
            set => SetField(ref _cacheBitmaps, value, "CacheBitmaps");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameDisplayWallpaper"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionDisplayWallpaper"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayWallpaper
        {
            get => GetPropertyValue("DisplayWallpaper", _displayWallpaper);
            set => SetField(ref _displayWallpaper, value, "DisplayWallpaper");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameDisplayThemes"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionDisplayThemes"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool DisplayThemes
        {
            get => GetPropertyValue("DisplayThemes", _displayThemes);
            set => SetField(ref _displayThemes, value, "DisplayThemes");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameEnableFontSmoothing"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionEnableFontSmoothing"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableFontSmoothing
        {
            get => GetPropertyValue("EnableFontSmoothing", _enableFontSmoothing);
            set => SetField(ref _enableFontSmoothing, value, "EnableFontSmoothing");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameEnableDesktopComposition"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionEnableDesktopComposition"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool EnableDesktopComposition
        {
            get => GetPropertyValue("EnableDesktopComposition", _enableDesktopComposition);
            set => SetField(ref _enableDesktopComposition, value, "EnableDesktopComposition");
        }

        #endregion

        #region Redirect

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRedirectKeys"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRedirectKeys"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectKeys
        {
            get => GetPropertyValue("RedirectKeys", _redirectKeys);
            set => SetField(ref _redirectKeys, value, "RedirectKeys");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRedirectDrives"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRedirectDrives"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectDiskDrives
        {
            get => GetPropertyValue("RedirectDiskDrives", _redirectDiskDrives);
            set => SetField(ref _redirectDiskDrives, value, "RedirectDiskDrives");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRedirectPrinters"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRedirectPrinters"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPrinters
        {
            get => GetPropertyValue("RedirectPrinters", _redirectPrinters);
            set => SetField(ref _redirectPrinters, value, "RedirectPrinters");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRedirectClipboard"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRedirectClipboard"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectClipboard
        {
            get { return GetPropertyValue("RedirectClipboard", _redirectClipboard); }
            set { SetField(ref _redirectClipboard, value, "RedirectClipboard"); }
        }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRedirectPorts"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRedirectPorts"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectPorts
        {
            get => GetPropertyValue("RedirectPorts", _redirectPorts);
            set => SetField(ref _redirectPorts, value, "RedirectPorts");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRedirectSmartCards"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRedirectSmartCards"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool RedirectSmartCards
        {
            get => GetPropertyValue("RedirectSmartCards", _redirectSmartCards);
            set => SetField(ref _redirectSmartCards, value, "RedirectSmartCards");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameRedirectSounds"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionRedirectSounds"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPSounds RedirectSound
        {
            get => GetPropertyValue("RedirectSound", _redirectSound);
            set => SetField(ref _redirectSound, value, "RedirectSound");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryRedirect", 6),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameSoundQuality"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionSoundQuality"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public RdpProtocol.RDPSoundQuality SoundQuality
        {
            get => GetPropertyValue("SoundQuality", _soundQuality);
            set => SetField(ref _soundQuality, value, "SoundQuality");
        }

        #endregion

        #region Misc

        [Browsable(false)] public string ConstantID { get; /*set;*/ }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 7),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameExternalToolBefore"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionExternalToolBefore"),
         TypeConverter(typeof(ExternalToolsTypeConverter))]
        public virtual string PreExtApp
        {
            get => GetPropertyValue("PreExtApp", _preExtApp);
            set => SetField(ref _preExtApp, value, "PreExtApp");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 7),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameExternalToolAfter"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionExternalToolAfter"),
         TypeConverter(typeof(ExternalToolsTypeConverter))]
        public virtual string PostExtApp
        {
            get => GetPropertyValue("PostExtApp", _postExtApp);
            set => SetField(ref _postExtApp, value, "PostExtApp");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 7),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameMACAddress"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionMACAddress")]
        public virtual string MacAddress
        {
            get => GetPropertyValue("MacAddress", _macAddress);
            set => SetField(ref _macAddress, value, "MacAddress");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryMiscellaneous", 7),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameUser1"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionUser1")]
        public virtual string UserField
        {
            get => GetPropertyValue("UserField", _userField);
            set => SetField(ref _userField, value, "UserField");
        }

        #endregion

        #region VNC

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameCompression"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionCompression"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.Compression VNCCompression
        {
            get => GetPropertyValue("VNCCompression", _vncCompression);
            set => SetField(ref _vncCompression, value, "VNCCompression");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameEncoding"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionEncoding"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.Encoding VNCEncoding
        {
            get => GetPropertyValue("VNCEncoding", _vncEncoding);
            set => SetField(ref _vncEncoding, value, "VNCEncoding");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryConnection", 2),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameAuthenticationMode"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionAuthenticationMode"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.AuthMode VNCAuthMode
        {
            get => GetPropertyValue("VNCAuthMode", _vncAuthMode);
            set => SetField(ref _vncAuthMode, value, "VNCAuthMode");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryProxy", 7),
            Browsable(false),
            LocalizedAttributes.LocalizedDisplayName("PropertyNameVNCProxyType"),
            LocalizedAttributes.LocalizedDescription("PropertyDescriptionVNCProxyType"),
            TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.ProxyType VNCProxyType
        {
            get => GetPropertyValue("VNCProxyType", _vncProxyType);
            set => SetField(ref _vncProxyType, value, "VNCProxyType");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryProxy", 7),
            Browsable(false),
            LocalizedAttributes.LocalizedDisplayName("PropertyNameVNCProxyAddress"),
            LocalizedAttributes.LocalizedDescription("PropertyDescriptionVNCProxyAddress")]
        public string VNCProxyIP
        {
            get => GetPropertyValue("VNCProxyIP", _vncProxyIp);
            set => SetField(ref _vncProxyIp, value, "VNCProxyIP");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryProxy", 7),
            Browsable(false),
            LocalizedAttributes.LocalizedDisplayName("PropertyNameVNCProxyPort"),
            LocalizedAttributes.LocalizedDescription("PropertyDescriptionVNCProxyPort")]
        public int VNCProxyPort
        {
            get => GetPropertyValue("VNCProxyPort", _vncProxyPort);
            set => SetField(ref _vncProxyPort, value, "VNCProxyPort");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryProxy", 7),
            Browsable(false),
            LocalizedAttributes.LocalizedDisplayName("PropertyNameVNCProxyUsername"),
            LocalizedAttributes.LocalizedDescription("PropertyDescriptionVNCProxyUsername")]
        public string VNCProxyUsername
        {
            get => GetPropertyValue("VNCProxyUsername", _vncProxyUsername);
            set => SetField(ref _vncProxyUsername, value, "VNCProxyUsername");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryProxy", 7),
            Browsable(false),
            LocalizedAttributes.LocalizedDisplayName("PropertyNameVNCProxyPassword"),
            LocalizedAttributes.LocalizedDescription("PropertyDescriptionVNCProxyPassword"),
            PasswordPropertyText(true)]
        public string VNCProxyPassword
        {
            get => GetPropertyValue("VNCProxyPassword", _vncProxyPassword);
            set => SetField(ref _vncProxyPassword, value, "VNCProxyPassword");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         Browsable(false),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameColors"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionColors"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.Colors VNCColors
        {
            get => GetPropertyValue("VNCColors", _vncColors);
            set => SetField(ref _vncColors, value, "VNCColors");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameSmartSizeMode"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionSmartSizeMode"),
         TypeConverter(typeof(MiscTools.EnumTypeConverter))]
        public ProtocolVNC.SmartSizeMode VNCSmartSizeMode
        {
            get => GetPropertyValue("VNCSmartSizeMode", _vncSmartSizeMode);
            set => SetField(ref _vncSmartSizeMode, value, "VNCSmartSizeMode");
        }

        [LocalizedAttributes.LocalizedCategory("CategoryAppearance", 5),
         LocalizedAttributes.LocalizedDisplayName("PropertyNameViewOnly"),
         LocalizedAttributes.LocalizedDescription("PropertyDescriptionViewOnly"),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public bool VNCViewOnly
        {
            get => GetPropertyValue("VNCViewOnly", _vncViewOnly);
            set => SetField(ref _vncViewOnly, value, "VNCViewOnly");
        }

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