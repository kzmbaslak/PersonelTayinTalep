using AutoMapper;

namespace Core.Utilities.Mappings
{
    public static class AutoMapperHelper
    {
        private static IMapper _mapper;

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public static List<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> sourceList)
        {
            return sourceList.Select(item => _mapper.Map<TSource, TDestination>(item)).ToList();
        }
    }
}
