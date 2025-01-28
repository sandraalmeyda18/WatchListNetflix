using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Audiovisuals;
using WatchListNetflix.Services.Watchlists;
using WatchListNetflix.Services.Watchlists.Models;

namespace WatchListNetflix.Server.Controllers
{
    [Route("api/Watctchlist")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IWatchlistService _watchlistService;
        private readonly IAudiovisualService _audiovisualService;
        private readonly IMapper _mapper;

        public WatchlistController(IWatchlistService watchlistService, IAudiovisualService audiovisualService, IMapper mapper)
        {
            _watchlistService = watchlistService;
            _audiovisualService = audiovisualService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var watchlists = await _watchlistService.GetAllAsync();

            var dtoList = _mapper.Map<List<WatchlistDto>>(watchlists);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var watchlist = await _watchlistService.GetById(id);

            if (watchlist is null)
            {
                return NotFound($"The watchlist with ID {id} does not exist.");
            }

            return Ok(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWatchlistDto newWatchListDto)
        {
            if (newWatchListDto == null)
            {
                return BadRequest("The watchlist cannot be null");
            }

            var watchlist = _mapper.Map<Watchlist>(newWatchListDto);
            await _watchlistService.CreateAsync(watchlist);

            return CreatedAtAction(nameof(GetById), new { id = watchlist.Id }, newWatchListDto);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateWatchListDto updateWatchlistDto)
        {
            if (id != updateWatchlistDto.Id)
            {
                return BadRequest("The ID of the watchlist does not match.");
            }

            var existingWatchlist = await _watchlistService.GetById(id);

            if (existingWatchlist == null)
            {
                return NotFound($"The watchlist with ID {id} does not exist.");
            }

            var watchlist = _mapper.Map<Watchlist>(updateWatchlistDto);

            await _watchlistService.UpdateAsync(watchlist);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var watchlist = await _watchlistService.GetById(id);

            if (watchlist is null)
            {
                return NotFound($"The watchlist with ID {id} does not exist.");
            }

            await _watchlistService.DeleteAsync(watchlist);

            return NoContent();
        }

        [HttpPost("{id}/add-audiovisual")]
        public async Task<IActionResult> AddAudiovisual(int id, [FromBody] List<int> audiovisualIds)
        {
            if (audiovisualIds == null || !audiovisualIds.Any())
            {
                return BadRequest("The list of audiovisuals cannot be empty");
            }

            var watchlist = await _watchlistService.GetById(id);

            if (watchlist is null)
            {
                return NotFound($"The watchlist with ID {id} does not exist.");
            }

            await _watchlistService.InsertAudiovisual(id, audiovisualIds);
            return NoContent();
        }

        [HttpDelete("{id}/remove-audiovisuals")]
        public async Task<IActionResult> RemoveAudiovisuals(int id, [FromBody] List<int> audiovisualIds)
        {
            if (audiovisualIds == null || !audiovisualIds.Any())
            {
                return BadRequest("The list of audiovisuals cannot be empty");
            }

            var watchlist = await _watchlistService.GetById(id);

            if (watchlist is null)
            {
                return NotFound($"The watchlist with ID {id} does not exist.");
            }

            await _watchlistService.RemoveAudiovisual(id, audiovisualIds);
            return NoContent();
        }
    }
}
