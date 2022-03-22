using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpPower = 3f;
    public float speed = 5f;

    public int score = 0;

    public bool dead = false;
    public AudioSource audioJump;
    public AudioSource audioScore;
    public AudioSource audioDead;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!dead)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            if (Input.GetMouseButtonDown(0))
            {
                rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
                audioJump.Play();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        audioScore.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        dead = true;
        audioDead.Play();
    }
}
