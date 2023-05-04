using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
     //public List<ItemBase> slots;
     public List<ItemBase> items = new List<ItemBase>();
     public int money = 500;

     public void AddItem(ItemBase item)
     {
	     items.Add(item);
     }

     public void RemoveItem(ItemBase item)
     {
	     items.Remove(item);
     }

     public void addMoney(int price)
     {
	     money += price;
     }

	public void takeMoney(int price)
    {
	    money -= price;
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
