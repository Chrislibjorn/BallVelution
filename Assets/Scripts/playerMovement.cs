using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float JumpPower;
    public LayerMask Mask;
    public Animator PlayerAnimator;
    public bool IsBallBig = false;
    public bool Dead = false;
    private bool _isGrounded;

    public GameObject RockWalls;
    private Rigidbody2D RB;
    private float TempX;

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

        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround + 0.03f, Mask);

        if (Input.GetAxis("Vertical") > 0.01 && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
        }

        if (Input.GetAxis("Vertical") < -0.5)
        {
            PlayerAnimator.SetBool("DownArrow", false);
        }

        if(Dead==true)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void OnTriggerEnter2D(Collider2D CoInfo)
    {
        if (CoInfo.gameObject.CompareTag("Teleport"))
        {
            TempX = RB.transform.position.x;
            Vector2 move = new Vector2(TempX, 10);
            RB.MovePosition(move);
            RockWalls.SetActive(false);
            RockWalls.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D CoInfo)
    {
        if (CoInfo.gameObject.CompareTag("ground"))
            PlayerAnimator.SetBool("DownArrow", true);
    }
    private void OnCollisionEnter2D(Collision2D CoInfo)
    {
        if (CoInfo.gameObject.CompareTag("Dead"))
            {
            PlayerAnimator.SetBool("Dead", true);
            } else {
            PlayerAnimator.SetBool("Dead", false);
            }

    } 
}
