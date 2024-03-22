using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios
{
    public class ProponentTypeService : IProponentTypeService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProponentTypeService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

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
    }

}
