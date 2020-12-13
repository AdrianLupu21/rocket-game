using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    Transform target;

    [SerializeField]
    float acceleration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float accelerationSpeed = acceleration;
        float yPosition = transform.position.y;
      if (yPosition > 110)
        {
            rigidBody.AddRelativeForce(Vector3.down * accelerationSpeed);
        }
      else if(yPosition < 0)
        {
            rigidBody.AddRelativeForce(Vector3.up * accelerationSpeed);
        }
        else
        {
            rigidBody.AddRelativeForce(Vector3.up * accelerationSpeed);
        }

    }
}
