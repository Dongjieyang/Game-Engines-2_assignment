using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject Explosion;
    public GameObject absorb;
    public AudioClip explosionSound;
    public AudioSource audioSource;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Explosion.gameObject.SetActive(true);
            audioSource.PlayOneShot(explosionSound);
            absorb.gameObject.SetActive(false);

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