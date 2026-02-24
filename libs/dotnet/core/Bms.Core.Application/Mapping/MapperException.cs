using Bms.Core.Domain;

namespace Bms.Core.Application.Mapping;

public class MapperException : BaseException
{
    public MapperException(string message) : base(message) { }
}
