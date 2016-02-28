using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ShareX.HelpersLib
{
    public static class URLHelpers
    {
        public static void OpenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                TaskEx.Run(() =>
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(HelperOptions.BrowsePath))
                        {
                            Process.Start(HelperOptions.BrowsePath, url);
                        }
                        else
                        {
                            Process.Start(url);
                        }
                        DebugHelper.WriteLine("URL opened: " + url);
                    }
                    catch (Exception e)
                    {
                        DebugHelper.WriteException(e, string.Format("OpenURL({0}) failed", url));
                    }
                });
            }
        }
    }
}
