using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.GameModels
{
    public class Note
    {
        public int Index { get; set; }
        public string NoteName { get; set; }
        public int NoteNumber { get; set; }
        public AudioClip Clip { get; set; }
        public KeyCode Key { get; set; }
        public TypeBrick Type { get; set; }
        public ColorBrick Color { get; set; }
        public float Volume { get; set; }
    }
}
