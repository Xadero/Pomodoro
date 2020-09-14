using AutoMapper;
using Pomodoro.DAL.Models.Pomodoro;
using Pomodoro.Dtos;

namespace Pomodoro.Profiles
{
    public class PomodoroProfile : Profile
    {
        public PomodoroProfile()
        {
            CreateMap<PomodoroTypeDto, PomodoroType>();
            CreateMap<PomodoroType, PomodoroTypeDto>();


            CreateMap<PomodoroSettingsDto, PomodoroSettings>();
            CreateMap<PomodoroSettings, PomodoroSettingsDto>();

            CreateMap<PomodoroDto, Pomodoros>();
            CreateMap<Pomodoros, PomodoroDto>();


            CreateMap<PomodoroStatusDto, PomodoroStatus>();
            CreateMap<PomodoroStatus, PomodoroStatusDto>();

        }
    }
}
