using System;
using System.Collections.Generic;
using System.Net;

namespace GameManagement.Domain
{
    public class ValidationError
    {
        public string ErrorMsg { get; set; }

        public string DataField { get; set; }
    }

    public class GameManagerException : Exception
    {
        public int Code { get; set; }

        public List<ValidationError> Errors { get; set; }

        public GameManagerException(string message, int code = (int) HttpStatusCode.InternalServerError)
           : base(message)
        {
            Code = code;
            Errors = null;
        }

        public GameManagerException(List<ValidationError> errors, int code = (int) HttpStatusCode.BadRequest)
           : base("Erro de Validação")
        {
            Code = code;
            Errors = errors;
        }
    }
}
