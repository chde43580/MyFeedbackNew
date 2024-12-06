using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record ReturnModel
    {
        public string JsonResponse { get; set; }

        public bool MakeReadonly { get; set; }
    }
}
