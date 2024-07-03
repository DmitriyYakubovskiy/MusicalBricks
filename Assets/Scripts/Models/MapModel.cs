using System;
using System.Collections.Generic;

[Serializable]
public class MapModel
{
    public List<BlockModel> blocks = new List<BlockModel>();
    public float speed;
    public string name;
}
