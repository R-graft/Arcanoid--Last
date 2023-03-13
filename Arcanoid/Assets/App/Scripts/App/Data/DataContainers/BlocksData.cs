using UnityEngine;

[CreateAssetMenu(fileName = "BlocksData", menuName = "Data/newBlocksData")]
public class BlocksData : ScriptableObject
{
    public SimpleType[] simpleTypes;

    public BoostType[] boostTypes;

    public Bonus[] parentBoostTypes;
}

[System.Serializable]
public class SimpleType
{
    public string type;

    public int poolsize;

    public int healthCount;

    public Sprite sprite;

    public Block block;
}

[System.Serializable]
public class BoostType : SimpleType
{
    public int damage;
}

[System.Serializable]
public class BonusType
{
    public Bonus blockBonus;
}

