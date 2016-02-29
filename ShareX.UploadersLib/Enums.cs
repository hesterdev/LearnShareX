using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ShareX.UploadersLib
{
    [Description("Image uploaders"),DefaultValue(Imgur)]
    public enum ImageDestination
    {
        [Description("Imgur")]
        Imgur,
        ImageShack,
        TinyPic,
        Flickr,
        Phototbucket,
        Picasa,
        Twitter,
        Cheverto,
        Vgyme,
        SomeImage,
        Imgland,
        CustomImageUploader,//Localized
        FileUploader//Localized
    }

    [Description("Text uploaders"),DefaultValue(Pastebin)]
    public enum TextDestination
    {
        Pastebin,
        Paste2,
        Slexy,
        Pastee,
        Pastee_ee,
        Gist,
        Upaste,
        Hastebin,
        OneTimeSecret,
        CustomTextUploader,//Localized
        FileUploader//Localized
    }

    [Description("File uploaders"),DefaultValue(Dropbox)]
    public enum FileDestination
    {
        Dropbox,
        FTP,
        OneDrive,
        GoogleDrive,
        Copy,
        Box,
        Mega,
        AmazonS3,
        OwnCloud,
        MediaFire,
        Gfycat,
        Pushbullet,
        SendSpace,
        Minus,
        Ge_tt,
        Localhostr,
        Jira,
        Lambda,
        VideoBin,
        Pomf,
        Uguu,
        Dropfile,
        Up1,
        Seafile,
        Sul,
        Streamable,
        SharedFolder,   //Localized
        Email,//Localized
        CustomFileUploader//Localized
           
    }
}
