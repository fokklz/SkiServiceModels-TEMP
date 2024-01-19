using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Request.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateOrderRequest : CreateRequest, IOrder
    {
        [JsonProperty("priority_id")]
        public required string PriorityId { get; set; }

        [JsonProperty("service_id")]
        public required string ServiceId { get; set; }

        [JsonProperty("state_id")]
        public required string StateId { get; set; }

        [JsonProperty("user_id")]
        public string? UserId { get; set; }

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

        [JsonProperty("email")]
        public required string Email { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("phone")]
        public required string Phone { get; set; }

        // Hidden properties since they are not allowed to be updated

        DateTime IOrderBase.Created { get; set; }

        IUser? IOrder.User { get; set; }
        [AllowNull]
        IState IOrder.State { get; set; }
        [AllowNull]
        IPriority IOrder.Priority { get; set; }
        [AllowNull]
        IService IOrder.Service { get; set; }
    }
}
