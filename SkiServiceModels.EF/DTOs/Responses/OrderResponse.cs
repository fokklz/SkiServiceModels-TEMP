using Newtonsoft.Json;
using SkiServiceModels.EF.DTOs.Responses.Base;
using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.EF.DTOs.Responses
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

        int IOrder.PriorityId
        {
            get => Priority.Id;
            set => Priority.Id = value;
        }
        int IOrder.ServiceId
        {
            get => Service.Id;
            set => Service.Id = value;
        }
        int IOrder.StateId
        {
            get => State.Id;
            set => State.Id = value;
        }
        int? IOrder.UserId
        {
            get => User == null ? null : User.Id;
            set
            {
                if (User != null && value != null)
                    User.Id = value ?? 0;
            }
        }

    }
}
