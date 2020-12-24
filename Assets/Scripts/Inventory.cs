﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;

    ObjectAbst[] inventory = new ObjectAbst[10];


    public ObjectAbst[] GetInventory { get { return inventory; } }
    private void Awake()
    {
        _instance = this;
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = null;
        }
    }



    public void AddToInventory(ObjectAbst item)
    {
 

        for (int i = 0; i < inventory.Length; i++)
        {

            if (inventory[i] == null)
            {
                inventory[i] = item;

                break;
            }
        }
    }
    public void RemoveFromInventory(ObjectAbst item)
    {
        if (item == null)
            return;


        for (int i = 0; i < inventory.Length; i++)
        {

            if (inventory[i].name == item.name)
            {
                inventory[i] = null;

                break;
            }
        }
    }

    public void CheckIfObjectIsSelectable(int x)
    {
        if (inventory[x] != null)
        {
            inventory[x].UseObject();


            if (inventory[x].isSelectAble)
            {
                InputManager._instance.SetUseObject(inventory[x]);
                Debug.Log("Now Holding a " + inventory[x].name + " Object");
            }
        }
        else
        {
            Debug.Log("Now My Hands Are Free!");
        }

    }

    public void GetObjectFromInventory(int x) {
        InputManager._instance.SetUseObject(inventory[x]);


    }
}