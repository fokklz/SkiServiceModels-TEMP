using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Requests.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateOrderRequest : UpdateRequest, IOrder
    {
        [JsonProperty("priority_id")]
        public int? PriorityId { get; set; } = null;

        [JsonProperty("service_id")]
        public int? ServiceId { get; set; } = null;

        [JsonProperty("state_id")]
        public int? StateId { get; set; } = null;

        [JsonProperty("user_id")]
        public int? UserId { get; set; } = null;

        int IOrder.PriorityId
        {
            get => PriorityId ?? 0;
            set => PriorityId = value;
        }
        int IOrder.ServiceId
        {
            get => ServiceId ?? 0;
            set => ServiceId = value;
        }
        int IOrder.StateId
        {
            get => StateId ?? 0;
            set => StateId = value;
        }
        int? IOrder.UserId
        {
            get => UserId ?? 0;
            set => UserId = value;
        }

        [AllowNull]
        [JsonProperty("email")]
        public string Email { get; set; } = null;

        [AllowNull]
        [JsonProperty("name")]
        public string Name { get; set; } = null;

        [JsonProperty("note")]
        public string? Note { get; set; } = null;

        [AllowNull]
        [JsonProperty("phone")]
        public string Phone { get; set; } = null;

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
