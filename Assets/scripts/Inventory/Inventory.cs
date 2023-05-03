using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
     public List<ItemBase> slots;

	public void takeMoney(int price)
    {
		// do stuff
    }
}

/*
public class ItemSlot
{
	[SerializeField] ItemBase item;
	[SerializeField] int count;

	public ItemBase Item => item;

	public int Count => count;
}
*/
