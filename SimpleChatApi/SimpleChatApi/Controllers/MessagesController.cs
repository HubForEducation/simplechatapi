using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SimpleChatApi.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesContoller : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        [HttpGet("getall")]
        public ActionResult<string> GetAll()
        {
            using (MessagesContext db = new MessagesContext())
            {
                return null;
            }

        }
        [HttpPost]
        public void Post(int id, string autor, string body)
        {
            using (MessagesContext db = new MessagesContext())
            {
                // создаем два объекта User
                Messages message = new Messages() { id = id, autor = autor, body = body};

                db.messages.Add(message);
                db.SaveChanges();
            }
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
