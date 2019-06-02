namespace TransporSystems.Frontend.Utils.Mapping
{
    public interface IMappingService
    {
        T Map<T>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        T2 Map<T1, T2>(T1 source);
    } 
}