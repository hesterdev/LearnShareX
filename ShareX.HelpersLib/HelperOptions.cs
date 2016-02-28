using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareX.HelpersLib
{
    public static class HelperOptions
    {
        public static ProxyInfo CurrentProxy = new ProxyInfo();
        public static bool DefaultCopyImageFillBackground = true;
        public static bool UseAlternativeCopyImage = true;
        public static bool UseAlternativeGetImage = true;
        public static string BrowsePath = null;
    }
}
