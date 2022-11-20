
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float value;
    public float weight;
    
    // number 0-x of which fish it is
    public int type;

    public GameObject inventory_obj;
    public PlayerInventory player_inventory;
    public Sprite heart;

    void Awake() {

        // TODO: make weight a random value on a normal distribution
        weight = Random.Range(0.5f, 10f);
        type = Random.Range(0, 1);

        value = (type + 1) * weight;

        // rescale the fish to be proportional to its weight
        transform.localScale = new Vector2(weight / 10, weight / 10);


        switch (type) {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = heart;
                break;
        }

        inventory_obj = GameObject.FindGameObjectWithTag("inventory");
        inventory_obj.TryGetComponent<PlayerInventory>(out player_inventory);
    }


    public void on_caught() {
        player_inventory.fish_inventory[type] += 1;
        }
}
