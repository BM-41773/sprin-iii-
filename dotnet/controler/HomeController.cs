using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using facebookfinal.Models;
using System.Web.UI.WebControls;
using System.IO;

namespace facebookfinal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("Index");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(ModalClass mc, String cmd)
        {
            if (cmd == "Login")
            {
                string li = mc.login();
                if (li.Contains("Responsecode:200"))
                {
                    return View("Login2");
                }
                else
                {

                    return Content("<script language='JavaScript' type='text/JavaScript'>alert('" + li + "')</script>");
                }

            }
            if (cmd == "Create an account")
            {
                int presentyear = Convert.ToInt16(DateTime.Now.Year.ToString());
                int year = Convert.ToInt16(mc.X_Year);

                int age =presentyear-year;
                if (age >= 13)
                    {
                            FileUpload fld = new FileUpload();
                   
                   

                            String myprofpic = "E:\\propic1" + mc.X_propic;
                          fld.SaveAs(myprofpic);
                    
                           // int sz = fld.PostedFile.ContentLength;
                           int b = Convert.ToInt32(fld.FileContent.Length);
                           int kb = b / 1024;
                           int mb = kb / 1024;
                           int gb = mb / 1024;
                  
      

                        if (mb <= 5)
                
                    {


                        string ce = mc.Signup();
                       // return Content("<script language='JavaScript' type='text/JavaScript'>alert('" + ce + "')</script>");
                        return View("verify 1");
                    }
                    else
                    {
                        return null;
                    }

                }
              

               
            }


            return null;


        }


    }
}



