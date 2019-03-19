using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlashCardPOC.Controllers
{
    public class FlashCardController : Controller
    {
        // GET: FlashCard
        public ActionResult Index()
        {
            return View();
        }
    }       
}