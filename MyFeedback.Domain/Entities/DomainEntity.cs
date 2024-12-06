using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public abstract class DomainEntity
    {
        public Guid Id { get; protected set; }

        [Timestamp]
        public byte[] RowVersion { get; protected set; }
    }
}
