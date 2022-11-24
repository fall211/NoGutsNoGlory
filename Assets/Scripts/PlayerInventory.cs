using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public float net_worth;
    public int[] fish_inventory;

    public GameObject heart_text;
    public GameObject guts_text;
    public GameObject lung_text;
    public GameObject canvas_obj;

    // Start is called before the first frame update
    void Start()
    {
        net_worth = 0;
        fish_inventory = new int[3];
        canvas_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if the player presses tab, open the inventory
        // if (Input.GetKeyDown(KeyCode.Tab) && !inventory_open) {
        //     inventory_open = true;
        //     show_inventory();
        // }
        // else if (Input.GetKeyDown(KeyCode.Tab) && inventory_open) {
        //     inventory_open = false;
        //     hide_inventory();
        // }

        heart_text.GetComponent<TextMeshProUGUI>().text = fish_inventory[0].ToString();
        guts_text.GetComponent<TextMeshProUGUI>().text = fish_inventory[1].ToString();
        lung_text.GetComponent<TextMeshProUGUI>().text = fish_inventory[2].ToString();

    }

    public void show_inventory() {
        canvas_obj.SetActive(true);
        Debug.Log("net_worth: " + net_worth);
        Debug.Log("Fish: " + fish_inventory[0] + ", " + fish_inventory[1] + ", " + fish_inventory[2]);
    }

    public void hide_inventory() {
        canvas_obj.SetActive(false);
        Debug.Log("Inventory closed");
    }
}
