using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStarter.Domain.Models
{
    public class TimeSpent
    {
        public int Id;
        public DateOnly Date;
        public TimeSpan Spent;
    }
}
