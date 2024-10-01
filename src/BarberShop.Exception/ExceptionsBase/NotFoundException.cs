using System.Net;

namespace BarberShop.Exception.ExceptionsBase;

public class NotFoundException : BarberShopException
{
    public NotFoundException(string message) : base(message)
    {

    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
