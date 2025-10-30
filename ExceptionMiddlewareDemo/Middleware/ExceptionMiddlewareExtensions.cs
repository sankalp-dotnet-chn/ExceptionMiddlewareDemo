namespace ExceptionMiddlewareAdvanced.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        //can be used to inject multiple different middlewares, we keep it here to keep program.cs clean
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

        }
    }

}
