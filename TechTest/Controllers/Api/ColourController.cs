using System.Linq;
using System.Web.Mvc;
using TechTest.Repository;

namespace TechTest.Controllers.Api
{
    public class ColourController : Controller
    {
        [HttpGet]
        [Route("api/colour")]
        public JsonResult Get()
        {
            using (var db = new TechTestModel())
            {
                db.Configuration.ProxyCreationEnabled = false;

                var colours = (from c in db.Colours
                    select c).ToList();

                return Json(colours, JsonRequestBehavior.AllowGet);
            }
        }
    }
}