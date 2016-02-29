using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ShareX
{
    public enum CaptureType
    {
        Screen,
        Monitor,
        ActiveMonitor,
        Window,
        ActiveWindow,
        Rectangle,
        Polygon,
        Freehand,
        CustomRegion,
        LastRegion
    }
    public enum ImagePreviewVisibility
    {
        Show, Hide, Automatic
    }

    public enum SupportedLanguage
    {
        Automatic,//Localized
        [Description("Nederlands(Dutch)")]
        Dutch,
        [Description("English")]
        English,
        [Description("French")]
        French,
        [Description("German")]
        German,
        Hungarian,
        Korean,
        ProtugueseBrazil,
        Russian,
        [Description("简体中文(Simplified Chinese")]
        SimplifiedChinese,
        Spanish,
        Turkish,
        Vietnamese
    }
}
