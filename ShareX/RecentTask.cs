using ShareX.HelpersLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShareX
{
    public class RecentTask
    {
        public string FilePath { get; set; }
        public string FileName
        {
            get
            {
                string text = ToString();
                if (!string.IsNullOrEmpty(text))
                {
                    text = Path.GetFileName(text);
                }
                return text;
            }
        }
        public string URL { get; set; }
        public string ThumbnailURL { get; set; }
        public string DeletionURL { get; set; }
        public string ShortenedURL { get; set; }

        public DateTime Time { get; set; }

        public string TrayMenuText
        {
            get
            {
                string text = ToString().Truncate(50, "...", false);
                return string.Format("[{0:HH:mm:ss}] {1}", Time.ToLocalTime(), text);
            }
        }

        public RecentTask()
        {
            Time=DateTime.UtcNow;
        }
        public override string ToString()
        {
            string text = "";
            if (!string.IsNullOrEmpty(ShortenedURL))
            {
                text = ShortenedURL;
            }
            else if (!string.IsNullOrEmpty(URL))
            {
                text = URL;
            }
            else if (!string.IsNullOrEmpty(FilePath))
            {
                text = FilePath;
            }
            return text;
        }
    }
}
