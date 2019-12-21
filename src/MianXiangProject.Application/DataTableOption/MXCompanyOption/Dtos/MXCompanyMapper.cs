
using AutoMapper;
using MianXiangProject.DataTables;
using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;

namespace MianXiangProject.DataTableOption.MXCompanyOption.Dtos
{

	/// <summary>
    /// 配置MXCompany的AutoMapper
    /// </summary>
	public class MXCompanyMapper: Profile
    {
        public MXCompanyMapper()
        {
            CreateMap <MXCompany,MXCompanyListDto>();
            CreateMap <MXCompanyListDto,MXCompany>();

            CreateMap <MXCompanyEditDto,MXCompany>();
            CreateMap <MXCompany,MXCompanyEditDto>();

        }
	}
}
