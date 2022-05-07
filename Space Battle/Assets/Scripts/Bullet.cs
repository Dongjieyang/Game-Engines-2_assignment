using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject Explosion;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Explosion.gameObject.SetActive(true);

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