using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PaymentHub.Application.ViewModels;
using PaymentHub.Domain;

namespace PaymentHub.Application.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public DomainToViewModelMappingProfile()
    {
      CreateMap<Tenant, TenantViewModel>().ReverseMap();
    }
  }
}
