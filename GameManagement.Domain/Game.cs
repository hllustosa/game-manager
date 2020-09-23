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

        public MediaType MediaType { get; set; }

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


            if (errors.Count > 0 )
            {
                throw new GameManagerException(errors);
            }
        }

    }
}
