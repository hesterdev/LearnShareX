

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace ShareX.HelpersLib
{
    public class GitHubUpdateChecker : UpdateChecker
    {
        public string Owner { get; private set; }
        public string Repo { get; private set; }
        public bool IncludePreRelease { get; set; }

        private const string APIURL = "https://api.github.com";

        private string ReleasesURL
        {
            get
            {
                return string.Format("{0}/repos/{1}/{2}/releaases", APIURL, Owner, Repo);
            }
        }

        public GitHubUpdateChecker(string owner, string repo)
        {
            Owner = owner;
            Repo = repo;
        }

        public override void CheckUpdate()
        {
            try
            {
                List<GitHubRelease> releases = GetReleases();
                if (releases != null && releases.Count > 0)
                {
                    GitHubRelease latestRelease;
                    if (IncludePreRelease)
                    {
                        latestRelease = releases[0];
                    }
                    else
                    {
                        latestRelease = releases.FirstOrDefault(x => !x.prerelease);
                    }

                    if (latestRelease != null && !string.IsNullOrEmpty(latestRelease.tag_name) && latestRelease.tag_name.Length > 1 && latestRelease.tag_name[0] == 'v')
                    {
                        LatestVersion = new Version(latestRelease.tag_name.Substring(1));
                        if (latestRelease.assets != null && latestRelease.assets.Count > 0)
                        {
                            string extension;
                            if (IsPortable)
                            {
                                extension = "portable.zip";
                            }
                            else
                            {
                                extension = ".exe";
                            }
                            foreach (GitHubAsset asset in latestRelease.assets)
                            {
                                if (asset != null && !string.IsNullOrEmpty(asset.name) && asset.name.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    Filename = asset.name;
                                    if (IsPortable)
                                    {
                                        DownloadURL = asset.browser_download_url;
                                    }
                                    else
                                    {
                                        DownloadURL = asset.url;
                                    }
                                    RefreshStatus();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteException(ex, "Github update check failed");
            }
            Status = UpdateStatus.UpdateCheckFailed;
        }

        public string GetLatestDownloadUR()
        {
            List<GitHubRelease> releases = GetReleases();
            if (releases != null && releases.Count > 0)
            {
                return GetDownloadURL(releases[0]);
            }
            return null;
        }
        public string GetDownloadCounts()
        {
            StringBuilder sb = new StringBuilder();
            foreach (GitHubRelease release in GetReleases().Where(x => x.assets != null && x.assets.Count > 0))
            {
                sb.AppendFormat("{0} ({1}): {2}\r\n", release.name, DateTime.Parse(release.published_at), release.assets.Sum(x => x.download_count));
            }
            return sb.ToString().Trim();
        }
        private string GetDownloadURL(GitHubRelease release)
        {
            if (release.assets != null && release.assets.Count > 0)
            {
                GitHubAsset asset = release.assets[0];
                if (asset != null && !string.IsNullOrEmpty(asset.name))
                {
                    return string.Format("https://github.com/{0}/{1}/releases/download/{2}/{3}", Owner, Repo, release.tag_name, asset.name);
                }
            }
            return null;
        }

        private List<GitHubRelease> GetReleases()
        {
            using (WebClient wc = new WebClient())
            {
                wc.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                wc.Headers.Add("user_agent", "ShareX");
                wc.Proxy = Proxy;

                string response = wc.DownloadString(ReleasesURL);

                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<List<GitHubRelease>>(response);
                }
            }
            return null;
        }
    }





    public class GitHubRelease
    {
        public string url { get; set; }
        public string assets_url { get; set; }
        public string upload_url { get; set; }
        public string html_url { get; set; }
        public int id { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
        public string name { get; set; }
        public string body { get; set; }
        public bool draft { get; set; }
        public bool prerelease { get; set; }
        public string created_at { get; set; }
        public string published_at { get; set; }
        public List<GitHubAsset> assets { get; set; }
        public string tarball_url { get; set; }
        public string zipball_url { get; set; }
    }

    public class GitHubAsset
    {
        public string url { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public string content_type { get; set; }
        public string state { get; set; }
        public string size { get; set; }
        public int download_count { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string browser_download_url { get; set; }
    }

}