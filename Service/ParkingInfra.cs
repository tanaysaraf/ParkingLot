using ParkingFacility.Dto;
using System.Text.Json;


namespace ParkingFacility.Service
{
    public class ParkingInfra
    {
        public List<SortedSet<int>> parkingLots = new();
        public Dictionary<string, ParkedVehicleInfo> parkedVehicles = new();
        public int typeOfLots = Enum.GetValues(typeof(ParkingTypeEnum)).Length;

        public ParkingInfra(List<int>SlotSizes)
        {
            foreach (var size in SlotSizes)
            {
                parkingLots.Add([.. Enumerable.Range(0, size)]);
            }
        }

        public ParkedVehicleInfo? StoreVehicle(ParkingTypeEnum parkingType, string number)
        {
            if(parkedVehicles.ContainsKey(number))
            {
                Console.WriteLine("Vehicle already exist.");
                return null;
            }

            int ind = (int)parkingType;

            for (int i = ind; i < typeOfLots; i++)
            {
                if (parkingLots[i].Count > 0)
                {
                    var slotName = Enum.GetValues(typeof(ParkingTypeEnum)).GetValue(i)!.ToString();
                    int free = parkingLots[i].Min;
                    parkingLots[i].Remove(free);
                    Console.WriteLine($"Allocated slot {free} from {slotName}");

                    var parkedVehicleInfo = new ParkedVehicleInfo
                    {
                        VehicleNumber = number,
                        SlotNumber = free,
                        SlotType = (ParkingTypeEnum)Enum.GetValues(typeof(ParkingTypeEnum)).GetValue(i)!,
                    };
                    parkedVehicles[number] = parkedVehicleInfo;
                    return parkedVehicleInfo;
                }
            }
            Console.WriteLine($"No Empty Slot");
            return null;
        }

        public void RemoveVehicle(string number)
        {
            if (parkedVehicles.TryGetValue(number, out var param))
            {
                Console.WriteLine($"Removing from {param.SlotType}");
                parkingLots[(int)param.SlotType].Add(param.SlotNumber);
                parkedVehicles.Remove(number);
                return;
            }
            Console.WriteLine("No such car is parked!");
            
        }

        public void GetParkedLocation(string number)
        {
            if (parkedVehicles.TryGetValue(number, out var param))
            {
                Console.WriteLine($"Details {JsonSerializer.Serialize(param)}");
            }
            else
            {
                Console.WriteLine("No such car is parked!");
            }
        }

        public void GetFreeSlotCount()
        {
            for (int i = 0; i < typeOfLots; i++)
            {
                var slotName = Enum.GetValues(typeof (ParkingTypeEnum)).GetValue(i)!.ToString();
                Console.WriteLine($"For {slotName} we have {parkingLots[i].Count} slots free");
            }
        }

    }
}
