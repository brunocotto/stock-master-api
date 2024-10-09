using System.Net;

namespace StockMaster.Exception.ExceptionsBase;

public class NotFoundException : StockMasterException
{
    public NotFoundException(string message) : base(message) { }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
