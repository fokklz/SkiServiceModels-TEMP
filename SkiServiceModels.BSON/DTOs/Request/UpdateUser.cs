using MongoDB.Bson;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Enums;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Base;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Request
{
    public class UpdateUser : IUser
    {
        public RoleNames? Role { get; set; } = null;

        [AllowNull]
        public string Username { get; set; } = null;

        public bool? Locked { get; set; } = null;

        public bool? IsDeleted { get; set; } = null;

        // Implemented properties but with allowed null values

        bool IUserBase.Locked {
            get => Locked ?? false; 
            set => Locked = value; 
        }

        bool IModelBase.IsDeleted { 
            get => IsDeleted ?? false;
            set => IsDeleted = value; 
        }

        RoleNames IUserBase.Role { 
            get => Role ?? RoleNames.User;
            set => Role = value;
        }

        // Hidden properties since they are not allowed to be updated

        int IUserBase.LoginAttempts { get; set; }
        string? IUserBase.RefreshToken { get; set; }
        [AllowNull]
        byte[] IUserBase.PasswordHash { get; set; }
        [AllowNull]
        byte[] IUserBase.PasswordSalt { get; set; }
        ObjectId IModel.Id { get; set; }
    }
}
