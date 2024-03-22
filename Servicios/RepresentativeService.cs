using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace famiCCV1.Server.Servicios
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly famiCC_v1Context _dbContext;

        public RepresentativeService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        //metod save 
        public async Task<int> SaveRepresentativeAsync(RepresentativeViewModel representativeViewModel)
        {
            var representative = new Representative
            {
                Email = representativeViewModel.Email,
                NumDocument = representativeViewModel.NumDocument,
                FirstName = representativeViewModel.FirstName,
                LastName = representativeViewModel.LastName,
                Phone = representativeViewModel.Phone,
                FkTdocumentId = representativeViewModel.FkTdocumentId
            };

            _dbContext.Representatives.Add(representative);
            await _dbContext.SaveChangesAsync();

            return representative.Id;
        }

        public async Task<List<RepresentativeViewModel>> GetAllRepresentativesAsync()
        {
            var representatives = await _dbContext.Representatives.ToListAsync();
            return representatives.Select(r => new RepresentativeViewModel
            {
                Email = r.Email,
                NumDocument = r.NumDocument,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Phone = r.Phone,
                FkTdocumentId = r.FkTdocumentId ?? 0 // Manejar el valor nulo de FkTdocumentId
            }).ToList();
        }

        // update 


        public async Task<bool> UpdateRepresentativeAsync(int id, RepresentativeViewModel representativeViewModel)
        {
            var existingRepresentative = await _dbContext.Representatives.FindAsync(id);
            if (existingRepresentative == null)
            {
                return false; // No se encontró el representante con el ID dado
            }

            // Actualiza las propiedades del representante existente con los valores del ViewModel
            existingRepresentative.Email = representativeViewModel.Email;
            existingRepresentative.NumDocument = representativeViewModel.NumDocument;
            existingRepresentative.FirstName = representativeViewModel.FirstName;
            existingRepresentative.LastName = representativeViewModel.LastName;
            existingRepresentative.Phone = representativeViewModel.Phone;
            existingRepresentative.FkTdocumentId = representativeViewModel.FkTdocumentId;

            // Guarda los cambios en la base de datos
            await _dbContext.SaveChangesAsync();

            return true; // Actualización exitosa
        }

    }

}
