using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Category : DomainEntity
    {
        public string Name { get; protected set; }

        public string PrincipalEmail { get; protected set; }

        public Category(string name, string principalEmail)
        {
            this.Name = name;
            this.PrincipalEmail = principalEmail;
        }
    }
}
