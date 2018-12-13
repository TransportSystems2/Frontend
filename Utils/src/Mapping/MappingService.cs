using AutoMapper;

namespace TransporSystems.Frontend.Utils.Mapping
{
    public class MappingService : IMappingService
    {
        public MappingService(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; }

        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}