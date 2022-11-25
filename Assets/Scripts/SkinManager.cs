using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{

    // Get reference to all things that can be reskinned
    public GameObject player_obj;
    public GameObject shop_obj;
    public GameObject fishing_rod_obj;

    // Get reference to all sprite renderers
    public SpriteRenderer player_sprite;
    public SpriteRenderer shop_sprite;
    public SpriteRenderer fishing_rod_sprite;
    

    private Sprite default_skin;


    // Start is called before the first frame update
    void Start() {
        player_obj = GameObject.Find("Player Sprite");
        shop_obj = GameObject.Find("Shop");
        fishing_rod_obj = GameObject.Find("Fishing Rod");

        player_sprite = player_obj.GetComponentInChildren<SpriteRenderer>();
        shop_sprite = shop_obj.GetComponent<SpriteRenderer>();
        fishing_rod_sprite = fishing_rod_obj.GetComponent<SpriteRenderer>();
        default_skin = Resources.Load<Sprite>("Sprites/player_default");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            player_sprite.sprite = default_skin;
        }
    }
}
