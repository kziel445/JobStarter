using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStarter.Domain.Models
{
    public class Command
    {
        public string Text { get; set; }
        public Command(string text) 
        {
            Text = text;
        }
    }
}
