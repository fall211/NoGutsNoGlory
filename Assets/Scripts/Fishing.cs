using UnityEngine;
using System.Collections;

public class Fishing : MonoBehaviour {
    
// * if bobber in water then coroutine wait for fish to bite if fish biting on hook and reel then cought fish

    private GameObject bobber_obj;
    private GameObject water_obj; 
    private Bobber bobber_component;
    private bool coroutine_running = false;
    private Coroutine wait_for_bite;

    private void Start() {
        water_obj = GameObject.FindGameObjectWithTag("water");
    }
    private void Update() {
        if (bobber_obj == null) {
            if (coroutine_running) {
                StopCoroutine(wait_for_bite);
                coroutine_running = false;
            }
            bobber_obj = GameObject.FindGameObjectWithTag("bobber");
            if (bobber_obj != null) {
                bobber_component = bobber_obj.GetComponent<Bobber>();
            }
        }
        if (!coroutine_running && bobber_obj != null) {
            Debug.Log("Start coroutine");
            if (bobber_component.fish_can_bite) {
                wait_for_bite = StartCoroutine(fish_bite());
            }
        }
    }

    IEnumerator fish_bite() {
        coroutine_running = true;
        int bite_interval = Random.Range(2, 5);

        yield return new WaitForSeconds(bite_interval);
        bobber_component.Bite();
        yield return new WaitForSeconds(2f);
        bobber_component.Bite();
        yield return new WaitForSeconds(1.5f);
        bobber_component.Released();
        coroutine_running = false;
    }

}