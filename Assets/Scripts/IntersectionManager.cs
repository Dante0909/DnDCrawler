using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionManager : MonoBehaviour
{
    private Intersection intersection;
    public static IntersectionManager instance = null;
    private void Awake()
    {

        if (instance == null)
                instance = this;
        else
            Destroy(gameObject);
    }
    private void StartIntersection(int amount)
    {
        //Intersection.startintersection()
        //randomly grab a preset intersection intersection.genera

        //"Choose your path" -> intersection.event intersectionDialogue.StoryText and intersectionDialogue.options
        //call event on ui
        //

        //x room/path makes noise -> that room indicates danger(stronger or regular mob)    //standard dungeon
        //x room/path is silent (neutral or regular mob)                                    
        //x room/path increases motivation of x character                                   //library increases mage, but lowers priest, //religious altar
        //x room/path lowers motivation of x character                                      //armory increases warrior, but lowers thief, //thief room
        //x room/path is locked (make sure not all paths are locked)    
        //x room/path contains a treasure                                                   //treasure chest
        //x room/path is dark(might lower motivation or nothing)                            //dark looking room

        //program algorigthm of above ^
        //different rooms-> neutral, strong, normal + treasure
        //links the two above



        //return intersection.

    }

    private void DoEffect()
    {

    }
}
