using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // The UI canvas game object
    public GameObject uiCanvas;

    // The panel or group of buttons that contain the options
    public GameObject optionsPanel;

    // A flag variable to track the state of the UI
    public bool uiOpen = false;

    // The close button
    public Button closeButton;

    // The "Buy Fuel" button
    public Button buyFuelButton;

    // The "Visit Pub" button
    public Button visitPubButton;

    // The "Purchase Supplies and Upgrades" button
    public Button purchaseSuppliesAndUpgradesButton;

    // The "Cancel" button
    public Button cancelButton;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the UI canvas and the options panel by default
        uiCanvas.SetActive(false);
        optionsPanel.SetActive(false);

        // Add a listener to the onClick event of the close button, calling the CloseUI function when the button is clicked
        closeButton.onClick.AddListener(CloseUI);

        // Add listeners to the onClick events of the other buttons, calling the appropriate function when the button is clicked
        buyFuelButton.onClick.AddListener(BuyFuel);
        visitPubButton.onClick.AddListener(VisitPub);
        purchaseSuppliesAndUpgradesButton.onClick.AddListener(PurchaseSuppliesAndUpgrades);
        cancelButton.onClick.AddListener(Cancel);
    }

    // A function to open the UI
    public void OpenUI()
    {
        // Enable the UI canvas and the options panel
        uiCanvas.SetActive(true);
        optionsPanel.SetActive(true);

        // Pause the game by setting the Time.timeScale property to 0
        Time.timeScale = 0;

        // Set the flag variable to true
        uiOpen = true;
    }

    // A function to close the UI
    public void CloseUI()
    {
        // Disable the UI canvas and the options panel
        uiCanvas.SetActive(false);
        optionsPanel.SetActive(false);

        // Unpause the game by setting the Time.timeScale property back to 1
        Time.timeScale = 1;

        // Set the flag variable to false
        uiOpen = false;
    }

    // A function to handle the "Buy Fuel" option
    public void BuyFuel()
    {
        // Add the necessary logic to purchase fuel here...

        // Close the UI
        CloseUI();
    }

    // A function to handle the "Visit Pub" option
    public void VisitPub()
    {
        // Add the necessary logic to visit the pub here...

        // Close the UI
        CloseUI();
    }

    // A function to handle the "Purchase Supplies and Upgrades" option
    public void PurchaseSuppliesAndUpgrades()
    {
    // Add the necessary logic to purchase supplies and upgrades here...

        // Close the UI
        CloseUI();
    }

    // A function to handle the "Cancel" option
    public void Cancel()
    {
        // Close the UI
        CloseUI();
    }
}
