using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.Interfaces.Base;

namespace SkiServiceModels.BSON.Extensions
{
    public static class ModelExtensions
    {
        public static Type GetUpdateType<TModel>(this TModel model)
            where TModel : IModel
        {
            return model.GetType().GetCustomAttributes(false).OfType<UpdateTypeAttribute>().FirstOrDefault()?.UpdateType ?? typeof(TModel);
        }

        public static Type GetCreateType<TModel>(this TModel model)
            where TModel : IModel
        {
            return model.GetType().GetCustomAttributes(false).OfType<CreateTypeAttribute>().FirstOrDefault()?.CreateType ?? typeof(TModel);
        }
    }
}
