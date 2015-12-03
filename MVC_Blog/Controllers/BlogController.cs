using System;
using System.Web;
using System.Web.Mvc;
using RepoBlog.Factories;
using RepoBlog.Models.BaseModels;
using System.IO;

namespace MVC_Blog.Controllers
{
    public class BlogController : Controller
    {
        PostFac postFac = new PostFac();

        // GET: Blog
        public ActionResult Index()
        {
            return View(postFac.GetIndexData());
        }

        public ActionResult Delete(int id)
        {
            postFac.Delete(id);
            return View("index", postFac.GetIndexData());
        }



        public ActionResult Edit(int id)
        {
            return View(postFac.Get(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Post p)
        {
            p.Dato = DateTime.Now;

            if (ModelState.IsValid)
            {
                postFac.Update(p);
            }

            return View(postFac.Get(p.ID));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Post p)
        {
            p.Dato = DateTime.Now;

            if (ModelState.IsValid)
            {
                postFac.Insert(p);
                ViewBag.MSG = "Posten er oprettet!";
            }
            else
            {
                ViewBag.MSG = "Der opstod en fejl!";
            }

            return View();
        }


        public ActionResult Upload(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Upload(int id, HttpPostedFileBase fil)
        {
            if (fil != null)
            {
                Uploader u = new Uploader();
                string path = Request.PhysicalApplicationPath + "Content/Images/";
                string file = u.UploadImage(fil, path, 300, true);

                BilledFac bf = new BilledFac();
                Billede b = new Billede();
                b.Filnavn = Path.GetFileName(file);
                b.PostID = id;
                bf.Insert(b);

            }

            return View("Index", postFac.GetIndexData());
        }
    }
}