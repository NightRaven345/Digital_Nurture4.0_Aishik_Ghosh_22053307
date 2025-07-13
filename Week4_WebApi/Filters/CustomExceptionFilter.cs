using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace MyWebApiApp.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            string message = $"\nTime: {DateTime.Now}, Controller: {controllerName}, Action: {actionName}, Exception: {context.Exception.Message}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");

            var directoryPath = Path.GetDirectoryName(filePath);
            if (directoryPath != null)
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.AppendAllText(filePath, message);

            context.Result = new ObjectResult("An unexpected error occurred. Please try again later.")
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}


