using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(255, 255, 255, 1);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 1);
    [SerializeField] float destructionDelay = 0.5f;

    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package")
        {
            if(!hasPackage)
            {
                hasPackage = true;
                Debug.Log("Package picked up!");
                spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, destructionDelay);
            }
            else
            {
                Debug.Log("You already have a package!");
            }
        }
        else if (other.tag == "Customer")
        {
            if (hasPackage)
            {
                hasPackage = false;
                Debug.Log("Package delivered!");
                spriteRenderer.color = noPackageColor;
                Destroy(other.gameObject, destructionDelay);
            }
            else
            {
                Debug.Log("Get the package first!");
            }
        }
    }
}
