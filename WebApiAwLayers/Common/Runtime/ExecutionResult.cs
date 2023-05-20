using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Runtime
{
    public class ExecutionResult
    {
        public bool Outcome { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public long LongId { get; set; }
        public string Code { set; get; }
    }
}
