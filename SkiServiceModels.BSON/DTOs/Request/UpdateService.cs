using MongoDB.Bson;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
{
    public class UpdateService : IService
    {
        [AllowNull]
        public string Description { get; set; } = null;

        [AllowNull]
        public string Name { get; set; } = null;

        public int? Price { get; set; } = null;

        public bool? IsDeleted { get; set; } = null;

        // Implemented properties but with allowed null values

        int IServiceBase.Price {
            get => Price ?? 0;
            set => Price = value;
        }
        
        bool IModelBase.IsDeleted { 
            get => IsDeleted ?? false;
            set => IsDeleted = value;
        }

        // Hidden properties since they are not allowed to be updated

        ObjectId IModel.Id { get; set; }
    }
}
