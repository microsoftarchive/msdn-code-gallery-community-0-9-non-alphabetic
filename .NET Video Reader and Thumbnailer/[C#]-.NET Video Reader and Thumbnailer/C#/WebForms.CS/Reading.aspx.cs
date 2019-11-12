using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Web.UI;
using GleamTech.AspNet;
using GleamTech.Examples;
using GleamTech.VideoUltimate;

namespace GleamTech.VideoUltimateExamples.WebForms.CS
{
    public partial class ReadingPage : Page
    {
        protected string TotalSeconds;
        protected string FrameDownloaderUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            var videoPath = exampleFileSelector.SelectedFile;
            var fileInfo = new FileInfo(videoPath);

            FrameDownloaderUrl = ExamplesConfiguration.GetDynamicDownloadUrl(
                FrameDownloaderHandlerName,
                new NameValueCollection
                {
                    {"videoPath", ExamplesConfiguration.ProtectString(videoPath)},
                    {"version", fileInfo.LastWriteTimeUtc.Ticks + "-" +  fileInfo.Length},
                    {"frameTime", "0"}
                });

            var duration = GetDuration(videoPath);
            TotalSeconds = ((int)duration.TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }

        public static TimeSpan GetDuration(string videoPath)
        {
            using (var videoFrameReader = new VideoFrameReader(videoPath))
            {
                return videoFrameReader.Duration;
            }
        }

        public static Bitmap GetFrame(string videoPath, double frameTime)
        {
            using (var videoFrameReader = new VideoFrameReader(videoPath))
            {
                if (frameTime > 0)
                    videoFrameReader.Seek(frameTime);

                //videoFrameReader.SetFrameWidth(300);

                if (videoFrameReader.Read())
                    return videoFrameReader.GetFrame();

                return GetErrorFrame(videoFrameReader.Width, videoFrameReader.Height, "Reading frame failed");
            }
        }

        public static Bitmap GetErrorFrame(int width, int height, string error)
        {
            var bitmap = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Black);

                graphics.DrawString(
                    error,
                    new Font(FontFamily.GenericSansSerif, 12), 
                    new SolidBrush(Color.White),
                    new RectangleF(0, 0, width, height),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
            }

            return bitmap;
        }

        public static void DownloadVideoFrame(IHttpContext context)
        {
            var videoPath = ExamplesConfiguration.UnprotectString(context.Request["videoPath"]);
            var frameTime = int.Parse(context.Request["frameTime"]);

            using (var bitmap = GetFrame(videoPath, frameTime))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;

                var fileResponse = new FileResponse(context);
                fileResponse.Transmit(
                    stream,
                    "frame.jpg",
                    File.GetLastWriteTimeUtc(videoPath),
                    stream.Length,
                    neverExpires: true);
            }
        }

        protected string FrameDownloaderHandlerName
        {
            get
            {
                if (frameDownloaderHandlerName == null)
                {
                    frameDownloaderHandlerName = "FrameDownloader";
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(frameDownloaderHandlerName, DownloadVideoFrame);
                }

                return frameDownloaderHandlerName;
            }
        }
        private static string frameDownloaderHandlerName;

        protected ResourceBundle PageCssBundle
        {
            get
            {
                if (pageCssBundle == null)
                {
                    pageCssBundle = new ResourceBundle("page.css")
                    {
                        Server.MapPath("~/resources/nouislider.min.css"),
                        Server.MapPath("~/resources/table.css")
                    };

                    ResourceManager.Register(pageCssBundle);
                }

                return pageCssBundle;
            }
        }
        private static ResourceBundle pageCssBundle;

        protected ResourceBundle PageJsBundle
        {
            get
            {
                if (pageJsBundle == null)
                {
                    pageJsBundle = new ResourceBundle("page.js")
                    {
                        Server.MapPath("~/resources/nouislider.min.js"),
                        Server.MapPath("~/resources/timeslider.js")
                    };

                    ResourceManager.Register(pageJsBundle);
                }

                return pageJsBundle;
            }
        }
        private static ResourceBundle pageJsBundle;
    }
}