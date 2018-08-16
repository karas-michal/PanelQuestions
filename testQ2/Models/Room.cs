using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testQ2.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }

		public static implicit operator Room(int v)
		{
			throw new NotImplementedException();
		}
	}
}
