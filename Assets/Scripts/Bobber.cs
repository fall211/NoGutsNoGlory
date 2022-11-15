using UnityEngine;

public class Bobber : MonoBehaviour
{
    private Rigidbody2D bobber_rigidbody;
    public bool in_water;
    public bool fish_can_bite;
    public bool fish_biting = false;
    private float buoyancy_force = 30f;
    private float fish_force = 3f;

    void Start()
    {
        bobber_rigidbody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (in_water) {
            bobber_rigidbody.velocity += new Vector2(0, buoyancy_force * Time.deltaTime);
        }
    }

    public void Bite() {
        Debug.Log("fish bite");
        fish_biting = true;
        bobber_rigidbody.velocity = new Vector2(0, -fish_force);
    }
    public void Caught() {
        Debug.Log("fish caught");
        fish_biting = false;
    }

    public void Released() {
        Debug.Log("fish released");
        fish_biting = false;
    }
}
