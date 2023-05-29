using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsTriggerText : MonoBehaviour
{
    private string _targetStringText, _target1Text, _target2Text;
    private string _target3Text = "<br>-Key";

    private void Update()
    {
        if(GameManager.Instance.HasCloset)
        {
            _target1Text = "<br><s>-Dresser</s>";
        }
        else
        {
            _target1Text = "<br>-Dresser";
        }

        if(GameManager.Instance.HasGameConsole)
        {
            _target2Text = "<br><s>-Game console</s>";
        }
        else
        {
            _target2Text = "<br>-Game console";
        }
        
        _targetStringText = "Pick-up Targets: " + _target1Text + _target2Text + _target3Text;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && GameManager.Instance.Player2DCanControl)
        {
            TextManager.Instance.ShowTargetsText(_targetStringText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            TextManager.Instance.ShowTargetsText("");
        }
    }
}
