using System;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Api.Model.Compartilhado.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CopaFilmes.Api.Filters
{
    public class FluentValidationFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

                var erroResponse = new ErroResponse("Request inválida", errors);

                context.Result = new JsonResult(erroResponse)
                {
                    StatusCode = 400
                };
            }

            await next();
        }
    }
}
