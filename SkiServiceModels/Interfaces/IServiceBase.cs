using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.Interfaces
{
    public interface IServiceBase : IModelBase
    {
        string Description { get; set; }
        string Name { get; set; }
        int Price { get; set; }
    }
}