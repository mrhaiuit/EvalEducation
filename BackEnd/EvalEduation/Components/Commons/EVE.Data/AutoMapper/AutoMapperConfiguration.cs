
using global::AutoMapper;

namespace EVE.Data
{

    public static class AutoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(p =>
            {
                p.AddProfile(new DtoEntityCommonMapper());
            });
        }
    }
}
