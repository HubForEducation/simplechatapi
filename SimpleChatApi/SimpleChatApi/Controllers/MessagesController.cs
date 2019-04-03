using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleChatApi.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesContoller : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        [HttpGet("getmessages")]
        public ActionResult<string> Get2(int id)
        {
            return "value1234 " + id;
        }

        // POST api/values
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
