using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA
{
    [Keyless]
    public class CamperNextOfKin
    {
        public int CamperId { get; set; }
        public int NextOfKinId { get; set; }

        //[ForeignKey("CamperId")] // Annotation för främmande nyckel
        public Camper Camper { get; set; }

        //[ForeignKey("NextOfKinId")] // Annotation för främmande nyckel
        public NextOfKin NextOfKin { get; set; }
    }
}
