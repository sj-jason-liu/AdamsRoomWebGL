using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTo2D : MonoBehaviour
{
    private bool cutsceneHasPlayed, hasPressedKey, hasEnterTrigger;
    [SerializeField]
    private GameObject goToBedCutscene, player2D, respawnPosition2D;

    private void FixedUpdate()
    {
        if (hasEnterTrigger) //detect pressing key when enter trigger
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPressedKey = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !GameManager.Instance.HasKey)
        {
            hasEnterTrigger = true;
            TextManager.Instance.EnterBedText(hasEnterTrigger);
            if (hasPressedKey)
            {
                TextManager.Instance.EnterBedText(false);
                GameManager.Instance.PlayerCanControl = false; //disable player control
                UIManager.Instance.MusicFadeOut();//music fade out
                if (!cutsceneHasPlayed)
                {
                    goToBedCutscene.SetActive(true);
                    cutsceneHasPlayed = true;
                }
                UIManager.Instance.WhiteOut();
                player2D.transform.position = respawnPosition2D.transform.position; //reposition 2D player to start point
                GameManager.Instance.Player2DCanControl = true;
                Invoke("Switching", 5f); //switch to 2D scene after 3 seconds- UIManager
                hasEnterTrigger = false;
                hasPressedKey = false;
            }           
        }   
    }

    void Switching()
    {
        Camera.main.orthographic = true;
        UIManager.Instance.MusicFadeIn(false); //change music to 2d and fade in
        UIManager.Instance.SwitchTo2D();
        UIManager.Instance.WhiteIn();
        goToBedCutscene.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            TextManager.Instance.EnterBedText(false);
        }
    }
}
