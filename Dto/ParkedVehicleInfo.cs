using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFacility.Dto
{
     public class ParkedVehicleInfo
    {
        required public string VehicleNumber { get; set; }
        public DateTime EntryTime { get; set; } = DateTime.Now;
        required public ParkingTypeEnum SlotType { get; set; }
        required public int SlotNumber { get; set; }
    }
}
