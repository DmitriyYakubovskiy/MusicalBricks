using Assets.Scripts;
using Assets.Scripts.Enums;
using System;

[Serializable]
public class BrickModel
{
    public ColorBrick color;
    public TypeBrick type;

    public static explicit operator BrickModel(string str)
    {
        BrickModel brick = new BrickModel();
        if (str == "m")
        {
            brick.color = ColorBrick.Red;
            brick.type = TypeBrick.None;
        }
        else if (str == "hhp")
        {
            brick.color = ColorBrick.Yellow;
            brick.type = TypeBrick.Square;
        }
        else if (str == "hho")
        {
            brick.color = ColorBrick.Yellow;
            brick.type = TypeBrick.CircleCross;
        }
        else if (str == "hhz")
        {
            brick.color = ColorBrick.Yellow;
            brick.type = TypeBrick.Cross;
        }
        else if (str == "t1")
        {
            brick.color = ColorBrick.Yellow;
            brick.type = TypeBrick.None;
        }
        else if (str == "k")
        {
            brick.color = ColorBrick.Blue;
            brick.type = TypeBrick.CircleCrossLine;
        }
        else if (str == "t2")
        {
            brick.color = ColorBrick.Blue;
            brick.type = TypeBrick.None;
        }
        else if (str == "r")
        {
            brick.color = ColorBrick.Green;
            brick.type = TypeBrick.CircleCrossLine;
        }
        else if (str == "t3")
        {
            brick.color = ColorBrick.Green;
            brick.type = TypeBrick.None;
        }
        else
        {
            brick.type = TypeBrick.Null;
        }

        return brick;
    }
}
