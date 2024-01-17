using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.Interfaces
{
    public interface IStateBase : IModelBase
    {
        string Name { get; set; }
    }
}