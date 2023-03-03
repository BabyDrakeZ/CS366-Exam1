using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPMove : MonoBehaviour
{
    public float speed = 5;
    public float maxSpeed = 10;
    public float rotationSpeed = 10;
    public float lerpConstant = 0.5f;

    private float actualSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yaw = 0;
        if (Input.GetKey(KeyCode.W))
        {
            //forward
            actualSpeed += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //backward
            actualSpeed -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //pivot left
            yaw = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //pivot right
            yaw = 1;
        }
        actualSpeed = Mathf.Clamp(actualSpeed, -maxSpeed, maxSpeed);
        actualSpeed = Mathf.Lerp(actualSpeed, 0, lerpConstant);
        transform.Rotate(0, rotationSpeed * Time.deltaTime * yaw, 0);
        transform.position += transform.forward * actualSpeed * Time.deltaTime;
    }
}
