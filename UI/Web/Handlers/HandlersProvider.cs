namespace UI.Web.Handlers
{
    public static class HandlersProvider
    {
        public static void RegisterHandlers(this WebApplication app)
        {
            app.RegisterTodoHandlers();
        }
    }
}