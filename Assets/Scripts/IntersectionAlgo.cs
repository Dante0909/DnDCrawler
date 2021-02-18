using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class IntersectionAlgo
{
    private static List<RoomEffectsA> roomEffects = ReflectiveEnumerator.GetEnumerableOfType<RoomEffectsA>().ToList();

    private static int maxEffectsAmount = 3;
    private static int[] weight = new int[3] { 50, 30, 10 };


    public static void Yeet(int amount)
    {
        var re = roomEffects;
        System.Random rnd = new System.Random();
        for (int i2 = 0; i2 < amount; i2++)
        {
            int[] ids = re.Select(x => x.GetID()).ToArray();
            ids = ids.OrderBy(x => rnd.Next()).ToArray();
            int counter = 0;
            bool flag = false;
            //
            for (int i = 0; i < re.Count; i++)
            {
                if (rnd.Next(1, 101) <= weight[counter])
                {
                    var room = re.Where(x => x.GetID() == ids[i]).First();
                    if (room.GetType() == typeof(LockedRoom)) flag = true;
                    counter++;
                    if (counter == weight.Length) break;
                    Debug.Log(room.GetDescription());

                }
                if (flag && re.OfType<LockedRoom>().Any())
                    re.RemoveAt(re.Where(x => x.GetType() == typeof(LockedRoom)).Select(x => x.GetID()).First());
            }
        }

    }
    private static void TE()
    {
        var i = new IntersectionReturnData
        {
            dark = true,

        };
    }
}
