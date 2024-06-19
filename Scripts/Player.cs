using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float mSpeed;
    [SerializeField] private float jumpSpeed;
    private Vector2 dir;

    [SerializeField] private GameObject win;

    public GameObject currentPlatform;

    [SerializeField] private LayerMask groundLayer;

    public bool grounded;

    public void Start()
    {
        win.SetActive(false);
    }

    public void OnMove(InputValue inputValue)
    {
        dir = inputValue.Get<Vector2>();
        Debug.Log(dir);
    }

    public void OnJump(InputValue inputValue)
    {
        if (IsGrounded())
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
            Debug.Log("jumped");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }


    private void FixedUpdate()
    {
        if (dir.x != 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x * mSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    
    public bool IsGrounded()
    {
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
            grounded = true;
        }
        
        return false;
        grounded = false;
        currentPlatform = null;
    } 
}
