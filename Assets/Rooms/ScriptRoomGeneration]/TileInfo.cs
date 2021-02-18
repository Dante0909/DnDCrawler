using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumClassDirect;

public class TileInfo : MonoBehaviour
{
    public GameObject wallLeft;
    public GameObject wallRigth;
    public GameObject wallBot;
    public GameObject wallTop;

    public GameObject Possleft;
    public GameObject PossRigth;
    public GameObject PossBot;
    public GameObject PossTop;

    [SerializeField] bool Intercection=false;

    private RoomGeneration Roommanager;
    private Transform Temposs;

    void Start()
    {
         
        Roommanager = RoomGeneration.instance;

        if (Intercection)
        {
            switch (Roommanager.LatestDirection)
            {
                case Direction.Up:

                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform,Direction.Up,false), Direction.Up);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform,Direction.Rigth,false), Direction.Rigth);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform,Direction.Left,false), Direction.Left);
                    break;
                case Direction.Left:

                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Up, false), Direction.Up);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Left, false),Direction.Left);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Down, false), Direction.Down);
                    break;
                case Direction.Down:
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Down, false), Direction.Down);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Rigth, false), Direction.Rigth);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Left, false), Direction.Left);
                    break;
                case Direction.Rigth:
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Up, false), Direction.Up);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Rigth, false), Direction.Rigth);
                    Roommanager.CreateRoom(Roommanager.CreateHallway(gameObject.transform, Direction.Down, false), Direction.Down);
                    break;
                default:
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
