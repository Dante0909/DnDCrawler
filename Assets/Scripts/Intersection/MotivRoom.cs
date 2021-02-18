using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivRoom : RoomEffectsA
{
    private int index;
    private System.Type[] types;
    private string[] description = new string[4]
    {
        "This rooms contains an armory. It will please the warrior at the thief's expense.\n",
        "This rooms contains jewels. It will please the thief at the warrior's expense.\n",
        "This rooms contains a religious altar. It will please the priest at the mage's expense.\n",
        "This rooms contains magic manuscripts. It will please the mage at the priest's expense.\n"
};
    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        SetType();
        return description[index];
    }
    private void SetType()
    {
        var le = new System.Type[2];
        System.Random rnd = new System.Random();
        index = rnd.Next(0, 4);
        switch (index)
        {
            case 0:
                {
                    le[0] = typeof(Warrior);
                    le[1] = typeof(Thief);
                }
                break;
            case 1:
                {
                    le[0] = typeof(Thief);
                    le[1] = typeof(Warrior);
                }
                break;
            case 2:
                {
                    le[0] = typeof(Priest);
                    le[1] = typeof(Mage);
                }
                break;
            case 3:
                {
                    le[0] = typeof(Mage);
                    le[1] = typeof(Priest);
                }
                break;
        }
        types = le;
    }

    public System.Type[] GetMotivEffect()
    {
        return types;
    }
    public override int GetID()
    {
        return 3;
    }
}
