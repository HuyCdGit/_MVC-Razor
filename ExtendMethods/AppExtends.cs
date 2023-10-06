using System.Net;
using Microsoft.AspNetCore.Builder;

namespace AppMVC.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePage(this WebApplication app)
        {
            app.UseStatusCodePages(appErr =>{
                appErr.Run(async Context =>{
                    var respone  = Context.Response;
                    var code = respone.StatusCode;
                    var content = @$"<html>
                        <head>
                            <meta charset = 'UTF-8'/>
                            <title>Error {code} </title> 
                        </head>
                        <body>
                            <p style='color:red; font-size: 30px'>
                                Error: {code} - {(HttpStatusCode)code}
                        </body>
                     </html>";
                     await respone.WriteAsync(content);
                });
            });
        }
    }
}