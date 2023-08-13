using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameModes
{
    Run,
    Fly
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameModes gameMode;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
