using UnityEngine;

public class Water : MonoBehaviour
{

    private GameObject bobber_obj;


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        find_bobber();
        Bobber bobber = bobber_obj.GetComponent<Bobber>();
        bobber.in_water = true;
        if (!bobber.fish_can_bite) {
            bobber.fish_can_bite = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        find_bobber();
        Bobber bobber = bobber_obj.GetComponent<Bobber>();
        bobber.in_water = false;
    }

    private void OnTriggerStay2D(Collider2D other) {
    
    }

    void find_bobber() {
        bobber_obj = GameObject.FindGameObjectWithTag("bobber");
    }
}

