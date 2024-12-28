using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public class Data4CreateLogObject<T,U>
    {
        public string? Message { get; set; }
        public string? ActionType { get; set; } // get, post, put, delete
        public int? EventTypeId { get; set; }
        public T? Payload { get; set; }
        public U? Response { get; set; }
        public bool? IsLogPayload { get; set; } 
        public int Result { get; set; }
        public int? FinanceTransactionId { get; set; }
        public string? LogPage { get; set; }
        public string? LinkText { get; set; }
    }
}
