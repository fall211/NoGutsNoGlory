using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movement_speed = 1f;
    public float move_range_left = 10f;
    public float move_range_right = 4f;
    public bool facing_right = true;
    public GameObject fishing_rod;
    public FishingCast fishing_cast;
    private float x_translate;

    private void Start() {
        fishing_cast = fishing_rod.GetComponent<FishingCast>();
    }
    void Update() {
        if (!fishing_cast.is_cast) {
            move();
            change_facing();
        }
        else {
            move();
        }
    }

    private void move() {
        x_translate = Input.GetAxis("Horizontal") * movement_speed * Time.deltaTime;
        transform.Translate(x_translate, 0f, 0f);

        Vector2 clamped_pos = transform.position;
        clamped_pos.x = Mathf.Clamp(clamped_pos.x, -move_range_left, move_range_right);

        transform.position = clamped_pos;
    }

    private void change_facing() {
        if (x_translate > 0 && !facing_right) {
            facing_right = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        } 
        else if (x_translate < 0 && facing_right) {
            facing_right = false;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

}

