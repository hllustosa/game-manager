using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace GameManagement.Domain
{
    public class Friend
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("IdentityUser")]
        public string ApplicationUserId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Friend friend &&
                   Id == friend.Id &&
                   Name == friend.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public void Validate()
        {
            var errors = new List<ValidationError>();

            if (String.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidationError()
                {
                    DataField = "Name",
                    ErrorMsg = "Nome não pode ser vazio"
                });
            }

            if (errors.Count > 0)
            {
                throw new GameManagerException(errors);
            }
        }
    }
}
