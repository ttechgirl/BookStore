using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.ServicesResponse
{
    public class ServiceResponse : IServiceResponse
    {
        protected List<ValidationResult> Results { get; set; } = new List<ValidationResult>();

        protected bool IsValid<T>(T entity)
        {
            return Validator.TryValidateObject(entity, new ValidationContext(entity, null, null),
              Results, false);
        }

        public string[] Errors
        {
            get
            {
                if (Results.Any())
                {
                    return Results.Select(e => e.ErrorMessage).ToArray();
                }
                return Array.Empty<string>();
            }
        }

        public bool HasError
        {
            get
            {
                if (Results.Any())
                {
                    return true;
                }
                return false;
            }
        }
    }
}
