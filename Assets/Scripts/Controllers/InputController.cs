using MidiJack;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private BrickUi[] bricks;
        private Sound sound;

        public static readonly Dictionary<KeyCode, int> keyboardIndexes = new Dictionary<KeyCode, int>()
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

        public static readonly Dictionary<int, int> keyDrumIndexes = new Dictionary<int, int>()
        {
            {0, 36},
            {1, 49},
            {2 , 38},
            { 3 , 51},
            { 4 , 48},
            { 5 , 45},
            { 6 , 43},
            { 7 , 42},
            { 8 , 46},
            { 9 , 44}
        };

        private void Start()
        {
            sound = GetComponent<Sound>();
        }

        private void Update()
        {
            for(int i=0; i < 10; i++)
            {
                int index = keyDrumIndexes[i];
                if (MidiMaster.GetKeyDown(MidiChannel.Ch10, index) || MidiMaster.GetKeyUp(MidiChannel.Ch10, index))
                {
                    for(int j = 0; j < bricks.Length; j++)
                    {
                        foreach(var key in keyboardIndexes.Keys)
                        {
                            if (keyboardIndexes[key]== i)
                            {
                                bricks[j].Check(key);
                                if (i == 7)
                                {
                                    sound.PlaySound(i, 0.2f);
                                }
                                else
                                {
                                    sound.PlaySound(i, 0.4f);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < bricks.Length; i++)
            {
                for (int j = 0; j < bricks[i].keys.Length; j++)
                {
                    if (Input.GetKeyDown(bricks[i].keys[j]))
                    {
                        sound.PlaySound(keyboardIndexes[bricks[i].keys[j]]);
                        bricks[i].Check(bricks[i].keys[j]);
                    }
                }
            }
        }

    }
}
