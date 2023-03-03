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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //forward
            actualSpeed += speed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //backward
            actualSpeed -= speed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //pivot left
            yaw = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
