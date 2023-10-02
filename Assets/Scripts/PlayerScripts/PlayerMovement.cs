using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;

    private float dirX;
    private float dirY;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
        if (dirX < 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            animator.SetBool("IsWalk", true);
        }
        else if (dirX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
        animator.SetFloat("Speed", dirX);

    }
}
