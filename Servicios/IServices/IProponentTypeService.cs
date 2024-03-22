using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProponentTypeService
    {
        Task<int> SaveProponentTypeAsync(ProponentTypeViewModel proponentTypeViewModel);
    }
}
