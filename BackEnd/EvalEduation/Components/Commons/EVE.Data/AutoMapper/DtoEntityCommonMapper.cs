
using global::AutoMapper;


namespace EVE.Data
{

    public class DtoEntityCommonMapper : Profile
    {
        public DtoEntityCommonMapper()
        {
            #region Enity To Dto

            //CreateMap<ITEM, ItemDto>();
            //CreateMap<ITEM_REEFER, ItemReeferDto>();
            //CreateMap<AGENT, AgentDto>();
            //CreateMap<CONVERT_TO_ISO, ConvertToIsoDto>();
            //CreateMap<DEPOT, DepotDto>();
            //CreateMap<SYS_CODES, SysCodesDto>();
            //CreateMap<LINE_OPER, LineOperDto>();

            #endregion

            #region Dto to Entity

            //CreateMap<ItemDto, ITEM>();
            //CreateMap<ItemReeferDto, ITEM_REEFER>();
            //CreateMap<AgentDto, AGENT>();
            //CreateMap<ConvertToIsoDto, CONVERT_TO_ISO>();
            //CreateMap<DepotDto, DEPOT>();
            //CreateMap<SysCodesDto, SYS_CODES>();
            //CreateMap<LineOperDto, LINE_OPER>();

            #endregion
        }
    }
}
