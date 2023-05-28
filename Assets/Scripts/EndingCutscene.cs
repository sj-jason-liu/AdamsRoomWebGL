using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject _endingCutscene, _3dPlayer, _respawnPosition;

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
        if(other.tag == "Player" && GameManager.Instance.HasKey)
        {
            hasEnterTrigger = true;
            TextManager.Instance.LeavingRoomText(hasEnterTrigger);
            if (hasPressedKey)
            {
                hasPressedKey = false;
                UIManager.Instance.StopMusic();
                TextManager.Instance.LeavingRoomText(hasPressedKey);
                GameManager.Instance.PlayerCanControl = false;
                _3dPlayer.SetActive(false);
                _endingCutscene.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                _3dPlayer.transform.position = _respawnPosition.transform.position;
                _3dPlayer.transform.rotation = _respawnPosition.transform.rotation;
                GameManager.Instance.ResetGame(); //reset all bool from GameManager                
            }
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            TextManager.Instance.LeavingRoomText(false);
        }
    }
}
