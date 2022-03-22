using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestroyer : MonoBehaviour
{
    private void OnMouseDown() {
        Destroy(gameObject);
    }
}
