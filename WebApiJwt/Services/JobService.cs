using Microsoft.EntityFrameworkCore;
using WebApiJwt.Data;
using WebApiJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJwt.Services
{
    public class JobService : IJobService
    {
        private readonly IGenericRepository<Job> _repository;

        public JobService(IGenericRepository<Job> repository)
        {
            _repository = repository;
        }


        public List<Job> GetAll()
        {
            List<Job> list = _repository.GetAll()
                                        .Include(j => j.Persons)
                                        .ToList();
            return list;
        }


        public async Task<List<Job>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }



        public async Task<List<Job>> GetAllWithIncludeAsync(string relatedEntities)
        {
            return (await _repository.GetAllWithIncludeAsync(relatedEntities)).ToList();
        }


        public Job GetById(Guid? id)
        {
            if (id == null)
                return null;

            Job job = _repository.GetBy(j => j.Id == id)
                                       .Include(p => p.Persons)
                                       .FirstOrDefault();

            return job;
        }



        public Job Create(Job job)
        {
            return _repository.Insert(job);
        }



        public Job Update(Job job)
        {
            return _repository.Update(job);
        }



        public void Delete(Job job)
        {
            _repository.Delete(job);
        }
    }
}