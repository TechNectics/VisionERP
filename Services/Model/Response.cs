using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public class ResponseObject<T>
    {
        public int result { get; set; }
        public string? message { get; set; }
        public T? payload { get; set; }
    }
}
