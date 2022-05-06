using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public int enemyCountdown = 5;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Destroy(other.gameObject);
            enemyCountdown--;
        }
    }
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}