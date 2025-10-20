using System;

namespace SysproConnector.Infrastructure.Helpers
{
    internal static class ExceptionHelper
    {
        internal static string InnerExceptionToString(Exception exception) =>
            exception.InnerException != null ? InnerExceptionToString(exception.InnerException) : exception.Message;
    }
}
