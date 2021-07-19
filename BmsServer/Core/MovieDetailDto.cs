using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmsServer.Core
{
    public class MovieDetailDto
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public string MovieQuality { get; set; }

        public string Length { get; set; }

        public string ImageLink { get; set; }

        public string MovieAgeRestriction { get; set; }

        public string MovieLanguage { get; set; }

        public DateTime? DateOfRelease { get; set; }

        public decimal? RentPrice { get; set; }

        public decimal? BuyPrice { get; set; }

        public string About { get; set; }

        public string TrailerLink { get; set; }

        public string MovieCategory { get; set; }

        public int? CastId { get; set; }

        public int? CrewId { get; set; }

    }
}
