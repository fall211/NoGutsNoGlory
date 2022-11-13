using UnityEngine;
using System.Collections;

public class Fishing : MonoBehaviour {
    
// * if bobber in water then coroutine wait for fish to bite if fish biting on hook and reel then cought fish

    private GameObject bobber_obj;
    private GameObject water_obj; 
    private Bobber bobber_component;
    private bool coroutine_running = false;

    private void Start() {
        water_obj = GameObject.FindGameObjectWithTag("water");
    }
    private void Update() {
        if (bobber_obj == null) {
            bobber_obj = GameObject.FindGameObjectWithTag("bobber");
            bobber_component = bobber_obj.GetComponent<Bobber>();

        }
        if (!coroutine_running) {
            StartCoroutine(fish_bite());
        }

    }

    IEnumerator fish_bite() {
        coroutine_running = true;
        int bite_time = Random.Range(3, 5);

        yield return new WaitForSeconds(bite_time);
        Debug.Log("fish bite now");
        coroutine_running = false;
    }

}