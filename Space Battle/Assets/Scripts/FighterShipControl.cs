using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterShipControl : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Enemy;
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new FighterPursueState());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
