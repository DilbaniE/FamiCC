using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IRepresentativeService
    {
        //savr
        Task<int> SaveRepresentativeAsync(RepresentativeViewModel representativeViewModel);

        //getAll
        Task<List<RepresentativeViewModel>> GetAllRepresentativesAsync();
        // update 
        Task<bool> UpdateRepresentativeAsync(int id, RepresentativeViewModel representativeViewModel);
    }



}
