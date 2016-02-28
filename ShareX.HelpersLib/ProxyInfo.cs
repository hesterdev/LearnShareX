using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace ShareX.HelpersLib
{
    public class ProxyInfo
    {
        public ProxyMethod ProxyMethod { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ProxyInfo()
        {
            ProxyMethod = ProxyMethod.Manual;
        }

        public bool IsValidProxy()
        {
            if (ProxyMethod == ProxyMethod.Manual)
            {
                return !string.IsNullOrEmpty(Host) && Port > 0;
            }
            if (ProxyMethod == ProxyMethod.Automatic)
            {
                //WebProxy systemProxy=Get
            }
            return true;
        }


        private WebProxy GetDefaultWebProxy()
        {
            try
            {
                //Need better solution
                return (WebProxy)typeof(WebProxy).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(bool) }, null).Invoke(new object[] { true });
            }catch(Exception e)
            {

            }
            return null;
        }
    }
}
