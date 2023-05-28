using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressChecker : MonoBehaviour
{
    [SerializeField] //objects about to hide or reveal or relocate
    private GameObject _3dCloset, _3dGameConsole, 
    _2dCloset, _2dGameConsole;
    
    private bool closetCollected, gameConsoleCollected;
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.HasCloset && !closetCollected)
        {
            _3dCloset.SetActive(true);
            _2dCloset.SetActive(false);
            closetCollected = true;
        }

        if(GameManager.Instance.HasGameConsole && !gameConsoleCollected)
        {
            _3dGameConsole.SetActive(true);
            _2dGameConsole.SetActive(false);
            gameConsoleCollected = true;
        }

        if(!GameManager.Instance.HasCloset && !GameManager.Instance.HasGameConsole)
        {
            _3dCloset.SetActive(false);
            _3dGameConsole.SetActive(false);
            _2dCloset.SetActive(true);
            _2dGameConsole.SetActive(true);
            closetCollected = false;
            gameConsoleCollected = false;
        }
    }
}
