
using AutoMapper;
using MianXiangProject.DataTables;
using MianXiangProject.DataTableOption.MXJobOption.Dtos;

namespace MianXiangProject.DataTableOption.MXJobOption.Dtos
{

    /// <summary>
    /// 配置MXJob的AutoMapper
    /// </summary>
    public class MXJobMapper : Profile
    {
        public MXJobMapper()
        {
            CreateMap <MXJob,MXJobListDto>();
            CreateMap <MXJobListDto,MXJob>();

            CreateMap <MXJobEditDto,MXJob>();
            CreateMap <MXJob,MXJobEditDto>();

        }
	}
}
