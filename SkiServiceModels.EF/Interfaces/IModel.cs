using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.EF.Interfaces
{
    public interface IModel : IModelBase
    {
        int Id { get; set; }
    }
}
