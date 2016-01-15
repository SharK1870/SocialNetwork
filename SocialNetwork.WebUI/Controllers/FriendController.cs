using System.Data;
using System.Linq;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.WebUI.Controllers
{
    public class FriendController : Controller
    {
        private IRepository<FriendEntity> friendRepository;
        
        public FriendController(IRepository<FriendEntity> friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        public ViewResult Index()
        {
            var friends = from p in friendRepository.GetAll() select p;

            return View(friends);
        }

        protected override void Dispose(bool disposing)
        {
            friendRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}