using System.Data;
using System.Linq;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.WebUI.Controllers
{
    public class FriendController : Controller
    {
        private IRepository<FriendEntity> friendRepository;
        public FriendController()
        {
            this.friendRepository = new Repository<FriendEntity>(new SocialNetworkContext());
        }

        public FriendController(IRepository<FriendEntity> friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        public ViewResult Index()
        {
            var friends = from p in friendRepository.Get() select p;

            return View(friends);
        }

        protected override void Dispose(bool disposing)
        {
            friendRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}