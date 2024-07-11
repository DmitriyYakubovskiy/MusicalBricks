using Assets.Scripts.Static;
using MidiJack;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private BrickUi[] bricks;
        private Sound sound;
        private NoteCollection noteCollection;

        private void Start()
        {
            noteCollection = new NoteCollection();
            sound = GetComponent<Sound>();
        }

        private void Update()
        {
            foreach(var note in noteCollection.Notes)
            {
                if (MidiDriver.Instance.GetKeyDown(MidiChannel.Ch10, note.NoteNumber) || MidiDriver.Instance.GetKeyUp(MidiChannel.Ch10, note.NoteNumber) || Input.GetKeyDown(note.Key))
                {
                    sound.PlaySound(note.Index, note.Volume);
                    for (int j = 0; j < bricks.Length; j++)
                    {
                        Debug.Log($"{note.Index} {note.Volume}");
                        bricks[j].Check(note.Key);
                    }
                }
            }
        }
    }
}
