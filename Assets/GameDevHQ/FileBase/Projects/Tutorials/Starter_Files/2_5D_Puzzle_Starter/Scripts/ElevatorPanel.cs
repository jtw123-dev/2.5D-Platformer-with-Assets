using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    private MeshRenderer _renderer;
    [SerializeField]private int _requiredAmount;
    private Elevator _elevator;
    private bool _isTriggered;
    private Player _player;
    [SerializeField]private bool _elevatorCalled;
    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        if (_elevator==null)
        {
            Debug.LogError("elevator is null");
        }
        _renderer = GameObject.Find("Call_Button").GetComponent<MeshRenderer>();
        if (_renderer==null)
        {
            Debug.LogError("renderer is null");
        }
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player==null)
        {
            Debug.LogError("player is null");
        }
    }
    private void Update()
    {
        if (_isTriggered==true)
        {
            if (Input.GetKeyDown(KeyCode.E) && _player.GetComponent<Player>().CoinCount() >= _requiredAmount)
            {
                if (_elevatorCalled==true)
                {
                    _renderer.material.color = Color.red;                 
                }
                else
                {
                    _elevatorCalled = true;
                    _renderer.material.color = Color.blue;                 
                }
                _elevator.CallElevator();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            _isTriggered = true;
        }
    }
}
