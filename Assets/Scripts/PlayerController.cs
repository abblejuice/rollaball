using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Renderer rend;

    private Rigidbody rb;
    private int yellowcount;
    private int redcount;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.material.color = Color.black;
        yellowcount = 0;
        redcount = 0;
        score = 0;
        winText.text = "";
        SetCountText();
        ColorChange();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        ColorChange();
    }
    void FixedUpdate()
    {
        if (yellowcount == 12)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void ColorChange()
    {
        rend.material.color = new Color(Math.Abs(transform.position.x) / 10, transform.position.y, Math.Abs(transform.position.z) / 10, 1f);

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            yellowcount = yellowcount + 1;
            score = score + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Oopsie"))
        {
            other.gameObject.SetActive(false);
            redcount = redcount + 1;
            score = score - 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            score = score - 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        int total = redcount + yellowcount;
        countText.text = "Count: " + total;
        scoreText.text = "Score: " + score;
        if (yellowcount >= 12)
        {
            transform.position = new Vector3(0f, 0.5f, 0f);
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            winText.text = "You finished with a score of: " + score;
        }
    }
}