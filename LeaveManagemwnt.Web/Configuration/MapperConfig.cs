using AutoMapper;
using LeaveManagemwnt.Web.Data;
using Microsoft.Build.Framework.Profiler;

namespace LeaveManagemwnt.Web.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVm>().ReverseMap();

        }
    }
}
