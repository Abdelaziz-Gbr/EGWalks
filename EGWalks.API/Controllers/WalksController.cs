using AutoMapper;
using EGWalks.API.Models.Domain;
using EGWalks.API.Models.Dto;
using EGWalks.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EGWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository repository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddWalk([FromBody]AddWalkRequestDto addWalkDto)
        {

            var walkDomain = mapper.Map<Walk>(addWalkDto);

            walkDomain = await repository.AddWalkAsync(walkDomain);

            var walkDto = mapper.Map<WalkDto>(walkDomain);
            return CreatedAtAction
                (
                // path of the created source.
                nameof(GetWalkById), new { walkDto.Id },
                // the created source.
                walkDto)
                ;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {
            var walks = await repository.GetAllWalksAsync();

            return Ok(mapper.Map<List<WalkDto>>(walks));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute]Guid Id)
        {
            var walk = await repository.GetWalkByIdAsync(Id);

            if(walk == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute]Guid Id, [FromBody]UpdateWalkDto updateWalkDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var walk = await repository.UpdateWalkAsync(Id, mapper.Map<Walk>(updateWalkDto));
            if(walk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute]Guid Id)
        {
            var walk = await repository.DeleteWalkAsync(Id);
            if(walk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walk));
        }
    }
}
