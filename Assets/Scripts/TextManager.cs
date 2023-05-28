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

    [SerializeField] private GameObject _enterBedText, _pickUpList, _leaveRoomText;
    private TMPro.TextMeshProUGUI _interactText, _pickUpText;
    
    private void Awake() 
    {
        _instance = this;
        _interactText = GetComponent<TMPro.TextMeshProUGUI>();
        _pickUpText = _pickUpList.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        if (_pickUpText == null)
            Debug.LogError("Pick Up Text is NULL!");
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
}
