using AutoMapper;
using Fpl.Client.Models.General;
using Ultimate.Fpl.Ui.Models.General;

namespace Ultimate.Fpl.Ui.Profiles.General
{
    public class GameweekProfile : Profile
    {
        public GameweekProfile()
        {
            CreateMap<Event, Gameweek>();
        }
    }
}