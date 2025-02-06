namespace CodeTest.Application.Interfaces.Mappings;

public interface IMappingStrategy<in TSource, out TDestination>
{
    TDestination Map(TSource source);
}