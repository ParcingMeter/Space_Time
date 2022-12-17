using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        // A flag variable to track the state of the UI
    public bool uiOpen = false;

    // The Text component used to display the fuel level
    public Text fuelText;

    // The Text component used to display a message when the ship runs out of fuel
    public Text outOfFuelText;

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

        // Start the fuel UI update coroutine
        StartCoroutine(UpdateFuelUI());
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space ship has any fuel left
        if (fuel > 0 && !uiOpen)
        {
            // Get the horizontal and vertical input axes
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // If the fuel level is above 0, disable the out of fuel text
            outOfFuelText.enabled = false;


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

            // Enable the out of fuel text
            outOfFuelText.enabled = true;
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

    // A coroutine that updates the fuel level display
    IEnumerator UpdateFuelUI()
    {
        while (true)
        {
            // Update the fuel level display
            fuelText.text = "Fuel: " + fuel.ToString("F1") + "%";

            // Wait for a few seconds before updating the display again
            yield return new WaitForSeconds(0.5f);
        }
    }
}



