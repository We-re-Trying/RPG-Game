using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class SaveLoadManager : MonoBehaviour
{
    private GameData gameData;
    public GameManager gameManager;
    public PlayerMovement max, lucia;
    public Inventory inventory;
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
        saveInventory();

        gameData.partyGold = inventory.gold;
        gameData.currentFloor = gameManager.currentFloor;
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
            loadInventory();

            inventory.gold = gameData.partyGold;
            gameManager.currentFloor = gameData.currentFloor;
            max.level = gameData.maxLevel; max.exp = gameData.maxExp; max.maxHealth = gameData.maxMaxHealth; 
            max.currentHealth = gameData.maxCurrentHealth; max.str = gameData.maxStr;
            lucia.exp = gameData.luciaExp; lucia.maxHealth = gameData.luciaMaxHealth;
            lucia.currentHealth = gameData.luciaCurrentHealth; lucia.str = gameData.luciaStr; lucia.level = gameData.luciaLevel;
        }
    }

    public void saveInventory()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.txt");
        StreamWriter writer = new StreamWriter(filePath);

        foreach (string item in inventory.inventory)
        {
            writer.WriteLine(item);
        }

        writer.Close();
    }

    public void loadInventory()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.txt");
        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            List<string> loadedStrings = new List<string>(File.ReadAllLines(filePath));
            inventory.inventory = loadedStrings;
            reader.Close();
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
