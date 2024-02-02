using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.BSON.Models;

namespace SkiServiceModels.BSON.Extensions
{
    public class MongoDBInitialization
    {
        private static bool _isInitialized = false;

        public static void RegisterMappings()
        {
            if (_isInitialized) return;

            RegisterMapping<IPriority, Priority>();
            RegisterMapping<IState, State>();
            RegisterMapping<IService, Service>();
            RegisterMapping<IUser, User>();
            RegisterMapping<IOrder, Order>();

            _isInitialized = true;
        }

        private static void RegisterMapping<TInterface, TConcrete>(bool root = false) where TConcrete : class, TInterface
        {
            BsonClassMap.RegisterClassMap<TConcrete>(cm =>
            {
                cm.AutoMap();
                if(root) cm.SetIsRootClass(true);
            });

            BsonSerializer.RegisterSerializer(typeof(TInterface), new ImpliedImplementationInterfaceSerializer<TInterface, TConcrete>());
        }
    }
}
