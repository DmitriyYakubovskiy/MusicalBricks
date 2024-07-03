using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MidiInputController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(Input.inputString);
            text.text = Input.inputString.ToString();
        }
    }

}
