using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float transitionSpeed;
    private Transform currentTransform;
    private static bool inTransition = false;
    public static bool GetInTransition => inTransition;
    public static CameraController _instance;
    private void Awake() {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
        currentTransform = transform;
    }
    public void SetAnchor(Transform newTransform) {
        if (newTransform == null)
            return;
        if (currentTransform != newTransform) {
            inTransition = true;
            LeanTween.cancel(gameObject);
            //LeanTween.move(gameObject, posAnchorsTransforms[currentPosIndex].position, transitionSpeed);
            //LeanTween.rotateY(gameObject, posAnchorsTransforms[currentPosIndex].rotation.eulerAngles.y, transitionSpeed).setOnComplete(() => { inTransition = false; });
        }

    }
}
