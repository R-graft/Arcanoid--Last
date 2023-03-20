using UnityEngine;

[CreateAssetMenu(fileName = "PacksData", menuName = "Data/newPacksData")]
public class PacksData : ScriptableObject
{
    public Pack[] packsModels;
}
[System.Serializable]
public class Pack
{
    [Header("progress")]
    public int EndedLevel;
    public bool isOpen;
    public bool isEnded;

    [Header("components")]
    public string title;

    public int packIndex;

    public int startLevel;

    public int finishLevel;

    public Sprite sprite;
}


