using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB, _parent2d;
    private Transform _selectedTarget;

    [SerializeField][Range(0, 1)]
    private int _platformNum;

    private bool _onward;
    private bool _platformEnabled;

    // Update is called once per frame
    void FixedUpdate()
    {
        //matching platform to responding GameManager bool
        switch(_platformNum) 
        {
            case 0:
                _platformEnabled = GameManager.Instance.HasCloset;
                break;
            case 1:
                _platformEnabled = GameManager.Instance.HasGameConsole;
                break;
        }

        //start moving when enable
        if(_platformEnabled)
            MovingPattern();
    }

    private void MovingPattern()
    {
        switch (_onward)
        {
            case true:
                _selectedTarget = _targetB;
                break;

            case false:
                _selectedTarget = _targetA;
                break;
        }

        transform.position =
            Vector3.MoveTowards(transform.position, _selectedTarget.position, Time.deltaTime);

        if (transform.position == _targetA.position || transform.position == _targetB.position)
            _onward = !_onward;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //        other.transform.parent = transform;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //        other.transform.parent = _parent2d.transform;
    //}

    public void ResetPlatform()
    {
        transform.position = _targetB.position;
    }
}
