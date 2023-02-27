using Data.Model.Message;
using Microsoft.AspNetCore.Mvc;
using Service.Services.InterFaces;

namespace MessageProject.Controllers
{
    [ApiController]
    public class MessageController : ControllerBase
    {
        #region Constructor
        private readonly IMessageService MessageService;
        private readonly IChatService chatService;
        public MessageController(IMessageService messageService, IChatService chatService)
        {
            this.MessageService = messageService;
            this.chatService = chatService;
        }
        #endregion

        [HttpGet]
        [Route("/GetAllChats")]
        public IActionResult GetAllChats()
        {
            var chaats = chatService.GetChats();
            JsonResult resultt = new JsonResult(chaats);
            return resultt;
        }

        [HttpGet]
        [Route("/Chat/{id?}")]
        public IActionResult GetByChatId(Guid id)
        {
            var chaats = MessageService.GetByChatID(id);
            JsonResult resultt = new JsonResult(chaats);
            return resultt;
        }

        [HttpGet]
        [Route("/DeleteChat/{id?}")]
        public IActionResult DeleteChat(Guid id)
        {
            chatService.Delete(id);
            JsonResult resultt = new JsonResult(true);
            return resultt;

        }

        [HttpPost]
        [Route("/save")]
        public IActionResult Save([FromBody]MessageSaveModel model)
        {
            MessageService.Save(model);
            JsonResult resultt = new JsonResult(true);
            return resultt;
        }
        [HttpPost]
        [Route("/Forward")]
        public IActionResult Forward([FromBody] ForwardMessage model)
        {
            MessageService.Forward(model);
            JsonResult resultt = new JsonResult(true);
            return resultt;
        }
    }
}
