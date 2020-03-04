using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    public class ContentData
    {
        public int ContentDataId { get; set; }

        
        public Category Category { get; set; }
        public int CategoryId { get; set; }

           
        public string Title { get; set; }

        
        public string URLString { get; set; }
        public string Content { get; set; }
    }
}