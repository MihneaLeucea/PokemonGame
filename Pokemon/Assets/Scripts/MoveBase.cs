using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name
    {
        get {  return name; }
    }

    public PokemonType Type
    {
        get { return type; }
    }

    public int Power
    {
        get { return power; }
    }

    public int Accuracy
    {
        get { return accuracy; }
    }

    public int Pp
    {
        get { return pp; }
    }

    public enum PokemonType
    {
        Normal,
        None,
        Grass,
        Fire,
        Water
    }

}


