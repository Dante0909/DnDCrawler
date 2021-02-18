using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionReturnData
{
    List<RoomEffectsA> roomEffects;
    public bool noise = false;
    public bool silent = false;
    public bool locked = false;
    public bool treasure = false;
    public bool dark = false;
    public MotivEffect motivEffect = null;

    public class MotivEffect
    {
        public int amount;
        public LivingEntities target;
        public MotivEffect(LivingEntities target)
        {
            amount = 10;
            this.target = target;
        }
    }
}
