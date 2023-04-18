using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class Rent
    {
        
        //Where is default constructor?
        
        public Rent(DateTime rentDate, double rentCost)
        {
            RentDate = rentDate;
            RentCost = rentCost;
        }

        public DateTime RentDate { get; set; }
        public double RentCost { get; set; }
    }
}
