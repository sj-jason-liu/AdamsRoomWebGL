using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractText : MonoBehaviour
{
    [SerializeField] private string _interactText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TextManager.Instance.ShowInteractText(_interactText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TextManager.Instance.ShowInteractText("");
        }
    }
}
