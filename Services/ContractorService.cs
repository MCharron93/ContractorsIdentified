using System;
using ContractorsIdentified.Models;
using ContractorsIdentified.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContractorsIdentified.Services
{
  public class ContractorService
  {

    private readonly ContractorRepository _cr;

    public ContractorService(ContractorRepository cr)
    {
      _cr = cr;
    }

    public Contractor GetContractor(string profileId, Profile userInfo)
    {
      Contractor foundContractor = _cr.GetByProfileId(userInfo);
      if (profileId == foundContractor.CreatorId)
      {
        return foundContractor;
      }
    }

    public Contractor Create(Contractor newContractor)
    {
      newContractor.Id = _cr.CreateContractor(newContractor);
      return newContractor;
    }
  }
}