using SkiServiceModels.Interfaces;

namespace SkiServiceModels.EF.Interfaces.Base
{
    public interface IModel : IModelBase
    {
        int Id { get; set; }
    }
}
