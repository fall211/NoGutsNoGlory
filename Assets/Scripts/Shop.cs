using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject player_obj;
    public GameObject inventory_obj;
    public PlayerInventory inventory_script;
    private bool shop_open = false;

    // Start is called before the first frame update
    void Start() {
        inventory_script = inventory_obj.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (check_player_proximity()) {
                inventory_script.show_inventory();
                shop_open = true;
            }
        }
        if (!check_player_proximity() && shop_open) {
            inventory_script.hide_inventory();
            shop_open = false;
        }

    }

public void sell_heart() {
    if (inventory_script.fish_inventory[0] > 0) {
        inventory_script.fish_inventory[0] -= 1;
        inventory_script.net_worth += 1;
    } else {
        Debug.Log("You don't have any hearts to sell!");
    }
}

public void sell_guts() {
    if (inventory_script.fish_inventory[1] > 0) {
        inventory_script.fish_inventory[1] -= 1;
        inventory_script.net_worth += 1;
    } else {
        Debug.Log("You don't have any guts to sell!");
    }
}

public void sell_lung() {
    if (inventory_script.fish_inventory[2] > 0) {
        inventory_script.fish_inventory[2] -= 1;
        inventory_script.net_worth += 1;
    } else {
        Debug.Log("You don't have any lungs to sell!");
    }
}

    private bool check_player_proximity() {
        return Vector2.Distance(player_obj.transform.position, transform.position) <= 4f;
    }

}
