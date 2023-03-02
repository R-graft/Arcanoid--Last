using UnityEngine;

[CreateAssetMenu(fileName = "PacksData", menuName = "Data/newPacksData")]
public class PacksData : ScriptableObject
{
    public Pack[] packsModels;
}
[System.Serializable]
public class Pack
{
    public string title;

    public int packIndex;

    public int startLevel;

    public int finishLevel;

    public int EndedLevel;

    public Sprite sprite;

    public bool isOpen;

    public bool isEnded;
}


