using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    int[,] PlayingPlane;
    [SerializeField] private GameObject[] MonsterRooms;
    [SerializeField] private GameObject[] ItemRoom;
    [SerializeField] private GameObject[] PuzzleRoom;
    [SerializeField] private GameObject[] Hallway;

    [SerializeField] private GameObject Startingobject;
    List<GameObject> Scuares =new List<GameObject>(); 

    private int RoomCounter = 6;
    [SerializeField]private GameObject Tile;
    private GameObject Parent;


    public enum Direction
    {
        Up,
        Left,
        Down,
        Rigth
    }

    //6 
    // one Room FIGTH && iTEM room && PuzzleRoom

    void Start()
    {
        
        //CreateHallway(Startingobject.transform,Direction.Up);
        Transform temp=CreateHallway(Startingobject.transform, Direction.Up);


        for (int o = 0; o < 10; o++)
        {
            temp = CreateHallway(temp, (Direction)Random.Range(0, Direction.GetNames(typeof(Direction)).Length));
        }
        //temp = CreateHallway(temp, (Direction)Random.Range(0, Direction.GetNames(typeof(Direction)).Length));


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform CreateHallway(Transform StartingPoint, Direction Orientation)
    {

        //GameObject Tilee= Instantiate(Tile, StartingPoint.position, Quaternion.identity);
        GameObject Hallway = new GameObject("Tile");
        

        switch (Orientation)
        {
            case Direction.Up:

                for (int i = 0; i < 4; i++)
                {
                    Parent=Instantiate(Tile, StartingPoint.position + new Vector3(0,0, 1 + i), Quaternion.identity,Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallBot);
                    
                    Destroy(Parent.GetComponent<TileInfo>().wallTop);
                    
                }
                return Parent.transform;
                
                
               
            case Direction.Left:
                for (int i = 0; i < 4; i++)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(-1 - i, 0,0), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallRigth);
                    
                        Destroy(Parent.GetComponent<TileInfo>().wallLeft);
                    
                }
                return Parent.transform;
                
            case Direction.Down:
                for (int i = 0; i < 4; i++)
                {
                    Parent = Instantiate(Tile, StartingPoint.position + new Vector3(0,0, 1- i), Quaternion.identity, Hallway.transform);
                    Destroy(Parent.GetComponent<TileInfo>().wallTop);
                    
                        Destroy(Parent.GetComponent<TileInfo>().wallBot);
                    
                }
                return Parent.transform;
               
            case Direction.Rigth:
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

    public void CreateRoom( )
    {

    }



}
