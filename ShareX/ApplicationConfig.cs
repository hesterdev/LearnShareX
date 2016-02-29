using ShareX.HelpersLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ShareX.UploadersLib;

namespace ShareX
{
    public class ApplicationConfig:SettingsBase<ApplicationConfig>
    {
        public TaskSettings DefaultTaskSettings = new TaskSettings();

        public string FileUploadDefaultDirectory = "";
        public bool ShowUploadWarning = true;//First time upload warning
        public bool ShowMultiUploadWarning = true;// More than 10 files upload warning
        public bool ShowTrayLeftClickTip = true;//Tray icon left click tip
        public int NameParserAutoIncrementNumber = 0;
        public bool DisableHotkeys = false;
        public List<QuickTaskInfo> QuickTaskPresets = QuickTaskInfo.DefaultPresets;

        public ApplicationConfig()
        {
            this.ApplyDefaultPropertyValues();
        }

        #region Main Form

        public bool ShowMenu = true;
        public bool ShowColumns = true;
        public ImagePreviewVisibility ImagePreview = ImagePreviewVisibility.Automatic;
        public int PreviewSplitterDistance = 335;

        #endregion

        #region Settings Form

        #region General

        public SupportedLanguage Lauguage = SupportedLanguage.Automatic;
        public bool ShowTray = true;
        public bool SilentRun = false;
        public bool TrayIconProgressEnabled = true;
        public bool RememberMainFormPosition = false;
        public bool RememberMainFormSize = false;
        public Size MainFormSize = Size.Empty;

        #endregion

        #region Paths

        public bool UseCustomScreenshotPath = false;
        public string CustomScreenshotPath = string.Empty;
        public string SaveImageSubFolderPattern = "%y-%mo";

        #endregion

        #region Export/Import

        public bool ExportSettings = true;
        public bool ExportHistory = true;
        public bool ExportLogs = false;

        #endregion

        #region Proxy

        public ProxyInfo ProxySettings = new ProxyInfo();

        #endregion

        #region Upload

        public int UploadLimit = 5;
        public int BufferSizePower = 5;
        public List<ClipboardFormat> ClipboardContentFormats = new List<ClipboardFormat>();

        public int MaxUploadFailRetry = 1;
        public bool UseSecondaryUploaders = false;
        public List<ImageDestination> SecondaryImageUploaders = new List<ImageDestination>();
        public List<TextDestination> SecondaryTextUploaders = new List<TextDestination>();
        public List<FileDestination> SecondaryFileUploaders = new List<FileDestination>();

        #endregion

        #region History

        public bool HistorySaveTasks = true;
        public bool HistoryCheckURL = false;

        public RecentTask[] RecentTasks = null;
        public bool RecentTaskSave = true;
        public int RecentTaskMaxCount = 10;
        public bool RecentTasksShowInMainWindow = true;
        public bool RecentTasksShowInTrayMenu = true;
        public bool RecentTasksTrayMenuMostRecentFirst = false;

        public WindowState History
        #endregion

        #endregion
        private void ApplyDefaultPropertyValues()
        {
            throw new NotImplementedException();
        }
    }
}
