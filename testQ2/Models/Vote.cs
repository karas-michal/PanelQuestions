using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testQ2.Models
{
    public class Vote
    {
        public int ID { get; set; }
        public Question Question { get; set; }
        public int score { get; set; }
    }
}
