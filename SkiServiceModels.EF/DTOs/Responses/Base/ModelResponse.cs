using SkiServiceModels.Attributes;
using SkiServiceModels.EF.Interfaces.Base;
using SkiServiceModels.Interfaces;

namespace SkiServiceModels.EF.DTOs.Responses.Base
{
    public abstract class ModelResponse : IModel
    {
        public int Id { get; set; }

        [AdminOnly]
        public bool? IsDeleted { get; set; } = null;

        bool IModelBase.IsDeleted
        {
            get => IsDeleted ?? false;
            set => IsDeleted = value;
        }
    }
}
