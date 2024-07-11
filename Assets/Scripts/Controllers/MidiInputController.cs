using Assets.Scripts.GameModels;
using MidiJack;
using System;
using TMPro;
using UnityEngine;

public class MidiInputController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    private void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            if (MidiDriver.Instance.GetKeyDown(MidiChannel.Ch10, i) || MidiDriver.Instance.GetKeyUp(MidiChannel.Ch10, i))
            {
                Debug.Log(i);
                text.text = i.ToString();
            }
        }
    }

}
