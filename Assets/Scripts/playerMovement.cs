using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float JumpPower;
    public LayerMask Mask;
    public Animator PlayerAnimator;
    public bool IsBallBig = false;
    public bool Touching = false;
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

        if (Input.GetAxis("Vertical") > 0.01 && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
        }

        IsBallBig = Input.GetAxis("Vertical") < -0.5;

        PlayerAnimator.SetBool("DownArrow", !IsBallBig);

    }
    private void OnCollisionEnter2D(Collision2D CoInfo)
    {
        if (CoInfo.collider.tag == "Obstacle")
            Touching = true;
    }
    private void OnCollisionExit2D(Collision2D CoInfo)
    {
        if (CoInfo.collider.tag == "Obstacle")
            Touching = false;
    }
    private void OnTriggerEnter2D(Collider2D Coinfo)
    {
        if(Coinfo.tag=="Teleport")
        {
        Vector2 move = new Vector2(14, -11);
        RB.MovePosition(move);
        }
    }
}
