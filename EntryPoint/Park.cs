using ParkingFacility.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFacility.EntryPoint
{
    public static class Park
    {
       
        public static void StartParking()
        {
            List<int> slotSizes = new List<int> { 10, 5, 4 };
            ParkingInfra parkingInfra = new ParkingInfra(slotSizes);
            
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "123");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "1234");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "1235");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "123666");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "1238");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "1236");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "123111");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "123222");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "123333");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "122123");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "12323");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "12423");
            parkingInfra.RemoveVehicle("122123");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "12342");
            parkingInfra.StoreVehicle(ParkingTypeEnum.Small, "12324");
            parkingInfra.GetFreeSlotCount();

            parkingInfra.GetFreeSlotCount();

            parkingInfra.GetParkedLocation("12342");

        }
         

    }
}
