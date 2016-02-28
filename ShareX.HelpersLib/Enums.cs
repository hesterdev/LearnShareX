using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ShareX.HelpersLib
{
    public enum UpdateStatus
    {
        None,
        UpdateCheckFailed,
        UpdateAvailable,
        UpToDate
    }
    public enum ReleaseChannelType
    {
        [Description("Stable version")]
        Stable,
        [Description("Beta version")]
        Beta,
        [Description("Dev version")]
        Dev
    }
    public enum ProxyMethod //Localized
    {
        None,
        Manual,
        Automatic
    }
    public enum DownloaderFormStatus
    {
        Waiting,
        DownloadStarted,
        DownloadCompleted,
        InstallStarted
    }
    public enum InstallType
    {
        Default,
        Silent,
        VerySilent,
        Event
    }
}
