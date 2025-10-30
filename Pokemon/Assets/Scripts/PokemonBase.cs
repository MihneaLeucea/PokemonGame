using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")]
public class PokemonBase : ScriptableObject
{
    // renamed to avoid shadowing UnityEngine.Object.name
    [SerializeField] private string pokemonName;
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private PokemonType type;
    [SerializeField] private int maxHp;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private List<LearneableMove> learnableMoves;

    public string Name => pokemonName;

    public Sprite FrontSprite => frontSprite;

    // <-- FIX: return the backing field, not call the property itself
    public Sprite BackSprite => backSprite;

    public PokemonType Type => type;

    public int MaxHp => maxHp;

    public int Attack => attack;

    public int Defense => defense;

    // Return the list reference; consider returning a copy if you want immutability
    public List<LearneableMove> LearneableMove => learnableMoves;


    public enum PokemonType
    {
        Normal,
        None,
        Grass,
        Fire,
        Water
    }
}

[System.Serializable]
public class LearneableMove
{
    [SerializeField] private MoveBase moveBase;
    [SerializeField] private int level;

    public MoveBase Base => moveBase;
    public int Level => level;
}
