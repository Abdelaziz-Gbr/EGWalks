using AutoMapper;
using EGWalks.API.Data;
using EGWalks.API.Mappings;
using EGWalks.API.Models.Domain;
using EGWalks.API.Models.Dto;
using EGWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper) 
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            var regionsDomain = await regionRepository.GetAllAsync();

            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
                return NotFound();

            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDto addRegionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //convert addDto to data model
            var regionModel = mapper.Map<Region>(addRegionDto);

            //add to db
            regionModel = await regionRepository.AddRegionAsync(regionModel);

            return CreatedAtAction(
                //pass the location of the newly created resource.
                nameof(GetByID), new {regionModel.Id},
                //pass the newly created resource it self.
                mapper.Map<RegionDto>(regionModel));
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult >UpdateRegion([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDto updateRegionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var regionModel = await  regionRepository.UpdateRegionAsync(Id, mapper.Map<Region>(updateRegionDto));

            if(regionModel == null)
                return NotFound();

            return Ok(mapper.Map<RegionDto>(regionModel));
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid Id) { 
            var regionModel = await regionRepository.DeleteRegionAsync(Id);
            if (regionModel == null)
                return NotFound();
            return Ok(mapper.Map<RegionDto>(regionModel)); 
        }

    }
}
