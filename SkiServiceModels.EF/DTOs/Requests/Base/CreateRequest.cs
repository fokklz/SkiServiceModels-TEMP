using SkiServiceModels.EF.Interfaces.Base;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.EF.DTOs.Requests.Base
{
    public class CreateRequest : IModel, ICreateDTO
    {
        // Hidden properties since they are not allowed to be set when creating
        bool IModelBase.IsDeleted { get; set; }
        int IModel.Id { get; set; }
    }
}
