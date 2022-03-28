using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float JumpPower;
    public LayerMask Mask;

    private bool _isGrounded;
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0, RB.velocity.y);

        float DistanceToGround = GetComponent<Collider2D>().bounds.extents.y;

        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround + 0.5f, Mask);

        if (Input.GetKeyDown(KeyCode.W) && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;

        }
    }
}
