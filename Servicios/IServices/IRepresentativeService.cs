using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IRepresentativeService
    {
        Task<int> SaveRepresentativeAsync(RepresentativeViewModel representativeViewModel);
    }
}
