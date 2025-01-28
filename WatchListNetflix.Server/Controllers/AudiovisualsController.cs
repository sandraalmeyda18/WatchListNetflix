using Microsoft.AspNetCore.Mvc;
using WatchListNetflix.Services.Audiovisuals;

namespace WatchListNetflix.Server.Controllers
{
    [Route("api/audiovisuals")]
    [ApiController]
    public class AudiovisualsController : ControllerBase
    {
        private readonly IAudiovisualService _audiovisualService;

        public AudiovisualsController(IAudiovisualService audiovisualService)
        {
            _audiovisualService = audiovisualService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAudiovisuals()
        {
            var audiovisual = await _audiovisualService.GetAllAsync();
            return Ok(audiovisual);
        }
    }
}
