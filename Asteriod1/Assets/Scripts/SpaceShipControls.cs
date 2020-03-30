using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;
    public float upperLimit;
    public float lowerLimit;
    public float leftLimit;
    public float rightLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check for input from keyboard
        thrustInput = Input.GetAxis("Vertical"); // only positive now foward only
        turnInput = Input.GetAxis("Horizontal"); // negative or positive rotation

        //screen wrapping
        Vector2 newPosition = transform.position;
        if (transform.position.y > upperLimit)
        {
            newPosition.y = lowerLimit;
        }
        if (transform.position.y < lowerLimit)
        {
            newPosition.y = upperLimit;
        }
        transform.position = newPosition;
        if (transform.position.x > rightLimit)
        {
            newPosition.x = leftLimit;
        }
        if (transform.position.x < leftLimit)
        {
            newPosition.x = rightLimit;
        }
        transform.position = newPosition;
    }

    private void FixedUpdate() //more accurate for physics
    {
        rb.AddRelativeForce(Vector2.up * thrustInput); // addRelativeForce will keep it moving foward
        rb.AddTorque(-turnInput); // lets us turn - revers direction
    }
}
