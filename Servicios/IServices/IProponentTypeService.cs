using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProponentTypeService
    {
        //METODO SAVE
        Task<int> SaveProponentTypeAsync(ProponentTypeViewModel proponentTypeViewModel);

        // METODO VIEW

        Task<List<ProponentTypeViewModel>> GetAllProponentTypesAsync();

        //UPDATE 
        Task<bool> UpdateProponentTypeAsync(int id, ProponentTypeViewModel proponentTypeViewModel);

        //DELETE
        Task<bool> DeleteProponentTypeAsync(int id);
    }
}


