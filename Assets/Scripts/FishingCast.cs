using System.Collections;
using UnityEngine;

public class FishingCast : MonoBehaviour
{
    public Transform fishing_rod_end;
    public GameObject bobber_prefab;
    public Transform mid_point;
    public GameObject player;

    private GameObject bobber;    
    private Rigidbody2D bobber_rigidbody;
    private Coroutine lerp;
    private Coroutine reel_cor;
    private Vector2 mouse_position;
    private CharacterMovement player_movement;

    public float cast_distance = 3f;
    
    private bool just_clicked = false;
    public bool is_cast = false;

    /*
    TODO: Only allow the player to cast a line if they are facing the pond and close enough to it.
    */
    private void Start() {
        player_movement = player.GetComponent<CharacterMovement>();
    }

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

        if (!player_movement.facing_right) {
            return;
        }

        bobber = Instantiate(bobber_prefab, fishing_rod_end.position, Quaternion.identity);
        bobber_rigidbody = bobber.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
        
        apply_vel(bobber_rigidbody);

        lerp = StartCoroutine(lerp_midpoint(mouse_position));
        is_cast = true;
        just_clicked = true;
    }

    public void reel() {
        Bobber bobber_component = bobber.GetComponent<Bobber>();
        if (bobber == null) {
            return;
        }
        if (bobber_component.fish_biting) {
            bobber_component.Caught();
        }
        bobber_component.fish_can_bite = false;
        reel_cor = StartCoroutine(reel_bobber(bobber));
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
        Vector2 start_pos = fishing_rod_end.position;
        Vector2 end_pos = mouse_position;
        // clamp the end position to a rectangle to the right of the start position.
        end_pos.x = Mathf.Clamp(end_pos.x, start_pos.x, start_pos.x + 4f);
        end_pos.y = Mathf.Clamp(end_pos.y, start_pos.y - 2f, start_pos.y);

        while (time_elapsed < lerp_duration) {
            mid_point.position = Vector2.Lerp(start_pos, end_pos, time_elapsed/lerp_duration);
            time_elapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator reel_bobber(GameObject bobber) {
        float time_elapsed = 0f;
        float lerp_duration = 0.5f;
        Vector2 start_pos = bobber.transform.position;

        Vector2 midpoint_start = mid_point.position;

        while (time_elapsed < lerp_duration) {
            if (bobber == null) {
                yield break;
            }
            bobber.transform.position = Vector2.Lerp(start_pos, fishing_rod_end.position, time_elapsed/lerp_duration);
            mid_point.position = Vector2.Lerp(midpoint_start, bobber.transform.position, time_elapsed/lerp_duration);
            time_elapsed += Time.deltaTime;
            yield return null;
        }
        mid_point.position = bobber.transform.position;
        Destroy(bobber);
        is_cast = false;
    }

}
