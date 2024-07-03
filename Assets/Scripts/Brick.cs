using Assets.Scripts;
using Assets.Scripts.Enums;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private TypeBrick type;
    [SerializeField] private ColorBrick color;
    [SerializeField] private float speed = 1;
    [SerializeField] private float targetDistance = 15;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Transform brickTransform;
    private Score score;

    public TypeBrick Type {  get => type;  set => type=value; }
    public ColorBrick Color { get => color; set => color = value; }
    public float Speed { get => speed; set => speed=value; }

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        brickTransform = GetComponent<Transform>();

        if (color == ColorBrick.Red) spriteRenderer.color = UnityEngine.Color.red;
        if (color == ColorBrick.Yellow) spriteRenderer.color = UnityEngine.Color.yellow;
        if (color == ColorBrick.Green) spriteRenderer.color = UnityEngine.Color.green;
        if (color == ColorBrick.Blue) spriteRenderer.color = UnityEngine.Color.blue;
    }

    private void Update()
    {
        brickTransform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
}
