using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ShareX.HelpersLib
{
    public class WindowState
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool IsMaximized { get; set; }

        public void SetFormState(Form form)
        {
            if (!Location.IsEmpty && CaptureHelpers.GetScreenBounds().IntersectsWith(new Rectangle(Location, Size)))
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
            }
            if (!Size.IsEmpty)
            {
                form.Size = Size;
            }
            if (IsMaximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }
        public void GetFormState(Form form)
        {
            WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
            wp.length = Marshal.SizeOf(wp);
            if(NativeMethods.GetWindowPlacement(form.Handle,ref wp))
            {
                Location = wp.rcNormalPosition.Location;
                Size = wp.rcNormalPosition.Size;
                IsMaximized = wp.showCmd == WindowShowStyle.Maximize;
            }
        }
    }
}
