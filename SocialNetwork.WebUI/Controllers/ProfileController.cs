using System.Data;
using System.Linq;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private IRepository<Profile> repository;
        
        public ProfileController(IRepository<Profile> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            var profiles = from p in repository.Get() select p;
            return View(profiles);
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}