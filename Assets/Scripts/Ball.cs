using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 10f;
    public TMP_Text tapToPlay;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            tapToPlay.gameObject.SetActive(false);
        }
    }
}
