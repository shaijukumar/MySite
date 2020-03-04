using MySite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace MySite.Controllers.API
{
    public class EditController : ApiController
    {
        [HttpGet]
        [Route("api/Test")]
        public string Test()
        {
            return "Success - 123";
        }

        [HttpPost]
        [Route("api/CreateContent")]       
        public APIActionResult CreateContent()
        {
            #region Parms



            //get CategoryId
            int contentDataId = -1;
            try
            {
                if (!Int32.TryParse(HttpContext.Current.Request.Form["ContentDataId"].ToString(), out contentDataId))
                {
                    contentDataId = -1;
                }
            }
            catch (Exception ex) { }


            //get CategoryId
            int categoryId;
            if (!Int32.TryParse(HttpContext.Current.Request.Form["CategoryId"].ToString(), out categoryId))
            {
                return ReturnResult("nvalid parameter CategoryId", false, -1);
            }

            //get Title
            string title = HttpContext.Current.Request.Form["Title"].ToString();
            if (string.IsNullOrEmpty(title))
            {
                return ReturnResult("invalid parameter Title", false, -1);
            }

            //get Title
            string urlString = HttpContext.Current.Request.Form["URLString"].ToString();
            if (string.IsNullOrEmpty(urlString))
            {
                return ReturnResult("invalid parameter URLString", false, -1);
            }


            string content = HttpContext.Current.Request.Form["Content"].ToString();

            StringWriter myWriter = new StringWriter();
            HttpUtility.HtmlDecode(content, myWriter);
            content = myWriter.ToString();

            #endregion Parms

            using (var db = new ApplicationDbContext())
                {
                if (contentDataId == -1)
                {
                    ContentData cd = new ContentData
                    {
                        CategoryId = categoryId,
                        Title = title,
                        URLString = urlString,
                        Content = content,
                    };

                    db.ContentDatas.Add(cd);
                    db.SaveChanges();
                    return ReturnResult("Created", true, cd.ContentDataId);
                }
                else
                {
                    var caQuery = db.ContentDatas.Where(x => x.ContentDataId == contentDataId);
                    if (!caQuery.Any())
                    {
                        return ReturnResult("Invalid data", false, -1);
                    }

                    ContentData cd = caQuery.Single();
                    cd.CategoryId = categoryId;
                    cd.Title = title;
                    cd.URLString = urlString;
                    cd.Content = content;
                    db.SaveChanges();
                    return ReturnResult("Updated", true, cd.ContentDataId);
                }
            }
        }

        public APIActionResult ReturnResult(string Message, bool Success, int ItemID)
        {
            APIActionResult res = new APIActionResult
            {
                Message = Message,
                ItemID = ItemID,
                Success = Success
            };

            return res;
        }
    }

    public class APIActionResult
    {
        public int ItemID { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}