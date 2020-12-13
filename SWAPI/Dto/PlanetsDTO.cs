using System;
using System.Collections.Generic;
using System.Text;

namespace AxaTests.Dto
{
    public partial class PlanetsDTO
    {
        public long Count { get; set; }
        public Uri Next { get; set; }
        public object Previous { get; set; }
        public PlanetResult[] Results { get; set; }
    }
    public partial class PlanetResult
    {
        public string Name { get; set; }
        public long RotationPeriod { get; set; }
        public long OrbitalPeriod { get; set; }
        public long Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        public Uri[] Residents { get; set; }
        public Uri[] Films { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Edited { get; set; }
        public Uri Url { get; set; }
    }
}
