using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Requests.Base;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.BSON.Extensions
{
    public static class UpdateDTOExtensions
    {
        public static Type GetUpdateModelType<TUpdate>(this TUpdate model)
            where TUpdate : UpdateRequest
        {
            return model.GetType().GetCustomAttributes(false).OfType<ModelTypeAttribute>().FirstOrDefault()?.ModelType ?? typeof(TUpdate);
        }
    }
}
