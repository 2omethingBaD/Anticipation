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


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); //gets rigid body so you dont have to type whole thing
        _rb.gravityScale = 0; //stops player from falling until set to at least 1
        _isAllowedUP = true;
        _isAllowedDOWN = true;
        _isAllowedLEFT = true;
        _isAllowedRIGHT = true;

    }


    //called when player touches the bounds
    void OnCollisionEnter2D(Collision2D collision)
    {
        while(collision.gameObject.name == "bounds" & Input.GetKey(KeyCode.W))
        {
            _isAllowedUP = false;
            Debug.Log("hi");
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
        //player movement
        if (Input.GetKey(KeyCode.W) & _isAllowedUP == true)
        {
            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }
}
