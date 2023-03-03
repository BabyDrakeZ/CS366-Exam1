using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public float speed = 2;
    public float maxPos = 5;
    public Vector3 dir;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += dir * speed * Time.deltaTime;
        if (Vector3.Magnitude(this.transform.position - origin) > maxPos)
        {
            dir = (origin - this.transform.position).normalized;
        }
    }
}
