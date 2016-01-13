using System.Data;
using System.Linq;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private IRepository<MessageEntity> repository;
        
        public MessageController(IRepository<MessageEntity> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            var messages = from p in repository.Get() select p;

            return View(messages);
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}