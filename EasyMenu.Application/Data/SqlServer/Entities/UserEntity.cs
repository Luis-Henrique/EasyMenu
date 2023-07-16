using EasyMenu.Application.Contracts.Request.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyMenu.Application.Data.MySql.Entities
{
    [Table("user")]
    public class UserEntity
    {
        public UserEntity(UserPostRequest user)
        {
            this.Id = Guid.NewGuid();
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Password = user.Password;
            this.CreatedDate = DateTime.Now;
        }

        public UserEntity(UserPutRequest user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Password = user.NewPassword;
            this.UpdatedDate = DateTime.Now;
            this.CreatedDate = DateTime.ParseExact(user.CreatedDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public UserEntity(){}

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("userName")]
        [StringLength(50)]
        [Unicode(false)]
        public string UserName { get; set; }

        [Column("email")]
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; }

        [Column("password")]
        [StringLength(50)]
        [Unicode(false)]
        public string Password { get; set; }

        [Column("createdDate", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Column("updatedDate", TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
    }
}
