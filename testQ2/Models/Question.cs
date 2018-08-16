using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testQ2.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Room Room { get; set; }
    }
}
