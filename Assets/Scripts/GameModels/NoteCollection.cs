using Assets.Scripts.Enums;
using Assets.Scripts.GameModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Static
{
    public class NoteCollection
    {
        private List<Note> notes = new List<Note>()
        {
            new()
            {
                Index = 0,
                NoteName="Бас",
                Key=KeyCode.Space,
                NoteNumber=36,
                Type=TypeBrick.Line,
                Color=ColorBrick.None,
                Volume=1f
            },
            new()
            {
                Index = 1,
                NoteName="Крэш",
                Key=KeyCode.Alpha3,
                NoteNumber=49,
                Type=TypeBrick.CircleCrossLine,
                Color=ColorBrick.Blue,
                Volume=1f
            },
            new()
            {
                Index = 2,
                NoteName="Малый",
                Key=KeyCode.Q,
                NoteNumber=38,
                Type=TypeBrick.None,
                Color=ColorBrick.Red,
                Volume=1f
            },
            new()
            {
                Index = 3,
                NoteName="Райд",
                Key=KeyCode.Alpha4,
                NoteNumber=51,
                Type=TypeBrick.CircleCrossLine,
                Color=ColorBrick.Green,
                Volume=1f
            },
            new()
            {
                Index = 4,
                NoteName="Том 1",
                Key=KeyCode.X,
                NoteNumber=48,
                Type=TypeBrick.None,
                Color=ColorBrick.Yellow,
                Volume=1f
            },
            new()
            {
                Index = 5,
                NoteName="Том 2",
                Key=KeyCode.E,
                NoteNumber=45,
                Type=TypeBrick.None,
                Color=ColorBrick.Blue,
                Volume=1f
            },
            new()
            {
                Index = 6,
                NoteName="Том 3",
                Key=KeyCode.R,
                NoteNumber=43,
                Type=TypeBrick.None,
                Color=ColorBrick.Green,
                Volume=1f
            },
            new()
            {
                Index = 7,
                NoteName="Хайхет закрытый",
                Key=KeyCode.W,
                NoteNumber=42,
                Type=TypeBrick.Cross,
                Color=ColorBrick.Yellow,
                Volume=1f
            },
            new()
            {
                Index = 8,
                NoteName="Хайхет открытый",
                Key=KeyCode.Alpha2,
                NoteNumber=46,
                Type=TypeBrick.CircleCross,
                Color=ColorBrick.Yellow,
                Volume=1f
            },
            new()
            {
                Index = 9,
                NoteName="Хайхет педаль",
                Key=KeyCode.S,
                NoteNumber=44,
                Type=TypeBrick.Square,
                Color=ColorBrick.Yellow,
                Volume=1f
            }
        };
        private string path = "sounds_volume.txt";

        public List<Note> Notes => notes;

        public NoteCollection()
        {
            if (!File.Exists(path)) WriteFile();
            ReadFile();
        }

        private void WriteFile()
        {
            File.Create(path).Close();
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach(var note in notes) outputFile.WriteLine($"{note.NoteName}:{note.Volume}");
            }
        }

        private void ReadFile()
        {
            using (StreamReader inputFile = new StreamReader(path))
            {
                var lines = inputFile.ReadToEnd().Split("\n");
                foreach(var line in lines)
                {
                    if (String.IsNullOrEmpty(line)) continue;
                    string name = line.Split(":")[0];
                    float volume = float.Parse(line.Split(":")[1], CultureInfo.InvariantCulture);   
                    notes.Where(x => x.NoteName == name).FirstOrDefault().Volume = volume;
                }
            }
        }
    }
}
