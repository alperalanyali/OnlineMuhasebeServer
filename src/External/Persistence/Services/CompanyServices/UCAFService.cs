using System;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Application.Services.CompanyServices;
using AutoMapper;
using Domain;
using Domain.CompanyEntities;
using Domain.Repository.UCAFRepositories;
using Persistence.Context;

namespace Persistence.Services.CompanyServices
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContextService _contextService;
        private CompanyDbContext _companyDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _commandRepository = commandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUCAFAsync(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            _companyDbContext = (CompanyDbContext)_contextService.CreateDBContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInst(_companyDbContext);
            _unitOfWork.SetDbContextInst(_companyDbContext);

            UCAF ucaf = _mapper.Map<UCAF>(request);
            ucaf.Id = Guid.NewGuid().ToString();

            await _commandRepository.AddAsync(ucaf, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

