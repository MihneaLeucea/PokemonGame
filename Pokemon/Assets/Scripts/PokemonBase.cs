using System;
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
    [SerializeField] private int speed;
    [SerializeField] private List<LearneableMove> learnableMoves;

    public string Name => pokemonName;

    public Sprite FrontSprite => frontSprite;

    // <-- FIX: return the backing field, not call the property itself
    public Sprite BackSprite => backSprite;

    public PokemonType Type => type;

    public int MaxHp => maxHp;

    public int Attack => attack;

    public int Defense => defense;
    
    public int Speed => speed;

    // Return the list reference; consider returning a copy if you want immutability
    public List<LearneableMove> LearneableMove => learnableMoves;


    
}

public enum PokemonType
{
    Normal,
    None,
    Grass,
    Fire,
    Water
}

[System.Serializable]
public class LearneableMove
{
    [SerializeField] private MoveBase moveBase;
    [SerializeField] private int level;

    public MoveBase Base => moveBase;
    public int Level => level;
}

public class typeChart
{
    static float[][] chart =
    {
        new float [] { 1f, 1f, 1f, 1f },
        new float [] { 1f, 0.5f, 0.5f, 2f },
        new float [] { 1f, 2f, 0.5f, 0.5f },
        new float [] { 1f, 0.5f, 2f, 0.5f }
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None)
            return 1f;

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        // Validate before indexing
        if (row < 0 || row >= chart.Length || col < 0 || col >= chart[row].Length)
        {
            Debug.LogWarning($"typeChart.GetEffectiveness: invalid type indices attack={attackType}({(int)attackType}), defense={defenseType}({(int)defenseType}). Returning 1f.");
            return 1f;
        }

        return chart[row][col];
    }


}
