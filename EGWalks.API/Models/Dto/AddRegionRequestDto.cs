﻿namespace EGWalks.API.Models.Dto
{
    public class AddRegionRequestDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
