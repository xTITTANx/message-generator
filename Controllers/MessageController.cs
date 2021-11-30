using MessageGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessageGenerator.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _repository;

        public MessageController(IMessageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Message> GetList()
        {
            return _repository.GetAll();
        }
    }
}
