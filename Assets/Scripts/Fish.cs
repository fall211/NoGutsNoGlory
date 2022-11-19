
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float value;
    public float weight;
    
    // number 0-x of which fish it is
    public int type;

    public GameObject inventory_obj;
    public PlayerInventory player_inventory;


    void Awake() {
        // TODO: make weight a random value on a normal distribution
        weight = Random.Range(0.5f, 10f);
        type = Random.Range(0, 3);

        value = (type + 1) * weight;

        switch(type) {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }

        inventory_obj = GameObject.FindGameObjectWithTag("inventory");
        inventory_obj.TryGetComponent<PlayerInventory>(out player_inventory);
    }


    public void on_caught() {
        player_inventory.fish_inventory[type] += 1;
        }
}
