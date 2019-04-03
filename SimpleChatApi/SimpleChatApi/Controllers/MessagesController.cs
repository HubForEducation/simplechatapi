using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace SimpleChatApi.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesContoller : ControllerBase
    {
        [HttpGet]
        public SimpleChatApi.Messages[] Get()
        {
            using (MessagesContext db = new MessagesContext())
            {
                return db.messages.ToArray();
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
