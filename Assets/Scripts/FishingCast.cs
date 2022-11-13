using System.Collections;
using UnityEngine;

public class FishingCast : MonoBehaviour
{
    public Transform fishing_rod_end;
    public GameObject bobber_prefab;
    public Transform mid_point;

    private GameObject bobber;    
    private Rigidbody2D bobber_rigidbody;
    private Coroutine lerp;
    private Vector2 mouse_position;

    public float cast_distance = 3f;
    
    private bool just_clicked = false;
    private bool is_cast = false;

    /*
    TODO: Only allow the player to cast a line if they are facing the pond and close enough to it.
    */

    void Update() {
        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !just_clicked) {
            if (!is_cast) {
                cast();
            }
            else if (is_cast) {
                reel();
                StopCoroutine(lerp);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            just_clicked = false;
        }
        //* Stops lerp coroutine if bobber's velocity is between 0 and 0.6.
        if (bobber_rigidbody != null && bobber_rigidbody.velocity.magnitude <= 0.6f && bobber_rigidbody.velocity.magnitude != 0) {
            StopCoroutine(lerp);
        }
    }

    void cast() {

        bobber = Instantiate(bobber_prefab, fishing_rod_end.position, Quaternion.identity);
        bobber_rigidbody = bobber.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
        
        apply_vel(bobber_rigidbody);

        lerp = StartCoroutine(lerp_midpoint(mouse_position));
        is_cast = true;
        just_clicked = true;
    }

    void reel() {
        Bobber bobber_component = bobber.GetComponent<Bobber>();
        if (bobber != null) {
            Destroy(bobber);
        }
        is_cast = false;
        bobber_component.fish_can_bite = false;

    }

    void apply_vel(Rigidbody2D rigidbody) {
        //* Gets vector pointing from fishing_rod_end to the mouse position.
        Vector2 vel_direction = mouse_position - new Vector2(fishing_rod_end.position.x,fishing_rod_end.position.y);

        float dist_to_mouse = Vector2.Distance(fishing_rod_end.position, mouse_position);
        dist_to_mouse = Mathf.Clamp(dist_to_mouse, 0f, 4f);

        if (rigidbody != null) {
            rigidbody.velocity = vel_direction.normalized * cast_distance * dist_to_mouse;
        }

    }

    IEnumerator lerp_midpoint(Vector2 mouse_position) {
        float time_elapsed = 0f;
        float lerp_duration = 2.5f;
        while (time_elapsed < lerp_duration) {
            
            //TODO: Clamp y coordinate of midpoint to prevent extreme maximums.

            mid_point.position = Vector3.Lerp(fishing_rod_end.position, mouse_position, time_elapsed/lerp_duration);
            time_elapsed += Time.deltaTime;

            yield return null;
        }
        mid_point.position = mouse_position;
    }


}
