namespace BarberShop.Exception.ExceptionsBase;

public abstract class BarberShopException : SystemException
{
    protected BarberShopException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}

