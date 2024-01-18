using MongoDB.Bson;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
{
    public class UpdatePriorityRequest : IPriority, IRequestDTO
    {
        public int? Days { get; set; } = null;

        [AllowNull]
        public string Name { get; set; } = null;

        public bool? IsDeleted { get; set; } = null;

        // Implemented properties but with allowed null values

        bool IModelBase.IsDeleted
        {
            get => IsDeleted ?? false;
            set => IsDeleted = value;
        }

        int IPriorityBase.Days {
            get => Days ?? 0;
            set => Days = value; 
        }

        // Hidden properties since they are not allowed to be updated

        ObjectId IModel.Id { get; set; }
    }
}
