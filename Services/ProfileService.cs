using System;
using ContractorsIdentified.Models;
using ContractorsIdentified.Repositories;

namespace ContractorsIdentified.Services
{
  public class ProfileService
  {
    private readonly ProfileRepository _repo;

    public ProfileService(ProfileRepository repo)
    {
      _repo = repo;
    }

    public Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile foundProfile = _repo.GetByEmail(userInfo.Email);
      if (foundProfile == null)
      {
        return _repo.CreateProfile(userInfo);
      }
      return foundProfile;
    }
  }
}