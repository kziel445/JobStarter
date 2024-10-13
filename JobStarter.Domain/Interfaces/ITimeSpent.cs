using JobStarter.Domain.Models;

namespace JobStarter.Application.Interfaces
{
    public interface ITimeSpent
    {
        IEnumerable<TimeSpent> GetSpent();
        TimeSpent GetById(int id);
        void Add(TimeSpent timeSpent);
        void Update(TimeSpent timeSpent);
        void Delete(int id);
    }
}
