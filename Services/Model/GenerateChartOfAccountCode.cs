using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public class GenerateChartOfAccountCode
    {
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public string? Code { get; set; }
        public int? CategoryTypeId { get; set; }
    }
}
