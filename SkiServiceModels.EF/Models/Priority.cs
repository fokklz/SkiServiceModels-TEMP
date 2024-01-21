using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.EF.Models
{
    public class Priority : Model, IPriority
    {
        public int Days { get; set; }

        [StringLength(20)]
        public required string Name { get; set; }
    }
}
