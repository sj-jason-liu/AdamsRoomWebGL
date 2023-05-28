using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is NULL!");
            }
            return _instance;
        }
    }

    [SerializeField]
    private bool _debugMode, _debugCloset, _debugGame, _debugKey, _debugControl2D, _debugControl3D;

    private void Awake()
    {
        _instance = this;
        ResetGame();
    }

    private void Update()
    {
        if (_debugMode)
        {
            HasCloset = _debugCloset;
            HasGameConsole = _debugGame;
            HasKey = _debugKey;
            Player2DCanControl = _debugControl2D;
            PlayerCanControl = _debugControl3D;
        }       
    }

    public bool HasCloset { get; set; }
    public bool HasGameConsole { get; set; }
    public bool HasKey { get; set; }

    public bool PlayerCanControl { get; set;}
    public bool Player2DCanControl { get; set; }

    public void ResetGame()
    {
        HasCloset = false;
        HasGameConsole = false;
        HasKey = false;
        PlayerCanControl = false;
        Player2DCanControl = false;
    }
}
