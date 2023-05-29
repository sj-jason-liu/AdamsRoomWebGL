using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private static TextManager _instance;
    public static TextManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("TextManager is NULL!");
            return _instance;
        }
    }

    [SerializeField] private GameObject _enterBedText, _pickUpList, _leaveRoomText, _3dInteractCanvasGroup;
    private TMPro.TextMeshProUGUI _interactText, _pickUpText;
    [SerializeField] private TMPro.TextMeshProUGUI _3dInteractText;
    private CanvasGroup _canvasGroup;

    private bool _isFadeIn;

    private float _3dInteractCanvasGroupAlpha;
    
    private void Awake() 
    {
        _instance = this;
        _interactText = GetComponent<TMPro.TextMeshProUGUI>();
        _pickUpText = _pickUpList.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        if (_pickUpText == null)
            Debug.LogError("Pick Up Text is NULL!");
        _canvasGroup = _3dInteractCanvasGroup.GetComponent<CanvasGroup>();
    }

    private void FixedUpdate() 
    {
        if(_isFadeIn)
        {
            _canvasGroup.alpha += Time.deltaTime * 2f;
        }
        else
        {
            _canvasGroup.alpha -= Time.deltaTime * 2f;
        }
    }

    public void EnterBedText(bool active)
    {
        if(GameManager.Instance.PlayerCanControl)
            _enterBedText.SetActive(active);
    }

    public void LeavingRoomText(bool active)
    {
        if (GameManager.Instance.HasKey)
            _leaveRoomText.SetActive(active);

    }

    public void ShowInteractText(string textContent) //objects interactive text
    {
        _interactText.text = textContent;
    }

    public void ShowTargetsText(string textContent) //2D pick up list texts
    {
        _pickUpText.text = textContent;
    }

    public void Show3dInteractText(string text)
    {
        //replace text with object string
        //play alpha animation from 0 to 1
        _3dInteractText.text = text;
        _isFadeIn = true;
    }

    public void Hide3dInteractText(string text)
    {
        //replace text with object string
        //play alpha animation from 1 to 0
        _3dInteractText.text = text;
        _isFadeIn = false;
    }
}
