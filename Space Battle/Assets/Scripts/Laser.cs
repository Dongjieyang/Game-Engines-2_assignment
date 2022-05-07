using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
    
{
    public GameObject starSurface, starCorona, starLoops;
    public float speed = 20;
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
          starSurface .gameObject.SetActive(true);
          starCorona.gameObject.SetActive(true);
          starLoops.gameObject.SetActive(true);

        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
