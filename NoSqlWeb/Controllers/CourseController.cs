using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NoSqlWeb.Models;

namespace NoSqlWeb.Controllers
{
    public class CourseController : Controller 
    {
        //
        // GET: /Course/

        private const string ApiUrl = "http://localhost/NosqlSvc/api/course/";

        public ActionResult Index()
        {
            var client = new HttpClient();
            var response = client.GetAsync(ApiUrl).Result;
            var courses = response.Content.ReadAsAsync<IEnumerable<Course>>().Result;
            return View(courses);
        }

        

        ////
        //// GET: /Course/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        public async Task<ActionResult> Create(PostCourse course)
        {
            try
            {
                var client = new HttpClient();
                
                var response = await client.PostAsJsonAsync(ApiUrl, course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Course/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewAv(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync(ApiUrl+id).Result;
            var courses = response.Content.ReadAsAsync<Course>().Result;
            var avFiles = courses.Videos;
            return View(avFiles);
        }

        public ActionResult DownloadAv(string id, string fileType)
        {
            ViewBag.Id = id;
            ViewBag.AvType = fileType.Substring(0, fileType.IndexOf('/')) == "video" ? "video" : "image";
            return View();
        }

        public ActionResult GetAv(string id)
        {
            var client = new HttpClient();
            string url = string.Format(@"{0}/GetAv/?avId={1}&localFilePath=d:\\test", ApiUrl, id);
            var response = client.GetAsync(url).Result;
            var content = response.Content.ReadAsAsync<AvFile>().Result;
            //ViewBag.AvFilePath = localPath;
            return File(content.StreamByteArray, content.FileType);
        }

        public ActionResult UploadView(string id)
        {
            ViewBag.CourseId = id;
            return View();
        }

        [HttpPost]
        public ActionResult UploadView(string id, IEnumerable<HttpPostedFileBase> files)
        {
            var postedFiles = files as HttpPostedFileBase[] ?? files.ToArray();
            foreach (var file in postedFiles)
            {
                var byteArray = new BinaryReader(file.InputStream).ReadBytes(file.ContentLength);
                var url = string.Format("{0}?id={1}&filename={2}&contenttype={3}", ApiUrl, id, file.FileName,file.FileName.GetMimeType());
                //var filepath = file.FileName;
                HttpContent fileContent = new ByteArrayContent(byteArray);

                using (var client = new HttpClient())
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        formData.Add(fileContent, "file", "fileName");

                        //call service
                        var response = client.PostAsync(url, formData).Result;

                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception();
                        }


                    }


                }
                
            }
            

            return RedirectToAction("Index");
        }
    }
}
