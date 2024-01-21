using SkiServiceModels.Attributes;
using SkiServiceModels.EF.Interfaces.Base;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.EF.Models.Base
{
    public class Model : IModel
    {
        [Key]
        public int Id { get; set; }

        [AdminOnly]
        public bool IsDeleted { get; set; }
    }
}
