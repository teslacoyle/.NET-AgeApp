using AgeApp.Models.Access;
using AgeApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AgeApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UserAgeAccess access = new UserAgeAccess();
        public async Task<ActionResult> Index()
        {
            AgeViewModel avm = await access.GetAgeViewModel(User.Identity.Name);
            return View(avm);
        }
    }
}