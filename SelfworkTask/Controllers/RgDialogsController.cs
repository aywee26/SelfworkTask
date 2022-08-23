using Microsoft.AspNetCore.Mvc;
using SelfworkTask.Library.Services;

namespace SelfworkTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RgDialogsController : ControllerBase
    {
        private readonly IDialogSearchService _dialogSearchservice;

        public RgDialogsController(IDialogSearchService dialogSearchservice)
        {
            _dialogSearchservice = dialogSearchservice;
        }

        [HttpGet("dialog")]
        public Guid Dialog([FromQuery]List<Guid> clients)
        {
            return _dialogSearchservice.SearchDialog(clients);
        }
    }
}
