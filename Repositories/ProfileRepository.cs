using System;
using System.Data;
using ContractorsIdentified.Models;

namespace ContractorsIdentified.Repositories
{
  public class ProfileRepository
  {
    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetByEmail(object email)
    {
      throw new NotImplementedException();
    }

    internal Profile CreateProfile(Profile userInfo)
    {
      throw new NotImplementedException();
    }
  }
}