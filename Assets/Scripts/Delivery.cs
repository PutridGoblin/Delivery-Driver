using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package") {

            hasPackage = true;
            Debug.Log("Package picked up!");

        } else if (other.tag == "Customer") {

            if (hasPackage) {

                hasPackage = false;
                Debug.Log("Package delivered!");

            } else {

                Debug.Log("Get the package first!");

            }
        }
    }
}
