using Api.Models.DTOs;
using Api.Services.EncoderHubService;
using Api.Services.EncoderService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncoderHubController : ControllerBase
    {
        private readonly IHubContext<EncoderHubService, IEncoderHubService> _hubContext;
        private readonly IEncoderService _encoderService;
        public EncoderHubController(IHubContext<EncoderHubService, IEncoderHubService> hubContext, IEncoderService encoderService)
        {
            _hubContext = hubContext;
            _encoderService = encoderService;
        }

        [HttpPost("EncodeText")]
        public async Task<IActionResult> Get([FromForm] EncoderHubDto model)
        {
            var rnd = new Random();
            int rndNumber = rnd.Next(1000, 5001);

            var task = Task.Run(async delegate
            {
                await Task.Delay(rndNumber);
                await _hubContext.Clients.All.SendEncodedTextAsync(await _encoderService.EncodeTextToBase64Async(model.Text));
            });
            
            task.Wait();

            return Ok("true");
        }
    }
}