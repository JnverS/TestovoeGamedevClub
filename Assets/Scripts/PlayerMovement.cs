using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float offset;
    private float dirX;
    private float dirY;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        float rotatez = Mathf.Atan2(dirY, dirX) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0,0,rotatez + offset);
    }
}
