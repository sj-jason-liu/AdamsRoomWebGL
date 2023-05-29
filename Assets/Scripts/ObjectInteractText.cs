using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractText : MonoBehaviour
{
    [SerializeField][TextArea] private string _interactText, _interactTextBack;
    [SerializeField][Range(0,1)] private int _3dObjectNumber;
    [SerializeField] private bool _is3dObjects;
    private bool _isDresserBack, _isGameBack;

    private void Update() 
    {
        _isDresserBack = GameManager.Instance.HasCloset;
        _isGameBack = GameManager.Instance.HasGameConsole;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch(_is3dObjects)
            {
                case true: //is 3D object
                    switch(_3dObjectNumber)
                    {
                        case 0: //is dresser
                            if(!_isDresserBack) //dresser not back yet
                            {
                                TextManager.Instance.Show3dInteractText(_interactText);
                            }
                            else //dresser is back
                            {
                                TextManager.Instance.Show3dInteractText(_interactTextBack);
                            }
                            break;
                        case 1: //is game console
                            if (!_isGameBack) //game not back yet
                            {
                                TextManager.Instance.Show3dInteractText(_interactText);
                            }
                            else //game is back
                            {
                                TextManager.Instance.Show3dInteractText(_interactTextBack);
                            }
                            break;
                    }
                    break;
                case false: //is 2D object
                    TextManager.Instance.ShowInteractText(_interactText);
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (_is3dObjects)
            {
                case true: //is 3D object
                    switch (_3dObjectNumber)
                    {
                        case 0: //is dresser
                            if (!_isDresserBack) //dresser not back yet
                            {
                                TextManager.Instance.Hide3dInteractText(_interactText);
                            }
                            else //dresser is back
                            {
                                TextManager.Instance.Hide3dInteractText(_interactTextBack);
                            }
                            break;
                        case 1: //is game console
                            if (!_isGameBack) //game not back yet
                            {
                                TextManager.Instance.Hide3dInteractText(_interactText);
                            }
                            else //game is back
                            {
                                TextManager.Instance.Hide3dInteractText(_interactTextBack);
                            }
                            break;
                    }
                    break;
                case false: //is 2D object
                    TextManager.Instance.ShowInteractText("");
                    break;
            }
        }
    }
}
