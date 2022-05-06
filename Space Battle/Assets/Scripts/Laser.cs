using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
    
{
    public GameObject starSurface, starCorona, starLoops;
    public float speed = 20;
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Satr")
        {
          starSurface .gameObject.SetActive(true);
          starCorona.gameObject.SetActive(true);
          starLoops.gameObject.SetActive(true);

        }
    }
    void Start()
    {
        Destroy(this.gameObject, 20);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
