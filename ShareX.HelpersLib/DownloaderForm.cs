using ShareX.HelpersLib.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ShareX.HelpersLib
{

    // TODO: 修改为BlackStyleForm
    public partial class DownloaderForm : BaseForm
    {
        public delegate void DownloaderInstallEventHandler(string filePath);
        public event DownloaderInstallEventHandler InstallRequested;

        public string URL { get; set; }
        public string Filename { get; set; }
        public string SavePath { get; private set; }
        public IWebProxy Proxy { get; set; }
        public string Changelog { get; set; }
        public string AcceptHeader { get; set; }
        public bool AutoStartDownload { get; set; }
        public InstallType InstallType { get; set; }
        public bool AutoStartInstall { get; set; }
        public DownloaderFormStatus Status { get; private set; }
        public bool RunInstallerInBackground { get; set; }

        private FileDownloader fileDownloader;
        private FileStream fileStream;
        private Rectangle fillRect;

        private DownloaderForm()
        {
            InitializeComponent();

            fillRect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);

            //UpdateFormSize();
            //ChangeStatus(Resources.DownloaderForm_DownloaderForm_Waiting_);

            Status = DownloaderFormStatus.Waiting;

            AutoStartDownload = true;
            InstallType = InstallType.Silent;
            AutoStartInstall = true;
            RunInstallerInBackground = true;
        }

        public DownloaderForm(string url, string filename) : this()
        {
            URL = url;
            Filename = filename;

        }

        public DownloaderForm(UpdateChecker updateChecker) : this(updateChecker.DownloadURL, updateChecker.Filename)
        {
            Proxy = updateChecker.Proxy;
            if (updateChecker is GitHubUpdateChecker)
            {
                AcceptHeader = "application/octet-stream";
            }
        }
    }
}
