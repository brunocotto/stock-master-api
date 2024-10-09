namespace StockMaster.Exception.ExceptionsBase;

public abstract class StockMasterException : SystemException
{
    protected StockMasterException(string message) : base(message) { }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
