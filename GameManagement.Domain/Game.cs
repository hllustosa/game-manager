using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace GameManagement.Domain
{
    public enum MediaType
    {
        Cartridge,
        CD,
        DVD,
        BLURAY
    }

    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string PlataformName { get; set; }

        public long MediaType { get; set; }

        public bool IsLent { get; set; }

        public void Validate()
        {
            var errors = new List<ValidationError>();

            if(String.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidationError()
                {
                    DataField = "Name",
                    ErrorMsg = "Nome não pode ser vazio"
                });
            }

            if (String.IsNullOrEmpty(PlataformName))
            {
                errors.Add(new ValidationError()
                {
                    DataField = "PlataformName",
                    ErrorMsg = "Plataforma não pode ser vazio"
                });
            }

            if (Name.Length > 120)
            {
                errors.Add(new ValidationError()
                {
                    DataField = "Name",
                    ErrorMsg = "Nome não pode ter mais de 120 caracteres"
                });
            }

            if (PlataformName.Length > 120)
            {
                errors.Add(new ValidationError()
                {
                    DataField = "PlataformName",
                    ErrorMsg = "Plataforma não pode ter mais de 120 caracteres"
                });
            }

            if(MediaType < 0 || MediaType > 3)
            {
                errors.Add(new ValidationError()
                {
                    DataField = "MediaType",
                    ErrorMsg = "MediaType é inválido"
                });
            }

            if (errors.Count > 0 )
            {
                throw new GameManagerException(errors);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Game game &&
                   Id == game.Id &&
                   Name == game.Name &&
                   PlataformName == game.PlataformName &&
                   MediaType == game.MediaType &&
                   IsLent == game.IsLent;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, PlataformName, MediaType, IsLent);
        }
    }
}
