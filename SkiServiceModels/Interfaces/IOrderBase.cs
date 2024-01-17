using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.Interfaces
{
    public interface IOrderBase : IModelBase
    {
        DateTime Created { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string? Note { get; set; }
        string Phone { get; set; }
    }
}