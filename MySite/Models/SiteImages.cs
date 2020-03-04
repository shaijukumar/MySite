using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class SiteImages
    {
        public int SiteImagesId { get; set; }
        public int ContentDataId { get; set; }
        public string Image_url { get; set; }
        public string Name { get; set; }
    }
}