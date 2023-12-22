using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA
{
    public class Stay
    {
        public int StayId { get; set; }
        public int CamperId { get; set; }
        public int CounselorId { get; set; }
        public int CabinId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Camper Camper { get; set; }
        public Counselor Counselor { get; set; }
        public Cabin Cabin { get; set; }
    }
}
