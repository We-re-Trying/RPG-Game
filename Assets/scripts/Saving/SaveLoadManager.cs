using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class SaveLoadManager : MonoBehaviour
{
    private GameData gameData;
    public PlayerMovement max, lucia;
    public static SaveLoadManager instance { get; private set; }

    public void NewGame()
    {
        Debug.Log("Loading new game.");
        this.gameData = new GameData();
    }    

    public void saveGame()
    {
        Debug.Log("Saving game.");
        this.gameData = new GameData();
        gameData.maxLevel = max.level; gameData.luciaLevel = lucia.level;

        string json = JsonUtility.ToJson(gameData);

        File.WriteAllText(Application.persistentDataPath + "/savedGame.json", json.ToString());
    }

    public void loadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.json"))
        {
            Debug.Log("Loading game.");

            string jsonString = File.ReadAllText(Application.persistentDataPath + "/savedGame.json");

            gameData = JsonUtility.FromJson<GameData>(jsonString);

            max.level = gameData.maxLevel; lucia.level = gameData.luciaLevel;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one SaveLoadManager in scene.");
        }
        instance = this;
    }
}
