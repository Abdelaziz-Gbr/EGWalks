using EGWalks.API.Models.Dto;

namespace EGWalks.API.Models.Domain
{
    public class Region
    {
        public Guid Id{ get; set; }

        public string Code{ get; set; }

        public string Name{ get; set; }

        public string? RegionImageUrl{ get; set; }

        public static Region FromAddDto(AddRegionRequestDto addDto) =>
            new Region { 
                Code = addDto.Code, 
                Name = addDto.Name, 
                RegionImageUrl = 
                addDto.RegionImageUrl};

        internal void Update(Region updatedRegion)
        {
            Code = updatedRegion.Code;
            Name = updatedRegion.Name;
            RegionImageUrl = updatedRegion.RegionImageUrl;
        }
    }
}
