using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 0.5f;
    [SerializeField] private Color32 hasNoPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    private bool hasPackege;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ой");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackege)
        {
            Debug.Log("Пакунок піднято");
            hasPackege = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, timeToDestroy);
        }
        else
        {
            Debug.Log("Пакунок вже піднято, спочатку достав цей!");
        }

        if (other.tag == "Customer" && hasPackege)
        {
            Debug.Log("Пакунок доставлено");
            hasPackege = false;
            spriteRenderer.color = hasNoPackageColor;
        }
        else
        {
            Debug.Log("Де моя пошта?");
        }
    }
}
