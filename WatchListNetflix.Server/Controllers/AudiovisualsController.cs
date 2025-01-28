using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Audiovisuals;
using WatchListNetflix.Services.Audiovisuals.Models;

namespace WatchListNetflix.Server.Controllers
{
    [Route("api/audiovisuals")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IAudiovisualService _audiovisualService;
        private readonly IMapper _mapper;

        public MoviesController(IAudiovisualService audiovisualService, IMapper mapper)
        {
            _audiovisualService = audiovisualService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAudiovisuals()
        {
            var list = await _audiovisualService.GetAllAsync();
            var dtos = _mapper.Map<List<AudiovisualDto>>(list);
            return Ok(dtos);
        }

        [HttpGet("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _audiovisualService.GetMovies();
            var dtos = _mapper.Map<List<MovieDto>>(movies);
            return Ok(dtos);
        }

        [HttpGet("GetSeries")]
        public async Task<IActionResult> GetSeries()
        {
            var serie = await _audiovisualService.GetMovies();
            var dtos = _mapper.Map<List<SerieDto>>(serie);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var audiovisual = await _audiovisualService.GetById(id);

            if (audiovisual is null)
            {
                return NotFound($"The audiovisual with ID {id} does not exist.");
            }

            return Ok(audiovisual);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddAudiovisualDto newAudiovisualDto)
        {
            if (newAudiovisualDto == null)
            {
                return BadRequest("The audiovisual cannot be null");
            }

            Audiovisual audiovisual;

            if (newAudiovisualDto.AudiovisualType == nameof(audiovisual))
            {
                audiovisual = _mapper.Map<Movie>(newAudiovisualDto);
            }
            else if (newAudiovisualDto.AudiovisualType == nameof(Serie))
            {
                audiovisual = _mapper.Map<Serie>(newAudiovisualDto);
            }
            else
            {
                return BadRequest($"The {nameof(Audiovisual)} type is not valid. Type: {newAudiovisualDto.AudiovisualType}");
            }

            await _audiovisualService.CreateAsync(audiovisual);

            return CreatedAtAction(nameof(GetById), new { id = audiovisual.Id }, newAudiovisualDto);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAudiovisualDto updateAudiovisualDto)
        {
            if (id != updateAudiovisualDto.Id)
            {
                return BadRequest("The ID of the audiovisual does not match.");
            }

            var existingAudiovisual = await _audiovisualService.GetById(id);

            if (existingAudiovisual == null)
            {
                return NotFound($"The audiovisual with ID {id} does not exist.");
            }

            Audiovisual audiovisual;

            if (updateAudiovisualDto.AudiovisualType == nameof(Movie))
            {
                audiovisual = _mapper.Map<Movie>(updateAudiovisualDto);
            }
            else if (updateAudiovisualDto.AudiovisualType == nameof(Serie))
            {
                audiovisual = _mapper.Map<Serie>(updateAudiovisualDto);
            }
            else
            {
                return BadRequest($"The {nameof(Audiovisual)} type is not valid. Type: {updateAudiovisualDto.AudiovisualType}");
            }

            await _audiovisualService.UpdateAsync(audiovisual);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var audiovisual = await _audiovisualService.GetById(id);

            if (audiovisual is null)
            {
                return NotFound($"The audiovisual with ID {id} does not exist.");
            }

            await _audiovisualService.DeleteAsync(audiovisual);

            return NoContent();
        }
    }
}
