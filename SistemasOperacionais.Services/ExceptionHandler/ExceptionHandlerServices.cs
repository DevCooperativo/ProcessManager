namespace SistemasOperacionais.Services;

public class ExceptionHandlerServices : Exception
{
    public ExceptionHandlerServices(string message) : base(message)
    {
    }

    public ExceptionHandlerServices(string message) : this(message)
    {
    }
}
