using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public float G;
    public GameObject pivotObject;
    public float xRot, yRot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        Velocity();
        
    }

    void Velocity()
    {
        float m = pivotObject.GetComponent<Rigidbody>().mass;
        float r = Vector3.Distance(pivotObject.transform.position, this.transform.position);

        transform.RotateAround(pivotObject.transform.position, new Vector3(xRot, yRot, 0), Mathf.Sqrt((G * m) / r) * Time.deltaTime);

    }
}
