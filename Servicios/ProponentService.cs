using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        //viewAlll
        public async Task<List<ProponentViewModel>> GetAllProponentsAsync()
        {
            var proponents = await _dbContext.Proponents
                .Select(p => new ProponentViewModel
                {
                    NProponent = p.NProponent,
                    Trajectory = p.Trajectory,
                    FkRepresentativeId = p.FkRepresentativeId ?? 0,
                    FkTproponentId = p.FkTproponentId ?? 0
                })
                .ToListAsync();

            return proponents;
        }

        //update

        public async Task<bool> UpdateProponentAsync(int id, ProponentViewModel proponentViewModel)
        {
            var existingProponent = await _dbContext.Proponents.FindAsync(id);

            if (existingProponent == null)
                return false;

            existingProponent.NProponent = proponentViewModel.NProponent;
            existingProponent.Trajectory = proponentViewModel.Trajectory;
            existingProponent.FkRepresentativeId = proponentViewModel.FkRepresentativeId;
            existingProponent.FkTproponentId = proponentViewModel.FkTproponentId;

            _dbContext.Entry(existingProponent).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }




    }

}
