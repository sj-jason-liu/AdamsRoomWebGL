using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is NULL!");
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject _2dScene, _3dScene, _mainMenuPanel, _endingPanel, _whiteBG, _openingText;

    [SerializeField]
    private AudioClip _2dTheme, _3dTheme;
    
    private Animator animator;
    private AudioSource audioSource;

    private void Awake() 
    {
        _instance = this;
        animator = _whiteBG.GetComponent<Animator>();
        if(animator == null)
            Debug.LogError("Animator is NULL!");
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.LogError("AudioSource is NULL from UIManager!");
    }

    //Play white-in animation
    public void WhiteIn()
    {
        animator.SetTrigger("WhiteIn");
    }
    //Play white-out animation
    public void WhiteOut()
    {
        animator.SetTrigger("WhiteOut");
    }

    public void SwitchTo2D()
    {
        _3dScene.SetActive(false);
        _2dScene.SetActive(true);
    }

    public void SwitchTo3D()
    {
        _2dScene.SetActive(false);
        _3dScene.SetActive(true);
    }

    public void StartButton()
    {
        WhiteOut();
        Invoke("StartGame", 3f);
    }

    void StartGame()
    {
        StartCoroutine(StartGameRouting());     
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        _mainMenuPanel.SetActive(true);
        _endingPanel.SetActive(false);
    }

    public void MusicFadeOut()
    {
        StartCoroutine(AudioHelper.FadeOut(audioSource, 2.5f));
    }

    public void MusicFadeIn(bool from2D)
    {
        switch(from2D)
        {
            case true:
                audioSource.clip = _3dTheme;
                break;
            case false:
                audioSource.clip = _2dTheme;
                break;
        }
        StartCoroutine(AudioHelper.FadeIn(audioSource, 2.5f));
    }

    public void StopMusic()
    {
        StartCoroutine(AudioHelper.FadeOut(audioSource, 3f));
    }

    IEnumerator StartGameRouting()
    {
        _mainMenuPanel.SetActive(false);
        WhiteIn();
        audioSource.clip = _3dTheme;
        StartCoroutine(AudioHelper.FadeIn(audioSource, 3f));
        yield return new WaitForSeconds(3f);
        _openingText.GetComponent<Animator>().SetTrigger("Opening"); //play opening text animation
        yield return new WaitForSeconds(5f);
        GameManager.Instance.PlayerCanControl = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
