using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [ModelType(typeof(Order))]
    public class UpdateOrderRequest : UpdateRequest, IOrder
    {
        [JsonProperty("priority_id")]
        public string? PriorityId { get; set; } = null;

        [JsonProperty("service_id")]
        public string? ServiceId { get; set; } = null;

        [JsonProperty("state_id")]
        public string? StateId { get; set; } = null;

        [JsonProperty("user_id")]
        public string? UserId { get; set; } = null;

        ObjectId IOrder.PriorityId
        {
            get => ObjectId.Parse(PriorityId);
            set => PriorityId = value.ToString();
        }
        ObjectId IOrder.ServiceId
        {
            get => ObjectId.Parse(ServiceId);
            set => ServiceId = value.ToString();
        }
        ObjectId IOrder.StateId
        {
            get => ObjectId.Parse(StateId);
            set => StateId = value.ToString();
        }
        ObjectId? IOrder.UserId
        {
            get => ObjectId.Parse(UserId);
            set => UserId = value?.ToString();
        }

        [JsonProperty("email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }


        [JsonProperty("name")]
        public string? Name { get; set; } = null;

        [JsonProperty("note")]
        public string? Note { get; set; } = null;

        [JsonProperty("phone")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format")]
        public string? Phone { get; set; }

        // Implemented properties but with allowed null values

        string IOrderBase.Email
        {
            get => Email ?? string.Empty;
            set => Email = value;
        }

        string IOrderBase.Name
        {
            get => Name ?? string.Empty;
            set => Name = value;
        }

        string IOrderBase.Phone
        {
            get => Phone ?? string.Empty;
            set => Phone = value;
        }

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
