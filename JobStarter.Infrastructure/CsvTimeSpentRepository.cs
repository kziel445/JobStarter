using JobStarter.Application.Interfaces;
using JobStarter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var lines = File.ReadAllLines(_filePath);
            return lines.Select(ParseLine).ToList();
        }

        public TimeSpent GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Add(TimeSpent timeSpent)
        {
            var models = GetAll().ToList();
            timeSpent.Id = models.Any() ? models.Max(x => x.Id) + 1 : 1;
            models.Add(timeSpent);

            SaveAll(models);
        }

        public void Update(TimeSpent timeSpent)
        {
            var models = GetAll().ToList();
            var existing = models.FirstOrDefault(x => x.Id == timeSpent.Id);
            if (existing != null)
            {
                models.Remove(existing);
                models.Add(timeSpent);
                SaveAll(models);
            }
        }

        public void Delete(int id)
        {
            var models = GetAll().ToList();
            var existing = GetById(id);
            if (existing != null)
            {
                models.Remove(existing);
                SaveAll(models);
            }
        }
    }
}
