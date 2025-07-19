using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallColor : MonoBehaviour
{
    SpriteRenderer sr;
    public static int score = 0;
    public string currentColor;
    public Color Yellow, Purple, Red, Blue;
    public TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Yellow";
                sr.color = Yellow;
                break;
            case 1:
                currentColor = "Purple";
                sr.color = Purple;
                break;
            case 2:
                currentColor = "Red";
                sr.color = Red;
                break;
            case 3:
                currentColor = "Blue";
                sr.color = Blue;
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != currentColor && other.tag != "ColorChanger" && other.tag != "Star")
        {
            Debug.Log("Game Over");
            // TODO: Restart game or show game over UI
            Time.timeScale = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.tag == "ColorChanger")
        {
            string temp = currentColor;
            while (temp == currentColor)
            {
                SetRandomColor();
            }
            Destroy(other.gameObject);
            return;
        }
        if (other.tag == "Star")
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
            Debug.Log("Testing git");
        }
    }
}
