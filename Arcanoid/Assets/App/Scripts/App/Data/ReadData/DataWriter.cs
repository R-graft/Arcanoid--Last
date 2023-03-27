using System.IO;
using UnityEngine;

public class DataWriter<T>
{
    private T _dataFile;

    private string _savingFilePath;

    private string _resourcesPath = Application.dataPath + $"/App/Resources";

    public DataWriter(T dataFile, string savingFile)
    {
        _dataFile = dataFile;

        _savingFilePath = savingFile;
    }

    public void SaveFileToSystem()
    {
        var savePath = Application.persistentDataPath;

        if (Directory.Exists(savePath) && _dataFile != null)
        {
            string savingData = JsonUtility.ToJson(_dataFile);

            string saveFilePath = Application.persistentDataPath + _savingFilePath;

            File.WriteAllText(saveFilePath, savingData);
        }
        else
        {
            Debug.Log("Error save file");
        }
    }

    public void SaveFileToResources()
    {
        var savePath = _resourcesPath + _savingFilePath;

        if (_dataFile != null)
        {
            string savingData = JsonUtility.ToJson(_dataFile);

            File.WriteAllText(savePath, savingData);
        }
        else
        {
            Debug.Log("Error save file");
        }
    }
}
