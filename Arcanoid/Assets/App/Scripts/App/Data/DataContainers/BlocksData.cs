using UnityEngine;

[CreateAssetMenu(fileName = "BlocksData", menuName = "Data/newBlocksData")]
public class BlocksData : ScriptableObject
{
    public BlockType[] simpleTypes;

    public BlockType[] boostTypes;

    public BonusType[] parentBoostTypes;
}

[System.Serializable]
public class BlockType 
{
    public string type;

    public int healthCount;

    public Sprite sprite;

    public Block block;

    public Color effectColor;
}

[System.Serializable]
public class BonusType : BlockType
{
    public Sprite icon;

    public Bonus childBonus;
}
