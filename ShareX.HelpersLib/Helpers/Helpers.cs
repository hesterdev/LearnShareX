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

        public static readonly Version OSVersion = Environment.OSVersion.Version;

        #region 版本比较

        private static Version NormalizeVersion(string version)
        {
            return Version.Parse(version).Normalize();
        }
        public static int CompareVersion(string version1,string version2)
        {
            return NormalizeVersion(version1).CompareTo(NormalizeVersion(version2));
        }
        public static int CompareVersion(Version version1,Version version2)
        {
            return version1.Normalize().CompareTo(version2.Normalize());
        }

        public static int CompareApplicationVersion(string version)
        {
            return CompareVersion(version, Application.ProductVersion);
        }

        #endregion

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

        public static bool IsWindows10OrGreater()
        {
            return OSVersion.Major >= 10;
        }

        internal static bool IsWindowsVistaOrGreater()
        {
            return true;
        }
    }
}
