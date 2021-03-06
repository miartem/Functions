using System;
using System.Collections.Generic;
using System.IO;
using ImageResizer;
using Microsoft.Azure.WebJobs;

namespace EXP.Functions.ImageResizerProcessor
{
    public static class ImageResizerProcessor
    {
        [FunctionName("ImageResizer")]
        public static void Run(
            [BlobTrigger("images/{name}", Connection = "IMAGE_BLOB_CONNECTION")]Stream image,
            [Blob("images-small/{name}", FileAccess.Write, Connection = "IMAGE_SMALL_BLOB_CONNECTION")]Stream imageSmall,
            [Blob("images-medium/{name}", FileAccess.Write, Connection = "IMAGE_MEDIUM_BLOB_CONNECTION")]Stream imageMedium)  // output blobs
        {
            var imageBuilder = ImageBuilder.Current;

            var size = imageDimensionsTable[ImageSize.Small];
            imageBuilder.Build(image, imageSmall, new ResizeSettings(size.Item1, size.Item2, FitMode.Max, null), false);

            image.Position = 0;

            size = imageDimensionsTable[ImageSize.Medium];
            imageBuilder.Build(image, imageMedium, new ResizeSettings(size.Item1, size.Item2, FitMode.Max, null), false);
        }

        public enum ImageSize
        {
            ExtraSmall, Small, Medium
        }

        private static Dictionary<ImageSize, Tuple<int, int>> imageDimensionsTable = new Dictionary<ImageSize, Tuple<int, int>>()
        {
            { ImageSize.ExtraSmall, Tuple.Create(320, 200) },
            { ImageSize.Small,      Tuple.Create(640, 400) },
            { ImageSize.Medium,     Tuple.Create(800, 600) }
        };
    }
}
