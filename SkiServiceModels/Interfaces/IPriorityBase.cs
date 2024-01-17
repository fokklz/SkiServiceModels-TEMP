using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.Interfaces
{
    public interface IPriorityBase : IModelBase
    {
        int Days { get; set; }
        string Name { get; set; }
    }
}