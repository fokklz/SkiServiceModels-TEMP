using AutoMapper;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Request;
using SkiServiceModels.BSON.DTOs.Response;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.Interfaces;
using System.Reflection;

namespace SkiServiceModels.BSON.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Source, Destination>();

            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<UpdatePriorityRequest, Priority>();
            CreateMap<UpdateStateRequest, State>();
            CreateMap<UpdateServiceRequest, Service>();
            CreateMap<UpdateUserRequest, User>();

            SetupResponseMap<User, UserResponse>();
            SetupResponseMap<Order, OrderResponse>();
            SetupResponseMap<Priority, PriorityResponse>(); 
            SetupResponseMap<State, StateResponse>();
            SetupResponseMap<Service, ServiceResponse>();
        }

        public void SetupResponseMap<TSrc, TDest>()
        {
            CreateMap<TSrc, TDest>().ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember, context) =>
            {
                var destinationType = dest?.GetType();
                var sourceProperty = destinationType?.GetProperty(opts.DestinationMember.Name);

                var adminOnly = sourceProperty?.GetCustomAttribute<AdminOnlyAttribute>() != null;
                var ownerOrAdminOnly = sourceProperty?.GetCustomAttribute<OwnerOrAdminOnlyAttribute>() != null;

                if (context.TryGetItems(out var items))
                {
                    var isOwner = (bool)items.GetValueOrDefault("IsOwner", false);
                    var isAdmin = (bool)items.GetValueOrDefault("IsAdmin", false);

                    if (ownerOrAdminOnly)
                    {
                        return isOwner || isAdmin;
                    }
                    if (adminOnly)
                    {
                        return isAdmin;
                    }
                }

                if (adminOnly || ownerOrAdminOnly)
                    return false;

                return true;
            }));
        }
    }
}
