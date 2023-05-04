using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    //public Inventory inv;
    //public ItemBase type;

    private bool playerInRange = false;
    private Coroutine checkInputCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            checkInputCoroutine = StartCoroutine(CheckInput());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            StopCoroutine(checkInputCoroutine);
        }
    }

    private IEnumerator CheckInput()
    {
        while (playerInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Press Interact.");
                //inv.takeMoney(type.price);
                //inv.slots.Add(type);
                Destroy(gameObject);
            }
            yield return null;
        }
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    // public Inventory inv;
    // public Item type = new Item();
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("here");
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Press Interact.");
                // inv.takeMoney(type.price);
                // inv.add(type);
                Destroy(gameObject);
            }
        }
    }
}
*/