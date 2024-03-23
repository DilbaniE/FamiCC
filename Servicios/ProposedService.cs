using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using famiCCV1.Server.ViewModels.ViewModelDetails;
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
                        ProponentType = new ProponentTypeViewModel
                        {
                            //Id = p.FkProponent.FkTproponent.Id,
                            ProponentType1 = p.FkProponent.FkTproponent.ProponentType1
                        },
                        ProposedValue = new ProposedValueViewModel
                        {
                            //Id = p.FkProposedvalue.Id,
                            ContributionConfama = p.FkProposedvalue.ContributionConfama ?? 0,
                            TotalAmount = p.FkProposedvalue.TotalAmount ?? 0
                        }

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





    }

}
