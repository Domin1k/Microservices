using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFoodShop.Identity.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ControllerBase
    {
        public ActionResult<string> Index()
        {
            return "Hello";
        }
    }
}
