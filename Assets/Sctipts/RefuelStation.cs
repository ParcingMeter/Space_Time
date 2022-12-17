using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpaceShipController; // Add this line to include the SpaceShipController class

public class RefuelStation : MonoBehaviour
{
    // The space ship controller script attached to the space ship game object
    public SpaceShipController shipController;

    // The amount of fuel to add to the space ship when refueling
    public float refuelAmount = 10.0f;

    // The range at which the space ship can refuel
    public float refuelRange = 10.0f;

    // The UIController script attached to the UI canvas game object
    public UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space ship is within range of the refuel station
        if (Vector3.Distance(transform.position, shipController.transform.position) <= refuelRange)
        {
            // Check if the "E" key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Check if the space ship is already refueling
                if (!shipController.isRefueling)
                {
                    // Stop the space ship
                    shipController.Stop();

                    // Refuel the space ship
                    shipController.Refuel(refuelAmount);

                    // Open the UI
                    uiController.OpenUI();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // Calculate the refuel range
        float refuelRange = 2.0f;

        // Draw the refuel range using Gizmos.DrawWireSphere()
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, refuelRange);
    }
}