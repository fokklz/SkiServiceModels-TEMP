﻿using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Request.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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
