using AutoMapper;
using ClientEntry = Fpl.Client.Models.Entries.Entry;
using Entry = Ultimate.Fpl.Ui.Models.Entries.Entry;

namespace Ultimate.Fpl.Ui.Profiles.Entries
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<ClientEntry, Entry>();
        }
    }
}
