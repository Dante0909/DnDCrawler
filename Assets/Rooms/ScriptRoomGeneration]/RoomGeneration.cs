using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumClassDirect;

public class RoomGeneration : MonoBehaviour
{
    public static RoomGeneration instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }
    }




    int[,] PlayingPlane;
    [SerializeField] private GameObject[] MonsterRooms;
    [SerializeField] private GameObject[] ItemRoom;
    [SerializeField] private GameObject[] PuzzleRoom;
    [SerializeField] private GameObject[] Hallway;


    [SerializeField] private GameObject room;




    [SerializeField] private GameObject Startingobject;
    List<GameObject> Scuares =new List<GameObject>(); 

    [SerializeField]private int RoomCounter = 6;
    [SerializeField]private GameObject Tile;
    [SerializeField]private GameObject Intersection;
    private GameObject Parent;

    public Direction LatestDirection=default;
    private Transform temp;


    //6 
    // one Room FIGTH && iTEM room && PuzzleRoom

    void Start()
    {
        
        //CreateHallway(Startingobject.transform,Direction.Up);
        temp=CreateHallway(Startingobject.transform, Direction.Left,true);
        AddIntersection(temp.transform);



        //for (int o = 0; o < 10; o++)
        //{
        //    temp = CreateHallway(temp, (Direction)Random.Range(0, Direction.GetNames(typeof(Direction)).Length));
        //}

        //temp = CreateHallway(temp, (Direction)Random.Range(0, Direction.GetNames(typeof(Direction)).Length));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddIntersection(Transform Initialposs)
    {
        GameObject TempIntersect;
        switch (LatestDirection)
        {
            case Direction.Up:
                TempIntersect=Instantiate(Intersection, Initialposs.position + new Vector3(0, 0, 1f), Quaternion.identity);
                Destroy(TempIntersect.GetComponent<TileInfo>().wallBot);
                break;
            case Direction.Left:
                TempIntersect = Instantiate(Intersection, Initialposs.position + new Vector3(-1 , 0, 0), Quaternion.identity);
                Destroy(TempIntersect.GetComponent<TileInfo>().wallRigth);
                break;
            case Direction.Down:
                TempIntersect = Instantiate(Intersection, Initialposs.position + new Vector3(0, 0, -1), Quaternion.identity);
                Destroy(TempIntersect.GetComponent<TileInfo>().wallTop);
                break;
            case Direction.Rigth:
                TempIntersect = Instantiate(Intersection, Initialposs.position + new Vector3(1, 0, 0), Quaternion.identity);
                Destroy(TempIntersect.GetComponent<TileInfo>().wallLeft);
                break;
            default:
                break;
        }

    }




    public Transform CreateHallway(Transform StartingPoint, Direction Orientation,bool Room)
    {

        //GameObject Tilee= Instantiate(Tile, StartingPoint.position, Quaternion.identity);
        GameObject Hallway = new GameObject("Tile");

        LatestDirection = Orientation;
        switch (Orientation)
        {
            case Direction.Up:
                if (Room)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(0, 0, 0.5f), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallBot);

                    Destroy(Parent.GetComponent<TileInfo>().wallTop);

                }

                for (int i = 0; i < 4; i++)
                {
                    Parent=Instantiate(Tile, StartingPoint.position + new Vector3(0,0, 1 + i), Quaternion.identity,Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallBot);
                    
                    Destroy(Parent.GetComponent<TileInfo>().wallTop);
                    
                }
                return Parent.transform;
                
                
               
            case Direction.Left:
                if (Room)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(-0.5f, 0, 0), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallRigth);
                    Destroy(Parent.GetComponent<TileInfo>().wallLeft);
                }
                
                for (int i = 0; i < 4; i++)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(-1 - i, 0,0), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallRigth);
                    
                        Destroy(Parent.GetComponent<TileInfo>().wallLeft);
                    
                }
                return Parent.transform;
                
            case Direction.Down:

                if (Room)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(0, 0, -.5f), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallTop);

                    Destroy(Parent.GetComponent<TileInfo>().wallBot);
                }


                    for (int i = 0; i < 4; i++)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(0,0, -1- i), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallTop);
                    
                        Destroy(Parent.GetComponent<TileInfo>().wallBot);
                    
                }
                return Parent.transform;
               
            case Direction.Rigth:


                if (Room)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(.5f, 0, 0), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallLeft);

                    Destroy(Parent.GetComponent<TileInfo>().wallRigth);

                }
                    for (int i = 0; i < 4; i++)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(1 + i, 0,0), Quaternion.identity,Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallLeft);
                    
                        Destroy(Parent.GetComponent<TileInfo>().wallRigth);
                    
                }
                return Parent.transform;
                
            default:
                return null;
                
        }
    }

    public void CreateRoom(Transform Possition, Direction Orientation)
    {
        GameObject Teporrarrigameobject;

        if (RoomCounter > 0)
        {
            switch (Orientation)
            {
                case Direction.Up:
                    Teporrarrigameobject=Instantiate(room, Possition.GetComponent<TileInfo>().PossTop.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                    temp = CreateHallway(Teporrarrigameobject.GetComponent<RoomScriptinfo>().ExitPoint.transform, Direction.Up, true);
                    AddIntersection(temp.transform);

                    break;
                case Direction.Left:
                    Teporrarrigameobject=Instantiate(room, Possition.GetComponent<TileInfo>().Possleft.transform.position, room.transform.rotation);
                    temp = CreateHallway(Teporrarrigameobject.GetComponent<RoomScriptinfo>().ExitPoint.transform, Direction.Left, true);
                    AddIntersection(temp.transform);
                    break;
                case Direction.Down:
                    Teporrarrigameobject=Instantiate(room, Possition.GetComponent<TileInfo>().PossBot.transform.position, Quaternion.Euler(new Vector3(90, 180, 0)));
                    temp = CreateHallway(Teporrarrigameobject.GetComponent<RoomScriptinfo>().ExitPoint.transform, Direction.Down, true);
                    AddIntersection(temp.transform);
                    break;
                case Direction.Rigth:
                    Teporrarrigameobject=Instantiate(room, Possition.GetComponent<TileInfo>().PossRigth.transform.position, Quaternion.Euler(new Vector3(90, -90, 0)));
                    temp = CreateHallway(Teporrarrigameobject.GetComponent<RoomScriptinfo>().ExitPoint.transform, Direction.Rigth, true);
                    AddIntersection(temp.transform);
                    break;
                default:
                    break;
                    
            }

            RoomCounter--;
        }


    }



}
