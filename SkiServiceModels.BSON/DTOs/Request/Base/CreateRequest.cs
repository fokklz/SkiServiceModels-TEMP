﻿using MongoDB.Bson;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.BSON.DTOs.Request.Base
{
    public class CreateRequest : IModel, ICreateDTO
    {
        // Hidden properties since they are not allowed to be set when creating
        bool IModelBase.IsDeleted { get; set; }
        ObjectId IModel.Id { get; set; }
    }
}
