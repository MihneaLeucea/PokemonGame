using UnityEngine;

public class Move
{
    public MoveBase Base { get; set; }

    public int Pp { get; set; }

    public Move(MoveBase pBase, int pp)
    {
        Base = pBase;
        Pp = pp;
    }

    public Move(MoveBase @base)
    {
        Base = @base;
    }
}
