using JobStarter.Application.Interfaces;
using JobStarter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStarter.Infrastructure
{
    internal class CsvTimeSpentRepository : ITimeSpent
    {
        private readonly string _filePath;

        public CsvTimeSpentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public TimeSpent ParseLine(string line)
        {
            var parts = line.Split(',');
            return new TimeSpent
            {
                Id = int.Parse(parts[0]),
                Date = DateOnly.Parse(parts[1]),
                Spent = TimeSpan.Parse(parts[2]),
            };
        }

        public void SaveAll(IEnumerable<TimeSpent> models)
        {
            var lines = models.Select(x => $"{x.Id},{x.Date},{x.Spent}");
            File.WriteAllLines(_filePath, lines);
        }

        public IEnumerable<TimeSpent> GetAll()
        {
            throw new NotImplementedException();
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
