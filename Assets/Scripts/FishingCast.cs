using UnityEngine;

public class FishingCast : MonoBehaviour
{
    public Transform fishing_rod_end;
    public GameObject bobber;
    private GameObject clone_bobber;
    public float cast_distance = 3f;
    bool just_clicked = false;

    void Update()
    {
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !just_clicked) {
            if (clone_bobber != null) 
            {
                Destroy(clone_bobber);
            }
            clone_bobber = Instantiate(bobber, fishing_rod_end.position, Quaternion.identity);
            just_clicked = true;
            apply_vel(clone_bobber);
        }
        if (Input.GetMouseButtonUp(0)) {
            just_clicked = false;
        }
    }

    void apply_vel(GameObject bobber)
    {
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vel_position = mouse_position - new Vector2(fishing_rod_end.position.x,fishing_rod_end.position.y);

        float dist_to_mouse = Vector2.Distance(fishing_rod_end.position, mouse_position);
        dist_to_mouse = Mathf.Clamp(dist_to_mouse, 0f, 4f);

        Rigidbody2D rigidbody = bobber.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;

        if (rigidbody != null) {
            rigidbody.velocity = vel_position.normalized * cast_distance * dist_to_mouse;
        }
    }

}
