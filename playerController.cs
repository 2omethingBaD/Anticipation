using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;  //sets player speed
    public Rigidbody2D _rb; //sets up variable for rigid body
    //to check if the player is allowed to move
    public bool _isAllowedUP;
    public bool _isAllowedDOWN;
    public bool _isAllowedLEFT;
    public bool _isAllowedRIGHT;


    void Awake()
    {
        _isAllowedUP = false;
        _isAllowedDOWN = true;
        _isAllowedLEFT = true;
        _isAllowedRIGHT = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); //gets rigid body so you dont have to type whole thing
        _rb.gravityScale = 0; //stops player from falling until set to at least 1
    }


    //called to allow player to move again
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isAllowedUP = true;
        _isAllowedDOWN = true;
        _isAllowedLEFT = true;
        _isAllowedRIGHT = true;
    }


    //called to stop player form bouncing on bounds
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "BOUNDS" && Input.GetKey(KeyCode.W))
        {
            _isAllowedUP = false;
        }
        if (collision.gameObject.name == "BOUNDS" && Input.GetKey(KeyCode.A))
        {
            _isAllowedLEFT = false;
        }
        if (collision.gameObject.name == "BOUNDS" && Input.GetKey(KeyCode.S))
        {
            _isAllowedDOWN = false;
        }
        if (collision.gameObject.name == "BOUNDS" && Input.GetKey(KeyCode.D))
        {
            _isAllowedRIGHT = false;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        //player movement
        if (Input.GetKey(KeyCode.W) && _isAllowedUP == true)
        {
            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && _isAllowedLEFT == true)
        {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && _isAllowedDOWN == true)
        {
            transform.position += Vector3.down * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && _isAllowedRIGHT == true)
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }
}
