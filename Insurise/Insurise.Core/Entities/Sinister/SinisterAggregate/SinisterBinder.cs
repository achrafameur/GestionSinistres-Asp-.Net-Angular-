using Insurise.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate
{
    public class SinisterBinder : BaseEntity<int>
    {
        public DateTime SinisterDate { get; set; }
        public string SinisterTime { get; set; }
        public string? SinisterPlace { get; set; }
        public string? PolicyNumber { get; set; }
        public string? InsuredName { get; set; }
        public string? InsuredObject { get; set; }
        public string? Description { get; set; }
        public DateTime ReclamationDate { get; set; }
    }
}
