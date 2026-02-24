namespace ServiceDesk.Application;

public interface INumberService
{
    public delegate string GetNextNumberKeyMapFunc(string key, int nextNumber);
    (int nextNumber, string docNumber) GetNext(string document);
    (int nextNumber, string docNumber) GetNext(string document, GetNextNumberKeyMapFunc keyMapper);
    (int nextNumber, string docNumber) GetNext(string templateDocument, string numberDocument, GetNextNumberKeyMapFunc keyMapper);
}
