using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerMovement : MonoBehaviour
{
    public float JumpPower;
    public LayerMask Mask;
    public Animator PlayerAnimator;
    public bool IsBallBig = false;
    public bool Dead = false;
    public int level = 1;

    private bool PAlive = true;
    public TextMeshProUGUI LevelText;
    public GameObject WorldLight;
    public GameObject Lamps;
    public GameObject RockWalls;
    public GameObject Spikes;
    public GameObject Runsav;
    private Rigidbody2D RB;
    private float TempX;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        if (LevelText != null)
            LevelText.text = "Level: " + level;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0, RB.velocity.y);

        if (Input.GetAxis("Vertical") < -0.1 && PAlive && level > 3)
        {
            PlayerAnimator.SetBool("DownArrow", false);
        }

        if (Dead == true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void OnTriggerEnter2D(Collider2D CoInfo)
    {
        if (CoInfo.gameObject.CompareTag("Teleport"))
        {
            level += 1;
            LevelText.text = "Level: " + level;
            TempX = RB.transform.position.x;
            Vector2 move = new Vector2(TempX, 10);
            RB.MovePosition(move);
            if (level > 1)
            {
                WorldLight.SetActive(false);
                Lamps.SetActive(true);
            }
            if (level > 2)
            {
                Spikes.SetActive(true);
            }
            if (level > 3)
            {
                RockWalls.SetActive(false);
                RockWalls.SetActive(true);
            }
            if (level > 4)
            {
                Runsav.SetActive(true);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D CoInfo)
    {
        if (CoInfo.gameObject.CompareTag("ground"))
        {
            PlayerAnimator.SetBool("DownArrow", true);
            if (Input.GetAxis("Vertical") > 0.1 && PAlive && level > 1)
            {
                RB.AddForce(new Vector2(0, JumpPower));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D CoInfo)
    {
        if (CoInfo.gameObject.CompareTag("Dead"))
        {
            PAlive = false;
            PlayerAnimator.SetBool("Dead", true);
        }
        else
        {
            PlayerAnimator.SetBool("Dead", false);
        }

    }
}
