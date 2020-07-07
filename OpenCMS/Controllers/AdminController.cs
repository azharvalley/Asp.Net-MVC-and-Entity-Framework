using OpenCMS.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenCMS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllCMSPages()
        {
            DBCMSEntities dbContext = new DBCMSEntities();

            var allcmspages = dbContext.Database.SqlQuery<CMSPage>("FetchAllPages").ToList();

            return View(allcmspages);
        }

        public ActionResult Details(int Id)
        {
            DBCMSEntities dbContext = new DBCMSEntities();
            System.Data.Entity.Core.Objects.ObjectResult<FetchPageById_Result> pageDetails = dbContext.FetchPageById(Id);
            return View(pageDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CMSPage page)
        {
            DBCMSEntities dbContext = new DBCMSEntities();
            var Id = dbContext.AddPage(page.Id, page.Slug, page.PTitle, page.PKeyword, page.PDescription, page.PageContent, page.IsActive, page.IsDelete);

            Response.Redirect("/admin/details/" + Id);

            return View();
        }

        public ActionResult Edit(int Id)
        {
            CMSPage cmsPage = new CMSPage();
            if (Id != 0)
            {
                using (var context = new DBCMSEntities())
                {
                    var result = context.FetchPageInfoById(Id);
                    var targetList = result.Select(x => new CMSPage() { Id = x.Id, Slug = x.Slug, PTitle = x.PTitle, PKeyword = x.PKeyword, PDescription = x.PDescription, PageContent = x.PageContent, IsActive = x.IsActive, IsDelete = x.IsDelete, Create_On = x.Create_On, Modify_On = x.Modify_On }).ToList();
                    cmsPage = targetList.ToList().FirstOrDefault();
                    return View(cmsPage);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(CMSPage page)
        {
            DBCMSEntities dbContext = new DBCMSEntities();
            var Id = dbContext.UpdatePage(page.Id, page.Slug, page.PTitle, page.PKeyword, page.PDescription, page.PageContent, page.IsActive, page.IsDelete);
            return View();
        }

        public ActionResult AddUpdatePage(Int32? Id)
        {
            CMSPage cmsPage = new CMSPage();
            if (Id != null && Id != 0)
            {
                using (var context = new DBCMSEntities())
                {
                    var result = context.FetchPageInfoById(Id);
                    var targetList = result.Select(x => new CMSPage() { Id = x.Id, Slug = x.Slug, PTitle = x.PTitle, PKeyword = x.PKeyword, PDescription = x.PDescription, PageContent = x.PageContent, IsActive = x.IsActive, IsDelete = x.IsDelete, Create_On = x.Create_On, Modify_On = x.Modify_On }).ToList();
                    cmsPage = targetList.ToList().FirstOrDefault();
                    return View(cmsPage);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddUpdatePage(CMSPage page)
        {
            using (var context = new DBCMSEntities())
            {
                ObjectParameter result = new ObjectParameter("result", typeof(String));
                ObjectParameter createdId = new ObjectParameter("createdId", typeof(String));
                if (page.Id == 0)
                    context.InsertPage(page.Id, page.Slug, page.PTitle, page.PKeyword, page.PDescription, page.PageContent, page.IsActive, page.IsDelete, result, createdId);
                else
                    context.EditPage(page.Id, page.Slug, page.PTitle, page.PKeyword, page.PDescription, page.PageContent, page.IsActive, page.IsDelete, result);

                TempData["Result"] = createdId.Value == null ? result.Value : result.Value + " New Page Id is " + createdId.Value;

                if (page.Id == 0)
                {
                    return RedirectToAction("AddUpdatePage", new { Id = createdId.Value });
                }
            }
            ViewBag.Operation = page.Id == 0 ? "Add Page" : "Edit Page";




            return View();
        }

        public ActionResult Delete(int? Id)
        {
            DBCMSEntities dbContext = new DBCMSEntities();
            System.Data.Entity.Core.Objects.ObjectResult<FetchPageById_Result> pageDetails = dbContext.FetchPageById(Id);
            return View(pageDetails);
        }

        [HttpPost]
        public ActionResult Delete(long Id)
        {

            using (var context = new DBCMSEntities())
            {
                ObjectParameter result = new ObjectParameter("result", typeof(String));
                if(Id != 0)
                {
                    context.DeletePageById(Id, result);
                }
                

                if(result.Value.ToString() == "deleted")
                {
                    return RedirectToAction("AllCMSPages");
                }
                
            }

            return View();
        }
    }
}