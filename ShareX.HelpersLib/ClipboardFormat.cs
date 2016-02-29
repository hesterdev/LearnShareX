using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareX.HelpersLib
{
    public class ClipboardFormat
    {
        public string Description { get; set; }
        public string Format { get; set; }

        public ClipboardFormat()
        {
        }
        public ClipboardFormat(string description,string format)
        {
            Description = description;
            Format = format;
        }
    }
}
