using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public SpriteRenderer playerSprit;

    public float speedMov = 10.0f;
    public float horizontalInput;
    public float verticalInput;

    public static bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            PlayerMovement();
        }
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
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerSprit.flipX = true;
        }

        transform.Translate(Vector3.right * horizontalInput * speedMov * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speedMov * Time.deltaTime);
    }
}
