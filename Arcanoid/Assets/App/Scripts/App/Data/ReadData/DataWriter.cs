using System.IO;
using UnityEngine;

public class DataWriter<T>
{
    private T _dataFile;

    private string _savingFile;

    public DataWriter(T dataFile, string savingFile)
    {
        _dataFile = dataFile;

        _savingFile = savingFile;
    }

    public void SaveFileToSystem()
    {
        var savePath = Application.persistentDataPath;

        if (Directory.Exists(savePath) && _dataFile != null)
        {
            string savingData = JsonUtility.ToJson(_dataFile);

            string saveFilePath = Application.persistentDataPath + _savingFile;

            File.WriteAllText(saveFilePath, savingData);
        }
        else
        {
            Debug.Log("Error save file");
        }
    }

    public void SaveFileToResources()
    {
        var savePath = Application.dataPath;

        if (Directory.Exists(savePath) && _dataFile != null)
        {
            string savingData = JsonUtility.ToJson(_dataFile);

            string saveFilePath = Application.persistentDataPath + _savingFile;

            File.WriteAllText(saveFilePath, savingData);
        }
        else
        {
            Debug.Log("Error save file");
        }
    }
}
