using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/region
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext,IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //GET ALL REGIONS 
        //GET: https://localhost:portnumber/api/regions

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain Models
            var regionsDomain = await regionRepository.GetAllRegionsAsync();

            //Map Domain Models to DTOs
            //var regionsDto = new List<RegionDTO>();
            //foreach (var region in regionsDomain)
            //{ 
            //    regionsDto.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}

            //using automapper domain models to DTO
            var regionsDto = mapper.Map<List<RegionDTO>>(regionsDomain);
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            //var region = dbContext.Regions.Find(id);
            //ini adalah cara lain untuk find biasanya digunakan untuk properti id yang memanggil Primary Keynya sedangkan firstordefault bisa digunakan di properti id serta properti lainnya

            //Get Region Domain Model From Database
            var regionsDomain = await regionRepository.GetByIdAsync(id);

            if (regionsDomain == null)
                {
                    return NotFound();
                }

            //var regionsDto = new RegionDTO
            //{
            //    Id = regionsDomain.Id,
            //    Name = regionsDomain.Name,
            //    Code = regionsDomain.Code,
            //    RegionImageUrl = regionsDomain.RegionImageUrl
            //};

            //using automapper
            var regionsDto = mapper.Map<RegionDTO>(regionsDomain);
            return Ok(regionsDto); 
        }

        //Post To Create New Region
        //Post: https://localhos:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            //Map or Convert DTO to Domain Model
            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDTO.Code,
            //    Name = addRegionRequestDTO.Name,
            //    RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            //};

            //using automapper
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);

            //Use Domain Model to create Region
            regionDomainModel =  await regionRepository.CreateAsync(regionDomainModel);

            //Map Domain Model back to DTO
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            //using automapper
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //Map DTO to Domain Model
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDTO.Code,
            //    Name = updateRegionRequestDTO.Name,
            //    RegionImageUrl = updateRegionRequestDTO.RegionImageUrl
            //};

            //using automapper
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);


            //Cek jika id tersedia
            regionDomainModel =  await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            { 
                return NotFound();
            }

            ////Map Dto to Domain model
            //regionDomainModel.Code = updateRegionRequestDTO.Code;
            //regionDomainModel.Name = updateRegionRequestDTO.Name;
            //regionDomainModel.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;

            //await dbContext.SaveChangesAsync();

            ////Convert Domain Model to DTO
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            //return Ok(regionDto);

            //using automapper
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
            
        }

        //Delete Region
        //DELETE: https://localhost:portnumber/api/regions{id}

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //delete regions
            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            ////return deleted Region back
            ////mapping Domain model to DTO
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            //using automapper
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));

        }


    }
}

