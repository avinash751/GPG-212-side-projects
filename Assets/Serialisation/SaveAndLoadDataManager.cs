using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;


// the comments below  are assumptions of what these fucntions do after a lot of documenattion and tutorial watching 
public class SaveAndLoadDataManager : MonoBehaviour
{
    [SerializeField] Player gameDataObject;
    [SerializeField] string saveFileName;
    [SerializeField] string savePath;
    [SerializeField] bool saveInAssetsFolder;


    private void Start()
    {
        SetFilePath();
    }
    private void Update()
    {
        InputToSaveData();
        InputToLoadData();
    }

    public void InputToSaveData()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGameData();
        }
    }

    public void InputToLoadData()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGameData();
        }
    }
    public void SaveGameData()
    { 
       string saveData = JsonUtility.ToJson(gameDataObject.gameData);
       Debug.Log(saveData);
    

       using StreamWriter fileWriter = new StreamWriter(savePath); // makes a  file to the given path parameter
       fileWriter.WriteLine(saveData); // writes the jasonData to the file in the given save path;

    }

    public void LoadGameData()
    {
        using StreamReader fileReader = new StreamReader(savePath); // gets the file from the given file path 
        string jsonSaveData = fileReader.ReadToEnd(); // returns the jsondata from the file path to a string

        gameDataObject.gameData = JsonUtility.FromJson<GameData>(jsonSaveData); // converts json data to the object type specified 
        Debug.Log(gameDataObject.ToString());
    }

    public void SetFilePath()
    {
        if(!saveInAssetsFolder)
        {
            savePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + saveFileName + ".json"; // gives a path with file name  in your local app data folder
        }
        else
        {
            savePath = Application.dataPath + Path.AltDirectorySeparatorChar + saveFileName + ".json";  // gives a path with file name  in the assets folder of your unity project.
        }
        Debug.Log(savePath);    
    }

}
