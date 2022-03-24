using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isGrounded;
    public int JumpStrength;
    public int HighJump;
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
       RB = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
 
        if(Input.GetKeyDown(KeyCode.UpArrow) ){
            RB.AddForce(new Vector2(0, JumpStrength));
        }
    }
}
