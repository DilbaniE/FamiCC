using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using famiCCV1.Server.ViewModels.ViewModelDetails;
using famiCCV1.Server.ViewModels.ViewModelUpdate;
using Microsoft.EntityFrameworkCore;

namespace famiCCV1.Server.Servicios
{
    public class ProposedService : IProposedService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProposedService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        //SAVE
        public async Task<int> SaveProposedAsync(ProposedViewModel proposedViewModel)
        {
            var proposed = new Proposed
            {
                DescriptionActivities = proposedViewModel.DescriptionActivities,
                DescripcionProposed = proposedViewModel.DescripcionProposed,
                AlliedCompany = proposedViewModel.AlliedCompany,
                ProposedState = proposedViewModel.ProposedState,
                DateStart = proposedViewModel.DateStart,
                PresentationDate = proposedViewModel.PresentationDate,
                NameProponen = proposedViewModel.NameProponen,
                BenefitedPublic = proposedViewModel.BenefitedPublic,
                FkProponentId = proposedViewModel.FkProponentId,
                FkProposedvalueId = proposedViewModel.FkProposedvalueId
            };

            _dbContext.Proposeds.Add(proposed);
            await _dbContext.SaveChangesAsync();

            return proposed.Id;
        }

        //GETALL
        public async Task<List<ProposedViewModel>> GetAllProposedAsync()
        {
            var proposedList = await _dbContext.Proposeds
                .Select(p => new ProposedViewModel
                {
                    DescriptionActivities = p.DescriptionActivities,
                    DescripcionProposed = p.DescripcionProposed,
                    AlliedCompany = p.AlliedCompany,
                    ProposedState = p.ProposedState,
                    DateStart = p.DateStart ?? DateTime.MinValue,
                    PresentationDate = p.PresentationDate ?? DateTime.MinValue,
                    NameProponen = p.NameProponen,
                    BenefitedPublic = p.BenefitedPublic,
                    FkProponentId = p.FkProponentId ?? 0,
                    FkProposedvalueId = p.FkProposedvalueId ?? 0
                })
                .ToListAsync();

            return proposedList;
        }

        //GETALLDETAIL
        public async Task<List<ProposedViewModelDetail>> GetAllProposedWithDetailsAsync()
        {
            var proposedDetails = await _dbContext.Proposeds
                .Include(p => p.FkProponent)
                    .ThenInclude(p => p.FkRepresentative)
                        .ThenInclude(r => r.FkTdocument)
                .Include(p => p.FkProponent)
                    .ThenInclude(p => p.FkTproponent)
                .Include(p => p.FkProposedvalue)
                .Include(p => p.ProponentDocuments)
                    .ThenInclude(pd => pd.FkAdjuntdocument)
                .Select(p => new ProposedViewModelDetail
                {
                    Id = p.Id,
                    DescriptionActivities = p.DescriptionActivities,
                    DescripcionProposed = p.DescripcionProposed,
                    AlliedCompany = p.AlliedCompany,
                    ProposedState = p.ProposedState,
                    DateStart = p.DateStart,
                    PresentationDate = p.PresentationDate,
                    NameProponen = p.FkProponent.NProponent,
                    BenefitedPublic = p.BenefitedPublic,
                    FkProponentId = p.FkProponentId ?? 0,
                    FkProposedvalueId = p.FkProposedvalueId ?? 0,
                    Proponent = new ProponentViewModelDetail
                    {
                        Id = p.FkProponent.Id,
                        NProponent = p.FkProponent.NProponent,
                        Trajectory = p.FkProponent.Trajectory,
                        FkRepresentativeId = p.FkProponent.FkRepresentativeId ?? 0,
                        FkTproponentId = p.FkProponent.FkTproponentId ?? 0,
                        Representative = new RepresentativeViewModelDetail
                        {
                            Id = p.FkProponent.FkRepresentative.Id,
                            Email = p.FkProponent.FkRepresentative.Email,
                            NumDocument = p.FkProponent.FkRepresentative.NumDocument,
                            FirstName = p.FkProponent.FkRepresentative.FirstName,
                            LastName = p.FkProponent.FkRepresentative.LastName,
                            Phone = p.FkProponent.FkRepresentative.Phone,
                            FkTdocumentId = p.FkProponent.FkRepresentative.FkTdocumentId ?? 0,
                            DocumentType = new DocumentTypeViewModelDetail
                            {
                                Id = p.FkProponent.FkRepresentative.FkTdocument != null ? p.FkProponent.FkRepresentative.FkTdocument.Id : 0,
                                DocumentType1 = p.FkProponent.FkRepresentative.FkTdocument != null ? p.FkProponent.FkRepresentative.FkTdocument.DocumentType1 : string.Empty
                            }
                        },
                        ProponentType = new ProponentTypeViewModelDetail
                        {
                            Id = p.FkProponent.FkTproponent.Id,
                            ProponentType1 = p.FkProponent.FkTproponent.ProponentType1
                        }
                       

                    },

                    ProposedValue = new ProposedValueViewModelDetail
                    {
                        Id = p.FkProposedvalue.Id,
                        ContributionConfama = p.FkProposedvalue.ContributionConfama ?? 0,
                        TotalAmount = p.FkProposedvalue.TotalAmount ?? 0
                    },
                    ProponentDocuments = p.ProponentDocuments.Select(pd => new ProponentDocumentViewModelDetail
                        {
                        Id = pd.Id,
                        FkAdjuntdocumentId = pd.FkAdjuntdocumentId ?? 0,
                            FkProposedId = pd.FkProposedId ?? 0,
                            AdjuntDocument = new AdjuntDocumentViewModelDetail
                            {
                                Id = pd.FkAdjuntdocument.Id,
                                Urls = pd.FkAdjuntdocument.Urls,
                                NameDocument = pd.FkAdjuntdocument.NameDocument
                            }
                        }
                        
                        ).ToList()
                    }).ToListAsync();

                return proposedDetails;
        }

        public async Task UpdateProposedAsync(int id, UpdateProposedViewModel updateProposedViewModel)
        {
            var proposedToUpdate = await _dbContext.Proposeds.FindAsync(id);

            if (proposedToUpdate == null)
            {
                throw new ArgumentException("Proposed not found.");
            }

            // Actualizar los datos de la propuesta
            proposedToUpdate.DescriptionActivities = updateProposedViewModel.DescriptionActivities;
            proposedToUpdate.DescripcionProposed = updateProposedViewModel.DescripcionProposed;
            proposedToUpdate.AlliedCompany = updateProposedViewModel.AlliedCompany;
            proposedToUpdate.ProposedState = updateProposedViewModel.ProposedState;
            proposedToUpdate.DateStart = updateProposedViewModel.DateStart;
            proposedToUpdate.PresentationDate = updateProposedViewModel.PresentationDate;
            proposedToUpdate.NameProponen = updateProposedViewModel.NameProponen;
            proposedToUpdate.BenefitedPublic = updateProposedViewModel.BenefitedPublic;

            // Actualizar el proponente, el valor propuesto y los documentos del proponente

            await _dbContext.SaveChangesAsync();
        }

        //UPDATE
        //public async Task<bool> UpdateProposedAsync(int id, UpdateProposedViewModel updateProposedViewModel)
        //{
        //    var proposedToUpdate = await _dbContext.Proposeds.FindAsync(id);

        //    if (proposedToUpdate == null)
        //    {
        //        // Manejar el caso en que la propuesta no existe
        //        return false;
        //    }

        //    // Actualizar los datos de la propuesta
        //    proposedToUpdate.DescriptionActivities = updateProposedViewModel.DescriptionActivities;
        //    proposedToUpdate.DescripcionProposed = updateProposedViewModel.DescripcionProposed;
        //    proposedToUpdate.AlliedCompany = updateProposedViewModel.AlliedCompany;
        //    proposedToUpdate.ProposedState = updateProposedViewModel.ProposedState;
        //    proposedToUpdate.DateStart = updateProposedViewModel.DateStart;
        //    proposedToUpdate.PresentationDate = updateProposedViewModel.PresentationDate;
        //    proposedToUpdate.NameProponen = updateProposedViewModel.NameProponen;
        //    proposedToUpdate.BenefitedPublic = updateProposedViewModel.BenefitedPublic;

        //    // Actualizar el proponente
        //    var proponent = proposedToUpdate.FkProponent;
        //    proponent.NProponent = updateProposedViewModel.Proponent.NProponent;
        //    proponent.Trajectory = updateProposedViewModel.Proponent.Trajectory;

        //    var representative = proponent.FkRepresentative;
        //    representative.Email = updateProposedViewModel.Proponent.Representative.Email;
        //    representative.NumDocument = updateProposedViewModel.Proponent.Representative.NumDocument;
        //    representative.FirstName = updateProposedViewModel.Proponent.Representative.FirstName;
        //    representative.LastName = updateProposedViewModel.Proponent.Representative.LastName;
        //    representative.Phone = updateProposedViewModel.Proponent.Representative.Phone;

        //    var documentType = representative.FkTdocument;
        //    documentType.DocumentType1 = updateProposedViewModel.Proponent.Representative.DocumentType.DocumentType1;

        //    var proponentType = proponent.FkTproponent;
        //    proponentType.ProponentType1 = updateProposedViewModel.Proponent.ProponentType.ProponentType1;

        //    // Actualizar el valor propuesto
        //    var proposedValue = proposedToUpdate.FkProposedvalue;
        //    proposedValue.ContributionConfama = updateProposedViewModel.ProposedValue.ContributionConfama;
        //    proposedValue.TotalAmount = updateProposedViewModel.ProposedValue.TotalAmount;

        //    // Actualizar los documentos del proponente
        //    _dbContext.ProponentDocuments.RemoveRange(proposedToUpdate.ProponentDocuments);

        //    proposedToUpdate.ProponentDocuments = updateProposedViewModel.ProponentDocuments
        //        .Select(pd => new ProponentDocument
        //        {
        //            FkAdjuntdocumentId = pd.AdjuntDocument.Id
        //        }).ToList();

        //    await _dbContext.SaveChangesAsync();
        //    return true;
        //}

        //DELETE

        public async Task DeleteProposedAsync(int id)
        {
            var proposedToDelete = await _dbContext.Proposeds.FindAsync(id);

            if (proposedToDelete == null)
            {
                throw new ArgumentException("Propuesta no encontrada.");
            }

            _dbContext.Proposeds.Remove(proposedToDelete);
            await _dbContext.SaveChangesAsync();
        }





    }

}
