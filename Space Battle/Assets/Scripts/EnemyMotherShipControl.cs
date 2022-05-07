using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotherShipControl : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new AbsorbState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
