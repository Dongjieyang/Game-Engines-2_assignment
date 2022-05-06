using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3 : MonoBehaviour
{
    public float rotSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, rotSpeed * Time.deltaTime);
    }
}
