using System;
using System.Collections.Generic;
using System.Text;

namespace GameManagement.Domain
{
    public class Model
    {
        public static void CheckModel(Object model)
        {
            if (model == null)
            {
                throw new GameManagerException(new List<ValidationError>() {
                    new ValidationError()
                    {
                         ErrorMsg = "Dados inválidos"
                    }
                });
            };
        }
    }
}
