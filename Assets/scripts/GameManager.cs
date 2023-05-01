using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentFloor = 2;
    public SaveLoadManager sl;
    public void Awake()
    {
        sl.loadGame();
    }
}

