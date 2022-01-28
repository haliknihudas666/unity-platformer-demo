using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    public float movementSpeed = 1;
    public float jumpForce = 1;
    private Rigidbody2D _rigidbody;
    public SpriteRenderer character;

    public Text scoreText;
    public Text finishText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the horizontal axis values
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (movement < 0)
        {
            character.flipX = true;
        }
        else if (movement > 0)
        {
            character.flipX = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Check if collided
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "Enemy")
        {
            Invoke("Restart", 0);
        }
        else if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            score++;

            scoreText.text = score.ToString();
        }
        else if (collision.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("Level Two");
        }
        else if (collision.gameObject.tag == "Finish")
        {
            finishText.text = "Finished!";
            Invoke("Restart", 5);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Level One");
    }
}
