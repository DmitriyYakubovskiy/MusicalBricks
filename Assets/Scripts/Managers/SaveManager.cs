using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SaveManager:MonoBehaviour
    {
        private List<MapModel> maps;
        private const string path = "Saves";

        public List<MapModel> Maps => maps;

        private void Awake()
        {
            if (!File.Exists(path)) Directory.CreateDirectory(path);
            maps = new List<MapModel>();
            LoadData();
        }

        public MapModel GetMap(string name)
        {
            return maps.Find(x => x.name == name);
        }

        private void LoadData()
        {
            string[] fileNames = Directory.GetFiles(path, "*.txt");
            if (fileNames.Length == 0) return;

            for (int i = 0; i < fileNames.Length; i++)
            {
                MapModel map = new MapModel();
                try
                {
                    string file = File.ReadAllText($"{fileNames[i]}");
                    string[] lines = file.Split("\n");
                    map.name = lines[0].Split(" ")[0];
                    map.speed = (float)Convert.ToDouble(lines[0].Split(" ")[1]);
                    for (int j = 1; j < lines.Length; j++)
                    {
                        if (lines[j].Split("|").Count() <= 1) continue;
                        BlockModel block = new BlockModel();
                        string[] rows = lines[j].Split("|");
                        block.speedDelay = float.Parse(rows[0], CultureInfo.InvariantCulture);
                        for (int k = 1; k < 5; k++)
                        {
                            RowModel row = new RowModel();
                            string[] bricks = rows[k].Split(" ");
                            for (int l = 0; l < 4; l++)
                            {
                                row.bricks[l] = (BrickModel)bricks[l];
                            }
                            if (bricks.Count() > 4) row.line = bricks[4] == "by";
                            block.rows[k - 1] = row;
                        }
                        map.blocks.Add(block);
                    }
                    maps.Add(map);
                }

                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                }
            }
        }
    }
}
