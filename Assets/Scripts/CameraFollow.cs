using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null){
            Vector3 CameraTarget =Target.transform.position+offset;
            CameraTarget.x=0;
            transform.position = CameraTarget; 

        }
    }
}
