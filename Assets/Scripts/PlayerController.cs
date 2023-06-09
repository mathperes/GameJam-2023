using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public SpriteRenderer playerSprit;
    public SpriteRenderer playerSpritFora;
    public SpriteRenderer playerMorrendo;

    public GameObject gameOverPanel;

    public float speedMov = 10.0f;
    public float horizontalInput;
    public float verticalInput;

    public static bool canMove = true;
    public static bool onDomo = false;
    public static bool isLive = true;

    // Start is called before the first frame update
    void Start()
    {
        onDomo = false;
        canMove = true;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            PlayerMovement();
        }

        if (!isLive)
        {
            GameOver();
        }

        if (isLive)
        {
            if (onDomo)
            {
                playerSprit.gameObject.SetActive(true);
                playerSpritFora.gameObject.SetActive(false);
            }
            else if (!onDomo)
            {
                playerSprit.gameObject.SetActive(false);
                playerSpritFora.gameObject.SetActive(true);
            }
        }
        
    }

    void GameOver()
    {
        canMove = false;
        gameOverPanel.gameObject.SetActive(true);
        playerSprit.gameObject.SetActive(false);
        playerSpritFora.gameObject.SetActive(false);
        playerMorrendo.gameObject.SetActive(true);

        transform.position = new Vector3(0, 0.6f, -5);
    }

    public void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //playerRb.AddForce(Vector3.right * horizontalInput * speedMov);
        //playerRb.AddForce(Vector3.forward * verticalInput * speedMov);

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerSprit.flipX = false;
            //playerSpritFora.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerSprit.flipX = true;
            //playerSpritFora.flipX = true;
        }

        if (transform.position.y < -2)
        {
            transform.position = new Vector3(0, 0.6f, 0);
        }

        transform.Translate(Vector3.right * horizontalInput * speedMov * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speedMov * Time.deltaTime);
    }
}
