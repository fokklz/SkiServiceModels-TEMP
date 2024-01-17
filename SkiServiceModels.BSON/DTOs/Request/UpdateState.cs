using MongoDB.Bson;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
{
    public class UpdateState : IState
    {
        public bool? IsDeleted { get; set; } = null;

        [AllowNull]
        public string Name { get; set; } = null;

        // Implemented properties but with allowed null values

        bool IModelBase.IsDeleted {
            get => IsDeleted ?? false;
            set => IsDeleted = value;
        }

        // Hidden properties since they are not allowed to be updated

        ObjectId IModel.Id { get; set; }
    }
}
