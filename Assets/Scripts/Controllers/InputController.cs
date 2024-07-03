using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private BrickUi[] bricks;
        private Sound sound;

        public static readonly Dictionary<KeyCode, int> keysIndexes = new Dictionary<KeyCode, int>()
        {
            { KeyCode.Space, 0},
            { KeyCode.Alpha3, 1},
            { KeyCode.Q, 2},
            { KeyCode.Alpha4 ,3},
            { KeyCode.X, 4},
            { KeyCode.E, 5},
            { KeyCode.R, 6},
            { KeyCode.W, 7},
            { KeyCode.Alpha2, 8},
            { KeyCode.S, 9}
        };

        private void Start()
        {
            sound = GetComponent<Sound>();
        }

        private void Update()
        {
            for (int i = 0; i < bricks.Length; i++)
            {
                for (int j = 0; j < bricks[i].keys.Length; j++)
                {
                    if (Input.GetKeyDown(bricks[i].keys[j]))
                    {
                        sound.PlaySound(keysIndexes[bricks[i].keys[j]]);
                        bricks[i].Check(bricks[i].keys[j]);
                    }
                }
            }
        }

    }
}
