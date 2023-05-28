using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTo3D : MonoBehaviour
{
    [SerializeField]
    private int _objectNum;

    private bool hasPressedKey, hasEnterTrigger;

    private void Update() 
    {
        if(hasEnterTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPressedKey = true;
            }
        }
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player")
        {
            hasEnterTrigger = true;
            if (hasPressedKey)
            {
                switch (_objectNum)
                {
                    case 0: //closet
                        GameManager.Instance.HasCloset = true;
                        break;
                    case 1: //game console
                        GameManager.Instance.HasGameConsole = true;
                        break;
                    case 2: //key
                        GameManager.Instance.HasKey = true;
                        break;
                }
                UIManager.Instance.MusicFadeOut(); //music fade out
                GameManager.Instance.Player2DCanControl = false;
                TextManager.Instance.ShowInteractText("");
                UIManager.Instance.WhiteOut();
                Invoke("Switching", 3f);
                GameManager.Instance.PlayerCanControl = true;
                hasEnterTrigger = false;
                hasPressedKey = false;
            }           
        }    
    }

    void Switching()
    {
        Camera.main.orthographic = false;
        UIManager.Instance.MusicFadeIn(true); //change music to 3d and fade in
        UIManager.Instance.SwitchTo3D();
        UIManager.Instance.WhiteIn();
    }
}
