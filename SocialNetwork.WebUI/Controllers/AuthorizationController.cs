using System.Data;
using System.Linq;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.WebUI.Controllers
{
    public class AuthorizationController : Controller
    {
        private IRepository<Authorization> authRepository;
       
        public AuthorizationController(IRepository<Authorization> authRepository)
        {
            this.authRepository = authRepository;
        }

        public ViewResult Index()
        {
            var auth = from p in authRepository.Get() select p;
            return View(auth);
        }

        protected override void Dispose(bool disposing)
        {
            authRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}