using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.EF.Models
{
    public class Service : Model, IService
    {
        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Price { get; set; }
    }
}
