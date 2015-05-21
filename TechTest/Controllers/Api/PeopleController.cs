using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TechTest.Repository;

namespace TechTest.Controllers.Api
{
    public class PeopleController : Controller
    {
        [HttpGet]
        [Route("api/people")]
        public JsonResult Get()
        {
            using (var db = new TechTestModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var people = (from p in db.People.Include(x => x.Colours)
                    select new
                    {
                        personId = p.PersonId,
                        firstName = p.FirstName,
                        lastName = p.LastName,
                        isAuthorised = (p.IsAuthorised) ? "Yes" : "No",
                        isEnabled = (p.IsEnabled) ? "Yes" : "No",
                        colours = p.Colours.Select(x => x.Name)
                    }).OrderBy(x=> x.firstName).ToList();

                return Json(people, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Route("api/people/{id}")]
        public JsonResult GetById(int id)
        {
            using (var db = new TechTestModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var people = (from p in db.People.Include(x => x.Colours)
                              where p.PersonId == id
                    select new
                    {
                        personId = p.PersonId,
                        firstName = p.FirstName,
                        lastName = p.LastName,
                        isAuthorised = p.IsAuthorised,
                        isEnabled = p.IsEnabled,
                        colours = p.Colours
                    }).SingleOrDefault();

                return Json(people, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        [Route("api/people")]
        public void Post(Person person)
        {
            using (var db = new TechTestModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // get the person record from database.
                var personToUpdate = (from p in db.People.Include(x=>x.Colours)
                    where p.PersonId == person.PersonId
                    select p).SingleOrDefault();

                // attach the person record and set the properties to updated properties.
                db.People.Attach(personToUpdate);
                personToUpdate.IsAuthorised = person.IsAuthorised;
                personToUpdate.IsEnabled = person.IsEnabled;

                // iterate through colours that have been removed and delete them.
                foreach (var colour in personToUpdate.Colours.ToList())
                {
                    if (!person.Colours.Select(x => x.ColourId).Contains(colour.ColourId))
                        personToUpdate.Colours.Remove(colour);
                }

                // iterate through new colours and add them.
                foreach (var newColour in person.Colours)
                {
                    if (personToUpdate.Colours.All(x => x.ColourId != newColour.ColourId))
                    {
                        var nc = new Colour {ColourId = newColour.ColourId};
                        db.Colours.Attach(nc);
                        personToUpdate.Colours.Add(nc);
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
