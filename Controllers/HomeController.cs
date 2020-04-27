using JobPortal.Engine;
using JobPortal.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        AmakiriEntities2 db = new AmakiriEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveJ(string email,string jt,string jl,string jr,string jty,string jd,string cn,string cd,string cw)
        {
            JobPost jp = new JobPost();
            jp.CompanyDescription = jd;
            jp.CompanyEmail=email;
            jp.CompanyLogo="Logo";
            jp.CompanyName=cn;
            jp.CompanyWebsite=cw;
            jp.JobDescription=jd;
            jp.JobTitle=jt;
            jp.JobType=jty;
            jp.Location=jl;
            jp.Region=jr;
            db.JobPosts.Add(jp);
            var k = db.SaveChanges();

            if (k>0)
            {
                return Json(new { value = 1 });
            }

            return Json(new { value = 0});
        }
        public JsonResult SignUp(string email, string password, string phone)
        {

           // var check = db.Logins.Select(x => x.Email == email).SingleOrDefault();
            var check = db.Logins.Select(x => x.Email == email).FirstOrDefault();
            if (check)
            {
                return Json(new { value = 2 });
            }

            Login lg = new Login();

            lg.Email = email;
            lg.Password = password;
            lg.Phone = phone;
            db.Logins.Add(lg);
            var k= db.SaveChanges();
            if (k>0)
            {
               // EmailSender sendMail = new EmailSender("Dear Admin " + email + " Just sign up on portal","New Users",email );

               // sendMail.Shooter();
                return Json(new {value=1});
            }


            return Json(new {value=0});
        }

        [HttpPost]
        public JsonResult Login(string email,string password)
        {
            var LogMeIn = db.Logins.Select(h => h.Email == email && h.Password == password).FirstOrDefault();
            if (LogMeIn)
            {
                Session["mail"]=email;
                return Json(new { value = 1 });

            }

            return Json(new { value = 0 });
        }


        public JsonResult GetAll()
        {
            var jblist = db.JobPosts.ToList();
            var json = JsonConvert.SerializeObject(jblist);
             return Json(new {msg= json });
        }

        public JsonResult Search(string JobType, string SearchLocation)
        {
          //  var searchresult = db.JobPosts.Select();

            return Json(new { })
;
        }
        public ActionResult Login()
        {


            return View();
        }

        public ActionResult PostJob()
        {


            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}