using System.IO;
using UnityEngine;

public class DataReader<T>
{    
    private string _directory;
    public DataReader(string directory)
    {
        _directory = directory;
    }
    public T ReadFileFromResources()
    {
        var dataFile = Resources.Load<TextAsset>(_directory).ToString();

        if (dataFile != null)
        {
            return JsonUtility.FromJson<T>(dataFile);
        }

        Debug.Log("Error load file");

        return default;
    }

    public T ReadFileFromSystem()
    {
        var pathToFile = Application.persistentDataPath + _directory;

        if (File.Exists(pathToFile))
        {
            string dataFile = File.ReadAllText(pathToFile);

            return JsonUtility.FromJson<T>(dataFile);
        }

        Debug.Log("Error load file");

        return default;
    }
}
