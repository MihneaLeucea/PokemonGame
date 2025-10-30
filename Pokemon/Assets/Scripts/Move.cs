using UnityEngine;

public class Move
{
    public MoveBase Base { get; }

    public int PP { get; set; }

    public Move(MoveBase pBase, int pp)
    {
        Base = pBase;
        PP = pp;
    }

    public Move(MoveBase @base)
    {
        Base = @base;
    }
}
