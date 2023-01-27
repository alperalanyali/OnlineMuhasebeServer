using System;
using Application.Messaging;
using MediatR;

namespace Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    //public class CreateCompanyCommand:IRequest<CreateCompanyResponse>
    //{
    //       public string Name { get; set; }
    //       public string Address { get; set; }
    //       public string IdentityNumber { get; set; }
    //       public string TaxDepartment { get; set; }
    //       public string Tel { get; set; }
    //       public string Email { get; set; }
    //       public string ServerName { get; set; }
    //       public string DatabaseName { get; set; }
    //       public string ServerUserId { get; set; }
    //       public string ServerPassword { get; set; }
    //   }
    public record CreateCompanyCommand (
        string Name,
        string Address,
        string IdentityNumber,
        string TaxDepartment,
        string Tel,
        string Email,
        string ServerName,
        string DatabaseName,
        string ServerUserId,
        string ServerPassword
        ) : ICommand<CreateCompanyResponse>;
      

}

