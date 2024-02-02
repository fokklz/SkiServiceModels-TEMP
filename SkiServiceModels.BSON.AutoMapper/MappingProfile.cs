using AutoMapper;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Options;
using System.Diagnostics;
using System.Reflection;

namespace SkiServiceModels.BSON.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Source, Destination>();

            CreateAdminMap<UpdateOrderRequest, Order>();
            CreateAdminMap<UpdatePriorityRequest, Priority>();
            CreateAdminMap<UpdateStateRequest, State>();
            CreateAdminMap<UpdateServiceRequest, Service>();
            CreateAdminMap<UpdateUserRequest, User>();

            CreateAdminMap<CreateOrderRequest, Order>();
            CreateAdminMap<CreatePriorityRequest, Priority>();
            CreateAdminMap<CreateStateRequest, State>();
            CreateAdminMap<CreateServiceRequest, Service>();
            CreateAdminMap<CreateUserRequest, User>();

            CreateAdminMap<User, UserResponse>(true);
            CreateAdminMap<Order, OrderResponse>(true);
            CreateAdminMap<Priority, PriorityResponse>(true);
            CreateAdminMap<State, StateResponse>(true);
            CreateAdminMap<Service, ServiceResponse>(true);
        }

        public void CreateAdminMap<TSrc, TDest>(bool source = false)
        {
            CreateMap<TSrc, TDest>().ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember, context) =>
            {
                DTOParseOptions dtoOptions;

                var targetType = source ? src?.GetType() : dest?.GetType();
                var targetProperty = targetType?.GetProperty(opts.DestinationMember.Name);

                // parse automapper context options to our internal options class
                if (context.TryGetItems(out var items))
                {
                    var isOwner = (bool)items.GetValueOrDefault("IsOwner", false);
                    var isAdmin = (bool)items.GetValueOrDefault("IsAdmin", false);

                    dtoOptions = new DTOParseOptions
                    {
                        IsAdmin = isAdmin,
                        IsOwner = isOwner
                    };
                }
                else
                {
                    dtoOptions = new DTOParseOptions();
                }

                return ModelUtils.IsAllowed(targetProperty, dtoOptions) && srcMember != null;
            }));

        }
    }
}
