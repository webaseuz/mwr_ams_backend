using AutoMapper;

namespace Bms.Core.Application.Mapping;

public interface IMapFrom<T>
{
    public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}