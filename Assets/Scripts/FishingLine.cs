using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public Transform fishing_rod_end;
    public GameObject bobber;
    public Transform mid_point;
    private LineRenderer line_renderer;

    void Start(){
        line_renderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update(){
        bobber = GameObject.FindGameObjectWithTag("bobber");
        if (bobber != null) {
            // draw_straight_line();
            draw_quadratic_line();
        }
    }

    void draw_straight_line() {
            line_renderer.positionCount = 2;

            Vector3[] positions = new Vector3[2]{ fishing_rod_end.position, bobber.transform.position};
            line_renderer.SetPositions(positions);
    }

    void draw_quadratic_line() {
        float t = 0f;

        line_renderer.positionCount = 200;
        Vector3 B = new Vector3(0, 0, 0);

        for (int i = 0; i < line_renderer.positionCount; i++) {
            B = (1 - t) * (1 - t) * fishing_rod_end.position + 2 * (1 - t) * t * mid_point.position + t * t * bobber.transform.position;
            line_renderer.SetPosition(i, B);
            t += (1 / (float)line_renderer.positionCount);
        }
    }
}
