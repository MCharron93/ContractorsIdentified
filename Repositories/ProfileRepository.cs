using System;
using System.Data;
using ContractorsIdentified.Models;
using Dapper;

namespace ContractorsIdentified.Repositories
{
  public class ProfileRepository
  {
    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    public Profile GetByEmail(string email)
    {
      string sql = "SELECT * FROM profiles WHERE email = @Email";
      return _db.QueryFirstOrDefault<Profile>(sql, new { email });
    }

    public Profile CreateProfile(Profile userInfo)
    {
      string sql = @"
      INSERT INTO profiles
      (name, email, id)
      VALUES
      (@Name, @Email, @Id);";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}