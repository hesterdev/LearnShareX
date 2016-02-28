using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Windows.Forms;

namespace ShareX.HelpersLib
{
    public abstract class UpdateChecker
    {
        public UpdateStatus Status { get; set; }
        public Version CurrentVersion { get; set; }
        public Version LatestVersion { get; set; }
        public ReleaseChannelType ReleaseType { get; set; }
        public bool IsBeta { get; set; }
        public bool IsPortable { get; set; }
        public IWebProxy Proxy { get; set; }

        private string filename;

        public string Filename
        {
            get
            {
                if (string.IsNullOrEmpty(filename))
                {
                    return HttpUtility.UrlDecode(DownloadURL.Substring(DownloadURL.LastIndexOf('/')+1));
                }
                return filename;
            }
            set
            {
                filename = value;
            }
        }

        public string DownloadURL { get; set; }

        private const bool forceUpdate = false;// For testing purposes

        public void RefreshStatus()
        {
            if(CurrentVersion== null)
            {
                CurrentVersion = Version.Parse(Application.ProductVersion);
            }
            if(Status!=UpdateStatus.UpdateCheckFailed && CurrentVersion!=null && LatestVersion!=null && !string.IsNullOrEmpty(DownloadURL) &&
                (forceUpdate || Helpers.CompareVersion(CurrentVersion,LatestVersion)<0 ||(IsBeta && Helpers.CompareVersion(CurrentVersion,LatestVersion)==0))){
                Status = UpdateStatus.UpdateAvailable;
            }
            else
            {
                Status = UpdateStatus.UpToDate;
            }
        }

        public abstract void CheckUpdate();

        public void DownloadUpdate()
        {
            if (IsPortable)
            {
                URLHelpers.OpenURL(DownloadURL);
            }
            else
            {
                //using ()
            }
        }
    }
}
