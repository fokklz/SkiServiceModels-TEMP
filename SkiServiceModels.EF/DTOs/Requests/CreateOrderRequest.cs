using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateOrderRequest : CreateRequest, IOrder
    {
        [JsonProperty("priority_id")]
        public int PriorityId { get; set; }

        [JsonProperty("service_id")]
        public int ServiceId { get; set; }

        [JsonProperty("state_id")]
        public int StateId { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

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
