using Assets.Scripts;
using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BricksBuilderController : MonoBehaviour
{
    [SerializeField] private RowPoints[] rows = new RowPoints[4];
    [SerializeField] private BrickTemplateObjects bricksObjects;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private float speed = 1.2f;
    [SerializeField] private float bufferDistance = 4;
    private MapModel map;
    private float time = 0;
    private float startTime = 2f;
    private int currentBlock = 0;
    public bool isRandom = false;


    public float Speed
    {
        get => speed;
        set
        {
            speed = value;
            startTime = bufferDistance / speed;
        }
    }

    private void Start()
    {
        if (string.IsNullOrEmpty(CurrentMap.Name))
        {
            isRandom = true;
        }
        else
        {
            map = saveManager.GetMap(CurrentMap.Name);
            speed= map.speed;   
        }
        CurrentMap.Name = "";
        startTime = bufferDistance / speed;
    }

    private void Update()
    {
        if (isRandom) BuildRandomMap();
        else BuildMap();
    }

    private void BuildMap()
    {
        if (currentBlock >= map.blocks.Count) return;
        if (time <= 0)
        {
            for (int i = 0; i < map.blocks[currentBlock].rows.Length; i++)
            {
                for (int j = 0; j < map.blocks[currentBlock].rows[i].bricks.Length; j++)
                {
                    GameObject obj;
                    if (map.blocks[currentBlock].rows[i].bricks[j].type == TypeBrick.Square) obj = bricksObjects.squareBrick;
                    else if (map.blocks[currentBlock].rows[i].bricks[j].type == TypeBrick.None) obj = bricksObjects.simpleBrick;
                    else if(map.blocks[currentBlock].rows[i].bricks[j].type == TypeBrick.CircleCross) obj = bricksObjects.circleCrossBrick;
                    else if(map.blocks[currentBlock].rows[i].bricks[j].type == TypeBrick.CircleCrossLine) obj = bricksObjects.circleCrossLineBrick;
                    else if(map.blocks[currentBlock].rows[i].bricks[j].type == TypeBrick.Cross) obj = bricksObjects.crossBrick;
                    else if(map.blocks[currentBlock].rows[i].bricks[j].type == TypeBrick.Line) obj = bricksObjects.line;
                    else obj = null;
                    if (obj != null)
                    {
                        obj.GetComponent<Brick>().Speed = speed;
                        obj.GetComponent<Brick>().Color = map.blocks[currentBlock].rows[i].bricks[j].color;
                        obj.transform.position = rows[i].points[j].transform.position;
                        Instantiate(obj);
                    }
                }
                if (map.blocks[currentBlock].rows[i].line)
                {
                    var obj = Instantiate(bricksObjects.line);
                    obj.GetComponent<Brick>().Speed = speed;
                    obj.transform.position = new Vector3(0, rows[i].points[0].transform.position.y);
                }
            }
            time = startTime + map.blocks[currentBlock].speedDelay;
            currentBlock++;
        }
        time -= Time.deltaTime;
    }

    private void BuildRandomMap()
    {
        if (time <= 0)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].points.Length; j++)
                {
                    GameObject obj;
                    if (j == 0)
                    {
                        int index = Random.Range(0, 10);
                        obj = bricksObjects.GetBrick(index, new int[1] {0});
                        if(obj !=null) if (obj.GetComponent<Brick>()) obj.GetComponent<Brick>().Color = ColorBrick.Red;
                    }
                    else if (j == 1)
                    {
                        int index = Random.Range(0, 10);
                        obj = bricksObjects.GetBrick(index, new int[4] { 0, 1, 2, 3 });
                        if (obj != null) if (obj.GetComponent<Brick>()) obj.GetComponent<Brick>().Color = ColorBrick.Yellow;
                    }
                    else if (j == 2)
                    {
                        int index = Random.Range(0, 10);
                        obj = bricksObjects.GetBrick(index, new int[2] { 0 , 4});
                        if (obj != null) if (obj.GetComponent<Brick>()) obj.GetComponent<Brick>().Color = ColorBrick.Blue;
                    }
                    else
                    {
                        int index = Random.Range(0, 10);
                        obj = bricksObjects.GetBrick(index, new int[2] { 0,4 });
                        if (obj != null) if (obj.GetComponent<Brick>()) obj.GetComponent<Brick>().Color = ColorBrick.Green;
                    }
                    if (obj != null)
                    {
                        if (!obj.GetComponent<Brick>()) continue;
                        obj.GetComponent<Brick>().Speed = speed;
                        obj.transform.position = rows[i].points[j].transform.position;
                        Instantiate(obj);
                    }
                }
                if (Random.Range(0, 5) == 0)
                {
                    var obj = Instantiate(bricksObjects.line);
                    if (!obj.GetComponent<Brick>()) continue;
                    obj.GetComponent<Brick>().Speed = speed;
                    obj.transform.position = new Vector3(0, rows[i].points[0].transform.position.y);
                }
            }
            time = startTime;
        }
        time -= Time.deltaTime;
    }
}

[System.Serializable]
public class RowPoints
{
    public GameObject[] points = new GameObject[4];
}

[System.Serializable]
public class BrickTemplateObjects
{
    public GameObject simpleBrick;
    public GameObject squareBrick;
    public GameObject circleCrossBrick;
    public GameObject crossBrick;
    public GameObject circleCrossLineBrick;
    public GameObject line;

    public GameObject GetBrick(int index, int[] indexes)
    {
        if(index==0 && indexes.Contains(0)) return simpleBrick;
        else if(index==1 && indexes.Contains(1)) return squareBrick;
        else if (index==2 && indexes.Contains(2)) return circleCrossBrick; 
        else if (index==3 && indexes.Contains(3)) return crossBrick;
        else if (index==4 && indexes.Contains(4)) return circleCrossLineBrick;
        else if (index== 5 && indexes.Contains(5)) return line;
        else return null;
    }
}
