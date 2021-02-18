using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class IntersectionAlgo
{
    private static IEnumerable roomEffects = ReflectiveEnumerator.GetEnumerableOfType<RoomEffectsA>();
    private static int maxEffectsAmount = 3;
    private static int[] weight = new int[3] { 50, 30, 10 };


    public static List<IntersectionData> Yeet(int amount)
    {
        System.Random t = new System.Random();
        List<int> amountPerDoors = new List<int>();
        List<IntersectionData> toReturn = new List<IntersectionData>();
        List<RoomEffectsA> roomEffects = new List<RoomEffectsA>();

        List<RoomEffectsA> re = new List<RoomEffectsA>();
        foreach(RoomEffectsA rr in IntersectionAlgo.roomEffects)
        {
            re.Add(rr);
        }

        
        for (int i2 = 0; i2 < amount; i2++)
        {
            
            int[] ids = re.Select(x => x.GetID()).ToArray();
            ids = ids.OrderBy(x => t.Next()).ToArray();
            int counter = 0;
            int count = re.Count;
            for (int i = 0; i < count; i++)
            {
                if (Random.Range(1,101) <= weight[counter])                                //50% -> 30% -> 10%
                {
                    var room = re.Where(x => x.GetID() == ids[i]).First();

                    if (room.GetType() == typeof(LockedRoom) && re.OfType<LockedRoom>().Any())
                        re.Remove(re.Where(x => x.GetType() == typeof(LockedRoom)).First());

                    if (room.GetType() == typeof(MotivRoom) && re.OfType<MotivRoom>().Any())
                        re.Remove(re.Where(x => x.GetType() == typeof(MotivRoom)).First());

                    roomEffects.Add(room);
                    Debug.Log(room.GetDescription() + " " + i2);
                    
                    counter++;
                    
                    if (counter >= weight.Length) break;
                    
                    
                }
                    
            }
            amountPerDoors.Add(counter);
            toReturn.Add(new IntersectionData
            {
                lre = roomEffects
            });
            roomEffects.Clear();
        }

        return toReturn;
        
    }
}
public struct IntersectionData
{
    public List<RoomEffectsA> lre;
}
