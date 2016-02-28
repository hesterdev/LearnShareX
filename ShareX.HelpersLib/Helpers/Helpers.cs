using ShareX.HelpersLib.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareX.HelpersLib
{
    public static class Helpers
    {
        public static int CompareVersion(Version version1,Version version2)
        {
            return version1.Normalize().CompareTo(version2.Normalize());
        }

        public static void CreateDirectoryFromFilePath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                CreateDirectoryFromDirectoryPath(Path.GetDirectoryName(path));
            }
        }
        public static void CreateDirectoryFromDirectoryPath(string path)
        {
            if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }catch(Exception e)
                {
                    DebugHelper.WriteException(e);
                    MessageBox.Show(Resources.Helpers_CreateDirectoryIfNotExist_Create_failed_);
                }
            }
        }
    }
}
