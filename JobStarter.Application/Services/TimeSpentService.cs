
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
            _logger.LogInformation("Start retrive all TimeSpent.");
            var model = _repository.GetAll();

            _logger.LogInformation($"Retrived {model.Count()} items.");

            return model;
        }

        public TimeSpent GetById(int id)
        {
            _logger.LogInformation($"Start {id} all TimeSpent.");
            var model = _repository.GetById(id);

            _logger.LogInformation($"Retrived id: {id} item.");

            return model;
        }
        public void Add(TimeSpent timeSpent)
        {
            _logger.LogInformation($"Start adding.");
            
            _repository.Add(timeSpent);

            _logger.LogInformation($"Added {timeSpent.Id}, {timeSpent.Date},{timeSpent.Spent}");
        }

        public void Update(TimeSpent timeSpent)
        {
            _logger.LogInformation($"Start updating.");
            var Old = _repository.GetById(timeSpent.Id);
            _repository.Update(timeSpent);

            _logger.LogInformation($"Updated {timeSpent.Id}, {timeSpent.Date},{timeSpent.Spent} from {Old.Id}, {Old.Date},{Old.Spent}");
        }
        public void Delete(int id)
        {
            _logger.LogInformation($"Start removing.");
            var Old = _repository.GetById(id);
            _repository.Delete(id);

            _logger.LogInformation($"Removed {Old.Id}, {Old.Date},{Old.Spent}");
        }
    }
}
