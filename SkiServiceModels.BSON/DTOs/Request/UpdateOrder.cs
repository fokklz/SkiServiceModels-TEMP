using MongoDB.Bson;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServiceModels.BSON.DTOs.Request
{
    public class UpdateOrder : IOrder
    {
        public string? PriorityId { get; set; } = null;

        public string? ServiceId { get; set; } = null;

        public string? StateId { get; set; } = null;

        public string? UserId { get; set; } = null;

        ObjectId IOrder.PriorityId { 
            get => ObjectId.Parse(PriorityId);
            set => PriorityId = value.ToString();
        }
        ObjectId IOrder.ServiceId { 
            get => ObjectId.Parse(ServiceId);
            set => ServiceId = value.ToString(); 
        }
        ObjectId IOrder.StateId { 
            get => ObjectId.Parse(StateId);
            set => StateId = value.ToString(); 
        }
        ObjectId? IOrder.UserId { 
            get => ObjectId.Parse(UserId);
            set => UserId = value?.ToString();
        }

        [AllowNull]
        public string Email { get; set; } = null;
        [AllowNull]
        public string Name { get; set; } = null;
        public string? Note { get; set; } = null;
        [AllowNull]
        public string Phone { get; set; } = null;

        // Implemented properties but with allowed null values

        bool IModelBase.IsDeleted { get; set; }

        // Hidden properties since they are not allowed to be updated

        DateTime IOrderBase.Created { get; set; }
        ObjectId IModel.Id { get; set; }



    }
}
