using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCooking.Models;
using prjCooking.ViewModel;

namespace prjCooking.Controllers
{
    public class ManagerController : Controller
    {

        // GET: Manager
      
            public ActionResult List()
        {
            IEnumerable<t會員> datas = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
                datas = from p in (new dbCookingEntities()).t會員 select p;
            else
                datas = from p in (new dbCookingEntities()).t會員 where p.f會員姓名.Contains(keyword) select p;
            
            List<C管理者會員ViewModel> list = new List<C管理者會員ViewModel>();
            foreach (t會員 p in datas)
                list.Add(new C管理者會員ViewModel() { member = p });
            return View(list);

        }
        public ActionResult Details(int id)
        {
 
            dbCookingEntities db = new dbCookingEntities();
            t會員 member_select = db.t會員.FirstOrDefault(p => p.f會員Id == id);
            if (member_select == null)
                return RedirectToAction("List");

            return View(new C管理者會員ViewModel() { member = member_select });

        }
        public ActionResult Delete(int id)
        {
            dbCookingEntities db = new dbCookingEntities();
            t會員 member_select = db.t會員.FirstOrDefault(p => p.f會員Id == id);
            if (member_select != null)
            {
                db.t會員.Remove(member_select);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}