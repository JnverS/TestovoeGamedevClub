using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    private float dirX;
    private float dirY;
    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, dirY);
        if (dirX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (dirX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        animator.SetFloat("Speed", dirX);
    }
}
