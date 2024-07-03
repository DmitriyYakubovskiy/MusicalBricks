using Assets.Scripts;
using Assets.Scripts.Enums;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BrickUi : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TypeBrick[] brickTypes;
    private Dictionary<KeyCode,TypeBrick> keysDictinory;
    private Brick brick;

    public KeyCode[] keys;

    private void Start()
    {
        keysDictinory = new Dictionary<KeyCode,TypeBrick>();
        for (int i = 0; i < brickTypes.Length; i++)
        {
            keysDictinory.Add(keys[i], brickTypes[i]);
        }
    }

    public bool Check(KeyCode key)
    {
        if(!keys.Contains(key)) return false;
        if (brick != null)
        {
            if (keysDictinory[key]==brick.Type)
            {
                Destroy(brick.gameObject);
                score.ScoreValue++;
                return true;
            }
        }
        score.ScoreValue--;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!brickTypes.Contains(collision.gameObject.GetComponent<Brick>().Type)) return;
        brick=collision.gameObject.GetComponent<Brick>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!brickTypes.Contains(collision.gameObject.GetComponent<Brick>().Type)) return;
        brick = null; 
    }
}
