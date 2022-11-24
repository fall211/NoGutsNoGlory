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

    private bool check_player_proximity() {
        return Vector2.Distance(player_obj.transform.position, transform.position) <= 4f;
    }

}
