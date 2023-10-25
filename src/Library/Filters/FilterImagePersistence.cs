using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class FilterImagePersistence : IFilter
    {
        private string filePath;
        public FilterImagePersistence(string filepath)
        {
            this.filePath = filepath;
        }
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,filePath);

            return image;
        }
    }
}