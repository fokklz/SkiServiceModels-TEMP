using MongoDB.Bson;
using Newtonsoft.Json;
using SkiServiceModels.BSON.DTOs.Responses.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Responses
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class OrderResponse : ModelResponse, IOrder, IResponseDTO
    {
        public UserResponse? User { get; set; }

        [AllowNull, NotNull]
        public ServiceResponse Service { get; set; }

        [AllowNull, NotNull]
        public StateResponse State { get; set; }

        [AllowNull, NotNull]
        public PriorityResponse Priority { get; set; }

        public DateTime Created { get; set; }

        [AllowNull, NotNull]
        public string Email { get; set; }
        [AllowNull, NotNull]
        public string Name { get; set; }
        public string? Note { get; set; }
        [AllowNull, NotNull]
        public string Phone { get; set; }

        IState IOrder.State
        {
            get => State;
            set => State = (value as StateResponse)!;
        }
        IPriority IOrder.Priority
        {
            get => Priority;
            set => Priority = (value as PriorityResponse)!;
        }
        IService IOrder.Service
        {
            get => Service;
            set => Service = (value as ServiceResponse)!;
        }
        IUser? IOrder.User
        {
            get => User;
            set => User = value as UserResponse;
        }

        ObjectId IOrder.PriorityId
        {
            get => ObjectId.Parse(Priority.Id);
            set => Priority.Id = value.ToString();
        }
        ObjectId IOrder.ServiceId
        {
            get => ObjectId.Parse(Service.Id);
            set => Service.Id = value.ToString();
        }
        ObjectId IOrder.StateId
        {
            get => ObjectId.Parse(State.Id);
            set => State.Id = value.ToString();
        }
        ObjectId? IOrder.UserId
        {
            get => User == null ? null : ObjectId.Parse(User.Id);
            set
            {
                if (User != null && value != null)
                    User.Id = value.ToString()!;
            }
        }

    }
}
