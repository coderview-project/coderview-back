using API.IServices;
using API.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BootcampController : ControllerBase
    {

        private readonly IBootcampService _bootcampService;
        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpPost(Name = "PostBootcamp")]
        public int PostBootcamp([FromBody]BootcampItem bootcampItem)
        {

            return _bootcampService.PostBootcamp(bootcampItem);
        }

        [HttpGet(Name = "GetAllBootcamp")]
        public List<BootcampItem> GetAllBootcamp()
        {
            return _bootcampService.GetAllBootcamp();
        }

        [HttpPatch(Name = "ModifyBootcamp")]
        public void Patch([FromBody] BootcampItem bootcampItem)
        {
            _bootcampService.UpdateBootcamp(bootcampItem);
        }

        [HttpDelete(Name = "DeactivatedBootcamp")]
        public void DeactivatedBootcamp([FromQuery] int id)
        {
            _bootcampService.DeactivatedBootcamp(id);
        }


    }
}
