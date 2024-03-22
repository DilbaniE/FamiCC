using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios
{
    public class ProponentService : IProponentService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProponentService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveProponentAsync(ProponentViewModel proponentViewModel)
        {
            var proponent = new Proponent
            {
                NProponent = proponentViewModel.NProponent,
                Trajectory = proponentViewModel.Trajectory,
                FkRepresentativeId = proponentViewModel.FkRepresentativeId,
                FkTproponentId = proponentViewModel.FkTproponentId
            };

            _dbContext.Proponents.Add(proponent);
            await _dbContext.SaveChangesAsync();

            return proponent.Id;
        }
    }

}
