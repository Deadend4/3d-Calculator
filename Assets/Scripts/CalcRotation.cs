using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcRotation : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] float smooth = 2f;
    [SerializeField] float tiltAngle = 180f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void FixedUpdate() {
    float tiltAroundX = Input.GetAxis("Horizontal") * tiltAngle;
    float tiltAroundZ = Input.GetAxis("Vertical") * tiltAngle;
    // Rotate the cube by converting the angles into a quaternion.
    Quaternion target = Quaternion.Euler(0, -tiltAroundX, -tiltAroundZ);
    // Dampen towards the target rotation
    transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.fixedDeltaTime * smooth);
   }
}
