using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int levelnumber;

    public List<LevelBlock> levelBlocks;
}

[System.Serializable]

public class LevelBlock
{
   public string blockTag;

   public Vector2 blockCoordinate;
}
