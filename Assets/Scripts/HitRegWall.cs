using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRegWall : MonoBehaviour
{
    public GameObject Target;
    private playerMovement MovementScript;
    public GameObject WallHitBox;



    // Start is called before the first frame update
    void Start()
    {
        MovementScript = Target.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementScript.IsBallBig)
        {
            WallHitBox.SetActive(false);
        } else if(!MovementScript.IsBallBig){
            WallHitBox.SetActive(true);
        }

        
    }
}
