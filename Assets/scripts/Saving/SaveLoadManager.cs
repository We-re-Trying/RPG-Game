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

    public void newGame()
    {
        Debug.Log("Loading new game.");
        this.gameData = new GameData();
    }    

    public void saveGame()
    {
        Debug.Log("Saving game.");
        this.gameData = new GameData();
        //gameData.inventory = inventory.inventory;
        //gameData.partyGold = inventory.gold; gameData.currentFloor = gameManager.currentFloor;
        gameData.maxLevel = max.level; gameData.maxExp = max.exp; gameData.maxMaxHealth = max.maxHealth; 
        gameData.maxCurrentHealth = max.currentHealth; gameData.maxStr = max.str; gameData.luciaLevel = lucia.level; 
        gameData.luciaExp = lucia.exp; gameData.luciaMaxHealth = lucia.maxHealth; 
        gameData.luciaCurrentHealth = lucia.currentHealth; gameData.luciaStr = lucia.str; gameData.luciaLevel = lucia.level;

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

            //inventory.inventory = gameData.inventory;
            //inventory.gold = gameData.partyGold; gameManager.currentFloor = gameData.currentFloor;
            max.level = gameData.maxLevel; max.exp = gameData.maxExp; max.maxHealth = gameData.maxMaxHealth; 
            max.currentHealth = gameData.maxCurrentHealth; max.str = gameData.maxStr; lucia.level = gameData.luciaLevel;
            lucia.exp = gameData.luciaExp; lucia.maxHealth = gameData.luciaMaxHealth;
            lucia.currentHealth = gameData.luciaCurrentHealth; lucia.str = gameData.luciaStr; lucia.level = gameData.luciaLevel;
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
    public static SaveLoadManager GetInstance()
    {
        return instance;
    }
}
