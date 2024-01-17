using SkiServiceModels.EF.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.EF.Models.Base
{
    public class Model : IModel
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
