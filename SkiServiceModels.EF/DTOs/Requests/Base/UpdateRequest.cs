using Newtonsoft.Json;
using SkiServiceModels.EF.Interfaces.Base;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.EF.DTOs.Requests.Base
{
    public class UpdateRequest : IModel, IUpdateDTO
    {
        [JsonProperty("is_deleted")]
        public bool? IsDeleted { get; set; } = null;

        // Implemented properties but with allowed null values

        bool IModelBase.IsDeleted
        {
            get => IsDeleted ?? false;
            set => IsDeleted = value;
        }

        // Hidden properties since they are not allowed to be updated

        int IModel.Id { get; set; }
    }
}
