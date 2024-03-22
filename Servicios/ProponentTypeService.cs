using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace famiCCV1.Server.Servicios
{
    public class ProponentTypeService : IProponentTypeService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProponentTypeService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        //METODO SAVE

        public async Task<int> SaveProponentTypeAsync(ProponentTypeViewModel proponentTypeViewModel)
        {
            var proponentType = new ProponentType
            {
                ProponentType1 = proponentTypeViewModel.ProponentType1
            };

            _dbContext.ProponentTypes.Add(proponentType);
            await _dbContext.SaveChangesAsync();

            return proponentType.Id;
        }
        // METODO VER 
        public async Task<List<ProponentTypeViewModel>> GetAllProponentTypesAsync()
        {
            return await _dbContext.ProponentTypes
                .Select(pt => new ProponentTypeViewModel
                {
                    ProponentType1 = pt.ProponentType1
                })
                .ToListAsync();
        }

        //METODO UPDATE
        public async Task<bool> UpdateProponentTypeAsync(int id, ProponentTypeViewModel proponentTypeViewModel)
        {
            var existingProponentType = await _dbContext.ProponentTypes.FindAsync(id);

            if (existingProponentType == null)
                return false;

            existingProponentType.ProponentType1 = proponentTypeViewModel.ProponentType1;

            _dbContext.ProponentTypes.Update(existingProponentType);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        //METODO DELETE
        public async Task<bool> DeleteProponentTypeAsync(int id)
        {
            var proponentType = await _dbContext.ProponentTypes.FindAsync(id);

            if (proponentType == null)
                return false;

            _dbContext.ProponentTypes.Remove(proponentType);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }

}

