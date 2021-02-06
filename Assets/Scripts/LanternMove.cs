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
        transform.Rotate(Vector3.forward * -rotationAngle,Space.Self);
        StartRotate();
    }
    private void StartRotate() {
       LeanTween.rotateAroundLocal(gameObject, Vector3.forward, 2*rotationAngle, rotationTime).setEaseInOutQuad().setLoopPingPong();   

    }
}
