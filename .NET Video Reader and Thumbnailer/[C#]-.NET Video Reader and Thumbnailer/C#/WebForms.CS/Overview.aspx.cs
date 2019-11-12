using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Web.UI;
using GleamTech.AspNet;
using GleamTech.Caching;
using GleamTech.Examples;
using GleamTech.IO;
using GleamTech.VideoUltimate;

namespace GleamTech.VideoUltimateExamples.WebForms.CS
{
    public partial class OverviewPage : Page
    {
        protected string ThumbnailUrl;
        protected VideoInfoModel VideoInfo;
        private static readonly ForwardSlashPath ThumbnailCachePath = "~/App_Data/ThumbnailCache";
        private static readonly FileCache ThumbnailCache = new FileCache(ThumbnailCachePath.ToString());

        private static void GetAndSaveThumbnail(string videoPath, Stream thumbnailStream)
        {
            using (var videoThumbnailer = new VideoThumbnailer(videoPath))
            using (var thumbnail = videoThumbnailer.GenerateThumbnail(300))
                thumbnail.Save(thumbnailStream, ImageFormat.Jpeg);
        }

        private static VideoInfoModel GetVideoInfo(string videoPath)
        {
            var model = new VideoInfoModel();

            using (var videoFrameReader = new VideoFrameReader(videoPath))
            {
                model.Properties.Add("Duration", videoFrameReader.Duration.ToString());
                model.Properties.Add("Width", videoFrameReader.Width.ToString());
                model.Properties.Add("Height", videoFrameReader.Height.ToString());
                model.Properties.Add("CodecName", videoFrameReader.CodecName);
                model.Properties.Add("CodecDescription", videoFrameReader.CodecDescription);
                model.Properties.Add("CodecTag", videoFrameReader.CodecTag);
                model.Properties.Add("BitRate", videoFrameReader.BitRate.ToString());
                model.Properties.Add("FrameRate", videoFrameReader.FrameRate.ToString(CultureInfo.InvariantCulture));

                foreach (var entry in videoFrameReader.Metadata)
                    model.Metadata.Add(entry.Key, entry.Value);

                if (model.Metadata.Count == 0)
                    model.Metadata.Add("", "");
            }

            return model;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var videoPath = exampleFileSelector.SelectedFile;
            var fileInfo = new FileInfo(videoPath);
            var thumbnailCacheKey = new FileCacheKey(new FileCacheSourceKey(fileInfo.Name, fileInfo.Length, fileInfo.LastWriteTimeUtc), "jpg");
            var cacheItem = ThumbnailCache.GetOrAdd(
                thumbnailCacheKey,
                thumbnailStream => GetAndSaveThumbnail(videoPath, thumbnailStream)
            );

            ThumbnailUrl = ExamplesConfiguration.GetDownloadUrl(
                Hosting.ResolvePhysicalPath(ThumbnailCachePath.Append(cacheItem.RelativeName)),
                thumbnailCacheKey.FullValue
            );

            VideoInfo = GetVideoInfo(videoPath);
        }
    }

    public class VideoInfoModel
    {
        public VideoInfoModel()
        {
            Properties = new Dictionary<string, string>();
            Metadata = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Properties { get; }

        public Dictionary<string, string> Metadata { get; }
    }
}