using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform _targetA, _targetB;
    private float _speed = 3;
    [SerializeField]private bool _goingDown,_goingUp;

    public void CallElevator()
    {
        if (transform.position == _targetA.position)
        {
            _goingDown = true;
        }
        else if (transform.position==_targetB.position)
        {
            _goingUp = true;
            _goingDown = false;
        }
    }
    private void FixedUpdate()
    {
        if (_goingDown==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }      
        else if (_goingUp==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
