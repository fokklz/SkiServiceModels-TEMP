using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        [AllowNull, NotNull]
        public virtual Service Service { get; set; }
        [AllowNull, NotNull]
        public virtual Priority Priority { get; set; }
        [AllowNull, NotNull]
        public virtual State State { get; set; }

        public DateTime Created { get; set; }

        [StringLength(50)]
        [AllowNull, NotNull]
        public string Email { get; set; }

        [StringLength(50)]
        [AllowNull, NotNull]
        public string Name { get; set; }

        [StringLength(50)]
        [AllowNull, NotNull]
        public string Phone { get; set; }

        [StringLength(1000)]
        public string? Note { get; set; }

        IUser? IOrder.User { get => User; set => User = value as User; }
        IService IOrder.Service { get => Service; set => Service = (value as Service)!; }
        IPriority IOrder.Priority { get => Priority; set => Priority = (value as Priority)!; }
        IState IOrder.State { get => State; set => State = (value as State)!; }
    }
}
