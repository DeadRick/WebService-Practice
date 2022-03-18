using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private Storage _storage;

        public MessageController(Storage storage)
        {
            _storage = storage;
        }

        [HttpPost("create-message")]
        public IActionResult SendMessage(SendMessageRequest req)
        {

            var message = new MessageInfo()
            {
                SenderId = req.SenderId,
                RecieverId = req.RecieverId,
                Message = req.Message,
                Timestamp = System.DateTime.Now
            };
            _storage.Messages.Add(message);
            if (!_storage.Users.Exists(x => x.Id == req.SenderId))
            {
                return NotFound($"Пользователь-получатель senderId = {req.SenderId} не найден");  
            }

            return Ok(message);

        }

        [HttpGet("get-messages-by-sender-and-reciever")]
        public IActionResult GetMessagesBySenderAndReciever(int senderId, int recieverId)
        {
            List<MessageInfo> messagesList = new();

            foreach (var message in _storage.Messages)
            {
                if (message.SenderId == senderId && message.RecieverId == recieverId)
                {
                    messagesList.Add(message);
                }
            }
            
            if (messagesList.Count == 0)
            {
                return NotFound();
            }
            return Ok(messagesList);
        }
    }
}
