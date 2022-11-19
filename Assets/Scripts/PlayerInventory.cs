using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public float money;
    public int[] fish_inventory;

    private bool inventory_open = false;

    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        fish_inventory = new int[3];
    }

    // Update is called once per frame
    void Update()
    {
        // if the player presses tab, open the inventory
        if (Input.GetKeyDown(KeyCode.Tab) && !inventory_open) {
            inventory_open = true;
            show_inventory();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && inventory_open) {
            inventory_open = false;
            hide_inventory();
        }

    }

    void show_inventory() {
        Debug.Log("Money: " + money);
        Debug.Log("Fish: " + fish_inventory[0] + ", " + fish_inventory[1] + ", " + fish_inventory[2]);
    }

    void hide_inventory() {
        Debug.Log("Inventory closed");
    }

}
