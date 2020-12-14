using System;
using System.Collections.Generic;
using System.Text;

namespace AxaTests.Dto
{
    public partial class PeopleDTO
    {
        public long Count { get; set; }
        public Uri Next { get; set; }
        public object Previous { get; set; }
        public PeopleResult[] Results { get; set; }
    }
    public partial class PeopleResult
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public Uri Homeworld { get; set; }
        public Uri[] Films { get; set; }
        public Uri[] Species { get; set; }
        public Uri[] Vehicles { get; set; }
        public Uri[] Starships { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Edited { get; set; }
        public Uri Url { get; set; }

        
    }

    
}
