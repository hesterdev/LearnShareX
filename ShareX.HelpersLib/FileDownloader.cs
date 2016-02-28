using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace ShareX.HelpersLib
{
    class FileDownloader
    {
        public string URL { get; private set; }
        public bool IsDownloading { get; private set; }
        public bool IsCanceled { get; private set; }
        public long FileSize { get; private set; }
        public long DownloadedSize { get; private set; }
        public double DownloadSpeed { get; private set; }

        public double DownloadPercentage
        {
            get
            {
                if(FileSize>0)
                {
                    return (double)DownloadedSize / FileSize * 100;
                }
                return 0;
            }
        }

        public Exception LastException { get; private set; }
        public bool IsPaused { get; private set; }
        public IWebProxy Proxy { get; set; }
        public string AcceptHeader { get; set; }

        public event EventHandler FileSizeReceived;
        public event EventHandler DownloadStarted;
        public event EventHandler ProgressChanged;
        public event EventHandler DownloadCompleted;
        public event EventHandler ExceptionThrowed;

        private BackgroundWorker worker;
        private Stream stream;
        private const int bufferSize = 4096;

        public FileDownloader(string url,Stream stream,IWebProxy proxy=null,string acceptHeader= null)
        {
            URL = url;
            this.stream = stream;
            Proxy = proxy;
            AcceptHeader = acceptHeader;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += workd_RunWorkerCompleted;

        }

        private void workd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsDownloading = false;
        }

        public void StartDownload()
        {
            if(!IsDownloading&&!string.IsNullOrEmpty(URL)&& !worker.IsBusy)
            {
                IsDownloading = true;
                IsPaused = false;
                worker.RunWorkerAsync();
            }
        }

        public void ResumeDownload()
        {
            if (IsDownloading)
            {
                IsPaused = false;
            }
        }

        public void PauseDownload()
        {
            if (IsDownloading)
            {
                IsPaused = true;
            }
        }

        public void StopDownload()
        {
            if (IsDownloading)
            {
                IsCanceled = true;
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            EventHandler eventHandler = e.UserState as EventHandler;
            if(eventHandler!=null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.UserAgent = "ShareX";
                request.Proxy = Proxy;
                if (!string.IsNullOrEmpty(AcceptHeader))
                {
                    request.Accept = AcceptHeader;
                }
                response = (HttpWebResponse)request.GetResponse();
                FileSize = response.ContentLength;
                ThrowEvent(FileSizeReceived);

                if (FileSize > 0)
                {
                    Stopwatch timer = new Stopwatch();
                    Stopwatch progressEventTimer = new Stopwatch();
                    long speedTest = 0;

                    byte[] buffer = new byte[(int)Math.Min(bufferSize, FileSize)];
                    int bytesRead;

                    ThrowEvent(DownloadStarted);

                    while(DownloadedSize<FileSize && !worker.CancellationPending)
                    {
                        while(IsPaused && !IsCanceled)
                        {
                            timer.Reset();
                            Thread.Sleep(10);
                        }
                        if (IsCanceled)
                        {
                            return; 
                        }
                        if (!timer.IsRunning)
                        {
                            timer.Start();
                        }
                        if (!progressEventTimer.IsRunning)
                        {
                            progressEventTimer.Start();
                        }

                        bytesRead = response.GetResponseStream().Read(buffer, 0, buffer.Length);
                        stream.Write(buffer, 0, bytesRead);
                        DownloadedSize += bytesRead;
                        speedTest += bytesRead;

                        if (timer.ElapsedMilliseconds > 500)
                        {
                            DownloadSpeed = (double)speedTest / timer.ElapsedMilliseconds * 1000;
                            speedTest = 0;
                            timer.Reset();
                        }

                        if (progressEventTimer.ElapsedMilliseconds > 100)
                        {
                            ThrowEvent(ProgressChanged);
                            progressEventTimer.Reset();
                        }
                    }
                    ThrowEvent(ProgressChanged);
                    ThrowEvent(DownloadCompleted);
                }
            }catch(Exception ex)
            {
                if (!IsCanceled)
                {
                    LastException = ex;
                    ThrowEvent(ExceptionThrowed);
                }
            }
            finally
            {
                if (response != null) response.Close();
                if (stream != null) stream.Close();
            }
        }

        private void ThrowEvent(EventHandler eventHandler)
        {
            worker.ReportProgress(0, eventHandler);
        }
    }
}
