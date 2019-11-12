using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.IO;
using DevRain.Data.Extracting;

namespace WebImageCrawler
{
    public partial class FrmDesktopView : Form
    {
        private CookieContainer cookieContainer = new CookieContainer();
        
        private double totalUrls = 0;
        private double totalImages = 0;

        private bool stop = false; // Should the application stop running?

        // The FiFo Queues
        Queue<string> urlQueue = new Queue<string>(); // holds all the URLs to crawl.
        Queue<string> imageQueue = new Queue<string>(); // holds all the images to process.

        // Main Threads
        Thread urlThread;
        Thread imgThread;

        string processingNow = "";

        #region BottomMost
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        #endregion

        public FrmDesktopView(string url)
        {
            InitializeComponent();
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE); // Set this form as BottomMost
            urlQueue.Enqueue(url);
            Start();
        }

        private void LblStopClick(object sender, EventArgs e)
        {
            while (urlThread.IsAlive || imgThread.IsAlive)
            {
                if (urlThread.IsAlive) urlThread.Abort();
                if (imgThread.IsAlive) imgThread.Abort();
               
            }
            Application.Exit();
        }

        private void TimerGuiTick(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE); // Set this form as BottomMost

            lblDomainQueue.Text = urlQueue.Count.ToString("N0");
            lblImagesQueue.Text = imageQueue.Count.ToString("N0");
            lblImages.Text = totalImages.ToString("N0");
            lblDomains.Text = totalUrls.ToString("N0");
            lblPRocessing.Text = processingNow;
        }

        // Start running the main threads!
        private void Start()
        {
            urlThread = new Thread(new ThreadStart(ProcessUrls));
            urlThread.IsBackground = true; // Let the GC handle this
            urlThread.Start();

            imgThread = new Thread(new ThreadStart(ProcessImages));
            imgThread.IsBackground = true; // Let the GC handle this
            imgThread.Start();

            
        }
  
       

        // download each file from the queue
        private void ProcessImages()
        {
            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Wic");

            while (!stop)
            {
                if (imageQueue.Count > 0)
                {
                    try
                    {
                        string url = imageQueue.Dequeue().ToString();
                        string fileName = url.Substring(url.LastIndexOf("/") + 1, (url.Length - url.LastIndexOf("/") - 1));
                        Uri uri = new Uri(url);
                        string domain = uri.Authority.ToString().Replace(".", "_");
                        WebClient client = new WebClient();
                        
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(ClientDownloadFileCompleted);
                        string folder = Path.Combine(downloadPath, domain);
                        fileName = GenerateFilename(Path.Combine(folder, fileName)); 

                        if (Directory.Exists(folder))
                        {
                            client.DownloadFileAsync(uri, Path.Combine(folder, fileName));
                            
                        }
                        else
                        {
                            Directory.CreateDirectory(folder);
                            client.DownloadFileAsync(uri, Path.Combine(folder, fileName));
                            totalUrls++;
                            
                        }

                    }
                    catch (Exception)
                    {
                        // Not really interested just now
                    }
                }
            }

            while (imgThread.ThreadState != ThreadState.Stopped)
            {
                imgThread.Abort(); // Keep aborting until successful

            }
        }

        void ClientDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            totalImages++;
            
        }

        private string GenerateFilename(string thispath)
        {
            int counter = 0;

            if (File.Exists(thispath))
            {
                string newfile = thispath;
                while (File.Exists(newfile))
                {
                    string fname = Path.GetFileNameWithoutExtension(thispath);
                    string ext = Path.GetExtension(thispath);

                    newfile = Path.Combine(Path.GetDirectoryName(thispath), fname + "_" + counter + ext);
                    counter++;
                }
               
                return newfile;
            }
            else
            {
                return thispath;
            }
        }

        private void CheckForDuplicate(string thispath, string newfile)
        {
            throw new NotImplementedException();
        }

        // Add first URL to the urlQueue - get all URLs from that Page that are not Images - and add them to the urlQueue Process this urlQueue
        // Add all image Urls to the imgQueue
        private void ProcessUrls()
        {
            while (!stop) // run this continuos loop until stopped
            {
                if (urlQueue.Count > 0)
                {
                    try
                    {
                        
                        string thisPage = urlQueue.Dequeue(); // Process the next url in the list
                        processingNow = thisPage;

                        CookieWebClient client = new CookieWebClient(cookieContainer);
                      
                        string html = client.DownloadString(thisPage);


                        // Get this web page's html
                        // GetImageUrls(html);
                        GetUrls(html);
                    }
                    catch (Exception)
                    {
                        // Ignore for just now
                    }

                }
            }

            while (urlThread.ThreadState != ThreadState.Stopped)
            {
                urlThread.Abort(); // Keep aborting until successful

            }
        }

        private void GetUrls(string html)
        {
            DataExtractor de = new DataExtractor(html, DataTypes.Url);
            foreach (ExtractedItemInfo eInfo in de.GetExtractedResults())
            {

                // required by some sites ..
                eInfo.Value = eInfo.Value.Trim(')');
                if (IsImage(eInfo.Value))
                {
                    imageQueue.Enqueue(eInfo.Value);

                }
                else
                {
                    urlQueue.Enqueue(eInfo.Value);

                }
            }
        }

        private bool IsImage(string p)
        {
            if (p.ToLower().EndsWith("jpg") || p.ToLower().EndsWith("png") || p.ToLower().EndsWith("gif"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
}
