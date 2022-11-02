using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movement_speed = 1f;
    public float move_range_left = 10f;
    public float move_range_right = 4f;
    void Update()
    {
        float x_translate = Input.GetAxis("Horizontal") * movement_speed * Time.deltaTime;
        transform.Translate(x_translate, 0f, 0f);

        Vector2 clamped_pos = transform.position;
        clamped_pos.x = Mathf.Clamp(clamped_pos.x, -move_range_left, move_range_right);

        transform.position = clamped_pos;
    }
}
