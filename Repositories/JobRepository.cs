using System;
using System.Collections.Generic;
using System.Data;
using ContractorsIdentified.Models;
using Dapper;

namespace ContractorsIdentified.Repositories
{
  public class JobRepository
  {
    private readonly IDbConnection _db;

    public JobRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Job> GetAllJobs()
    {
      string sql = "SELECT * FROM jobs";
      return _db.Query<Job>(sql);
    }

    public int CreateJob(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (title, company, pay, benefits, id)
      VALUES 
      (@Title, @Company, @Pay, @Benefits, @Id);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newJob);

    }
  }
}