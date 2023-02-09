using System;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.UserCompanyRepositories;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.AppServices
{
    public class UserCompanyService : IUserCompanyService
    {
        private readonly IUserCompanyCommandRepository _userCompanyCommandRepository;
        private readonly IUserCompanyQueryRepository _userCompanyQueryRepository;
        private readonly IAppUnitOfWork _appUnitOfWork;
        public UserCompanyService(IUserCompanyCommandRepository userCompanyCommandRepository, IUserCompanyQueryRepository userCompanyQueryRepository,IAppUnitOfWork appUnitOfWork)
        {
            _userCompanyCommandRepository = userCompanyCommandRepository;
            _userCompanyQueryRepository = userCompanyQueryRepository;
            _appUnitOfWork = appUnitOfWork;
        }

        public async Task CreateAsync(AppUserCompany userCompany,CancellationToken cancellationToken)
        {
            await _userCompanyCommandRepository.AddAsync(userCompany, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteById(string userCompanyId, CancellationToken cancellationToken)
        {
            await _userCompanyCommandRepository.RemoveById(userCompanyId);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IList<AppUserCompany>> GetAllUserCompany(string filter)
        {
            return await _userCompanyQueryRepository.GetWhere(p => filter != null && (p.AppUser.UserName.ToLower().Contains(filter.ToLower())))
                                                    .Include("AppUser").Include("Company").ToListAsync();
                                                    
        }

        public async Task<IList<AppUserCompany>> GetCompanyListByUserId(string userId)
        {
            return await _userCompanyQueryRepository.GetWhere(p => p.AppUserId == userId).Include("Company").ToListAsync();
        }

     

        public async Task<AppUserCompany> GetUserCompanyById(string id)
        {
            return await _userCompanyQueryRepository.GetById(id, false);
        }

        public async Task<AppUserCompany> GetUserCompanyByUserIdAndCompanyId(string userId, string companyId)
        {
            return await _userCompanyQueryRepository.GetFirstByExpression(p => p.AppUserId == userId && p.CompanyId == companyId);
        }

        public async Task UpdateAsync(AppUserCompany userCompany, CancellationToken cancellationToken)
        {
            _userCompanyCommandRepository.Update(userCompany);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

