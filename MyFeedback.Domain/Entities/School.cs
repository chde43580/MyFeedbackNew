using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class School : DomainEntity
    {
        public string Name { get; protected set; }
        public string Address { get; protected set; }

        public School(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public School()
        {
            
        }
    }
}
