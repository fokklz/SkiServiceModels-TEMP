using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.EF.Models
{
    public class Order : Model, IOrder
    {
        // Foreign keys
        public int ServiceId { get; set; }
        public int PriorityId { get; set; }
        public int StateId { get; set; }
        public int? UserId { get; set; } = null;

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Service Service { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual State State { get; set; }

        public DateTime Created { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(1000)]
        public string? Note { get; set; }
    }
}
