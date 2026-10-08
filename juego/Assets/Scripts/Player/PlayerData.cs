using UnityEngine;
public enum Profile
{
    Strength,
    Charisma,
    Defense,
    Intelligence
}
public class PlayerData
{
    public Profile CharacterClass {  get; private set; }

    public int InitialHealth { get; private set; }

    public int Strength { get; private set; }

    public int Charisma { get; private set; }
    
    public int Defense { get; private set; }

    public int Intelligence { get; private set; }

    public PlayerData(
        Profile characterClass,
        int initialHealth,
        int strength,
        int charisma,
        int defense,
        int intelligence
        )
    {
        CharacterClass = characterClass;
        InitialHealth = initialHealth;
        Strength = strength;
        Charisma = charisma;
        Defense = defense;
        Intelligence = intelligence;
    }
}
