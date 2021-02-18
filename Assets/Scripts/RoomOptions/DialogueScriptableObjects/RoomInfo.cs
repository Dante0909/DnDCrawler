using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoomInfo : MonoBehaviour
{
    //Text options
    public string textToDisplay;

    //properties of room 
    public bool hasTreasure=false;
    public bool hasEnemies=false;
    public bool negativeMotivation=false;


    public int dangerLevel;
    public bool isBossRoom = false;
    public int numericalModifier=0;



    public List<PlayerCharacters> playersAffected= new List<PlayerCharacters>();
    private void Start()
    {
        if(isBossRoom)
        {
            //spawnboss
            return;
        }
        if(hasTreasure)
        {
            //Create Treasure
        }
        if(negativeMotivation)
        {
            foreach(PlayerCharacters p in playersAffected)
            {
                p.LoseMotivation(numericalModifier);
            }
        }
        if (hasEnemies)
        {
            //Instantiate Enemies 
            //GenerateEnemies(threatlevel)
        }
       
    }

}
