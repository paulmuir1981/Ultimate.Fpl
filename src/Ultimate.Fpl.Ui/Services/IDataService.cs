using Ultimate.Fpl.Ui.Models.General;

namespace Ultimate.Fpl.Ui.Services
{
    public interface IDataService
    {
        Task<Data> GetAsync(CancellationToken cancellationToken = default);
    }
}
