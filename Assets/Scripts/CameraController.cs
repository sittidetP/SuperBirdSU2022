using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BirdController bird;
    
    private void Awake() {
        bird = GameObject.FindObjectOfType<BirdController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(bird.transform.position.x, 0, transform.position.z);
    }
}
