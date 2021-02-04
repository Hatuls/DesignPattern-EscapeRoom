using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    
    [SerializeField] private Transform[] posAnchorsTransforms;
    [SerializeField] private int currentPosIndex;
    [SerializeField] private float transitionSpeed;
    int lastFramePosIndex;
    private void Update() {
        if(currentPosIndex != lastFramePosIndex) {
            LeanTween.cancel(gameObject);
            lastFramePosIndex = currentPosIndex;
            LeanTween.move(gameObject, transform.position, transitionSpeed);
            LeanTween.rotate(gameObject, transform.position, transitionSpeed);
        }
    }

}
