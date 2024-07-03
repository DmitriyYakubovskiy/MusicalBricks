using System;

[Serializable]
public class RowModel
{
    public BrickModel[] bricks = new BrickModel[4];
    public bool line = false;
}
