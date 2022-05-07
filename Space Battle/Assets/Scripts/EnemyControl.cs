using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject ships;
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new EnemyDefenseState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
