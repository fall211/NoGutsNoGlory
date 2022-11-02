using System.Collections;
using UnityEngine;

public class FishingCast : MonoBehaviour
{
    public Transform fishing_rod_end;
    public GameObject bobber;
    public float cast_distance = 3f;
    public Transform mid_point;
    private GameObject clone_bobber;    
    private bool just_clicked = false;
    private Rigidbody2D bobber_rigidbody;
    private Coroutine lerp;

    /*
    TODO: Only allow the player to cast a line if they are facing the pond and close enough to it.
    */

    void Update() {
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !just_clicked) {

            if (clone_bobber != null) {
                Destroy(clone_bobber);
            }

            clone_bobber = Instantiate(bobber, fishing_rod_end.position, Quaternion.identity);
            bobber_rigidbody = clone_bobber.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
            
            apply_vel(bobber_rigidbody);

            lerp = StartCoroutine(lerp_midpoint(mouse_position));

            just_clicked = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            just_clicked = false;
        }
        //* Stops lerp coroutine if bobber's velocity is between 0 and 0.6.
        if (bobber_rigidbody != null && bobber_rigidbody.velocity.magnitude <= 0.6f && bobber_rigidbody.velocity.magnitude != 0) {
            StopCoroutine(lerp);
        }
    }

    void apply_vel(Rigidbody2D rigidbody) {
        //* Mouse position in terms of in-engine units.
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
