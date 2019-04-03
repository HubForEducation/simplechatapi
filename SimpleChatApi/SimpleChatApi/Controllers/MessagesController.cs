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
        public SimpleChatApi.Messages[] Get(int id, string autor, string body)
        {
            using (MessagesContext db = new MessagesContext())
            {
                var returnvalue = db.messages.ToArray();

                if (id != 0)
                {
                    returnvalue = db.messages.Where(i => i.id == id).ToArray();
                }

                if (autor != null)
                {
                    returnvalue = db.messages.Where(i => i.autor == autor).ToArray();
                }

                if (body != null)
                {
                    returnvalue = db.messages.Where(i => i.body == body).ToArray();
                }

                return returnvalue;
            }
        }

        [HttpPost]
        public string Post(int id, string autor, string body)
        {
            try
            {
                using (MessagesContext db = new MessagesContext())
                {
                    Messages message = new Messages() { id = id, autor = autor, body = body };

                    db.messages.Add(message);
                    db.SaveChanges();
                }

                return "OK!";
            }
            catch (DbUpdateException)
            {
                return "All fields must be filled.";
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
