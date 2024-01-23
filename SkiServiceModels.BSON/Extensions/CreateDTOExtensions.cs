using SkiServiceModels.Attributes;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.BSON.Extensions
{
    public static class CreateDTOExtensions
    {
        public static Type GetModelType<TCreate>(this TCreate model)
            where TCreate : ICreateDTO
        {
            return model.GetType().GetCustomAttributes(false).OfType<ModelTypeAttribute>().FirstOrDefault()?.ModelType ?? typeof(TCreate);
        }
    }
}
