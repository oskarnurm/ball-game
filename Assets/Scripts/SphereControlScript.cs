// Import some external libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Declare a new class, which inherits functionality from the parent class MonoBehaviour
public class SphereControlScript : MonoBehaviour
{
    public float forceFactor = 1.0f;
    public Text scoreUIText;
    private int pickupCounter;

    // Start is called before the first frame update 
    void Start()
    {
        pickupCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(xDir, 0, zDir);
        rigidBody.AddForce(force, ForceMode.Force);
        scoreUIText.text = "Score: " + pickupCounter;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickups")
        {
            // Get the pickupValue from the collided PickupScript
            int pickupValue = other.GetComponent<PickupScript>().GetPickupValue();

            // Add the pickupValue to the player's score
            pickupCounter += pickupValue;

            Debug.Log("Pickup Score: " + pickupCounter);
        }
    }


    public void IncrementPickupCounter()
    {
        pickupCounter++;
    }
    public int GetPickupCounter()
    {
        return pickupCounter;
    }
}