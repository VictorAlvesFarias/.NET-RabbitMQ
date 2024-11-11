using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AMQPDeathQueueItem
    {
        public int Id { get; set; }
        public object Body { get; set; }    
        public string Queue { get; set; }
        public string Exchange { get; set; }
    }
}
