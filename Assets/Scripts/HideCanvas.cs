using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour
{
    // Start is called before the first frame update
private void Awake() {
    gameObject.SetActive(false);
}

}
