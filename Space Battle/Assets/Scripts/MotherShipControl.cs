using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipControl : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Enemy;
    public GameObject laser;
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new PursueState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
