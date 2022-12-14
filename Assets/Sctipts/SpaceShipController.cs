using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RefuelStation;

public class SpaceShipController : MonoBehaviour
{
    // The static instance of the SpaceShipController
    public static SpaceShipController instance;

    // The speed at which the space ship will move
    public float speed = 1.0f;

    // The amount of fuel the space ship has
    public float fuel = 100.0f;

    // The Rigidbody component attached to the space ship game object
    public Rigidbody2D rb;

    // A flag indicating whether the space ship is refueling
    public bool isRefueling = false;

    // The Refuel() method refuels the space ship
    public void RefuelShip(float amount)
    {
        fuel += amount;
        isRefueling = true;
    }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // If there is no other instance of the SpaceShipController...
        if (instance == null)
        {
            // ...set this instance as the static instance...
            instance = this;
        }
        // ...otherwise...
        else
        {
            // ...destroy this instance because there can only be one static instance of the SpaceShipController.
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the space ship game object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space ship has any fuel left
        if (fuel > 0)
        {
            // Get the horizontal and vertical input axes
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate the force to apply to the Rigidbody based on the input axes
            Vector3 force = new Vector3(horizontalInput, verticalInput) * speed;

            // Apply the force to the Rigidbody
            rb.AddForce(force);

            // Calculate the fuel usage based on the current speed and the amount of time that has passed since the last frame
            float fuelUsage = rb.velocity.magnitude * Time.deltaTime;

            // Reduce the fuel level by the calculated fuel usage
            fuel -= fuelUsage;
        }
        else
        {
            // If the space ship has no fuel left, stop it from moving
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
        }
    }
    public void Refuel(float amount)
    {
        // Increase the fuel level by the specified amount
        fuel += amount;

        // Clamp the fuel level to the minimum and maximum allowed values
        fuel = Mathf.Clamp(fuel, 0.0f, 100.0f);
    }

    public void Stop()
    {
        // Method implementation goes here...
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0.0f;
    }



}



