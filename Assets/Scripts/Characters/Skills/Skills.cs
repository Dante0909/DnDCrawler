using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills
{
    public string skillName;
    public string skillDesc;


    public abstract void CastSkill(LivingEntities target, LivingEntities self);
    

}
