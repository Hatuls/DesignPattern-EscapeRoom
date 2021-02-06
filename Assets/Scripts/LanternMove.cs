using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternMove : MonoBehaviour
{
    [SerializeField] float rotationAngle;
    [SerializeField] float rotationTime;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.right * -rotationAngle);
        LeanTween.rotateAround(gameObject, Vector3.right, 2 * rotationAngle, rotationTime).setEaseInOutCubic().setLoopPingPong();   
    }
}
