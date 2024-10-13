
using JobStarter.Application.Interfaces;
using JobStarter.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStarter.Application.Services
{
    public class TimeSpentService 
    {
        private readonly ILogger<ITimeSpent> _logger;
        private readonly ITimeSpent _repository;
        public TimeSpentService(ILogger<ITimeSpent> logger, ITimeSpent repository)
        {
            _logger = logger;
            _repository = repository;
        }

        
        public IEnumerable<TimeSpent> GetAll()
        {
            _logger.LogInformation("Start all TimeSpent retrive.");
            var model = _repository.GetAll();

            _logger.LogInformation($"Retrived {model.Count()} items.");

            return model;
        }

        public TimeSpent GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Add(TimeSpent timeSpent)
        {
            throw new NotImplementedException();
        }

        public void Update(TimeSpent timeSpent)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
