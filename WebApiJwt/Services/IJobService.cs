using WebApiJwt.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiJwt.Services
{
    public interface IJobService
    {
        List<Job> GetAll();
        Task<List<Job>> GetAllAsync();
        Task<List<Job>> GetAllWithIncludeAsync(string relatedEntities);

        Job GetById(Guid? id);
        Job Create(Job job);
        Job Update(Job job);
        void Delete(Job job);
    }
}