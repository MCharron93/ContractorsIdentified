using System;
using System.Collections.Generic;
using ContractorsIdentified.Models;
using ContractorsIdentified.Repositories;

namespace ContractorsIdentified.Services
{
  public class JobService
  {
    private readonly JobRepository _repo;

    public JobService(JobRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Job> GetAllJobs()
    {
      return _repo.GetAllJobs();
    }

    public Job CreateJob(Job newJob)
    {
      newJob.Id = _repo.CreateJob(newJob);
      return newJob;
    }
  }
}