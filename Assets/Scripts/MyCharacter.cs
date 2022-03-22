using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacter : MonoBehaviour
{
    public float speed = 2f;
    public float yForce = 30f;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float distanceZ = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        print(distanceX + ", " + distanceZ);
        transform.Translate(distanceX, 0, distanceZ);
        //print(Input.GetAxis("Horizontal"));
        //print(Input.GetButton("Fire1"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, yForce, 0), ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(new Vector3(0, yForce, 0), ForceMode.Impulse);
        }
        */
    }
}
