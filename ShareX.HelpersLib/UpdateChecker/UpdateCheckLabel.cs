using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareX.HelpersLib
{
    public partial class UpdateCheckLabel : UserControl
    {
        public delegate UpdateChecker CheckUpdate();
        public UpdateCheckLabel()
        {
            InitializeComponent();
        }
    }
}
