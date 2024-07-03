using Assets.Scripts;
using UnityEngine;

public class BrickDestroyerController : MonoBehaviour
{
    private Score score;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Brick>())
        {
            score.ScoreValue--;
            Destroy(collision.gameObject);
        }
    }
}
