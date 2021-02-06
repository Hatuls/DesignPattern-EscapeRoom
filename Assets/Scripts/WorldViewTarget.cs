using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WorldViewTarget : MonoBehaviour
{
    [SerializeField] private View view;
    private bool subscribedToEvent = false;
    private void Start() {
        SubscribeToEvent();
    }
    private void OnDestroy() {
        UnSubscribeFromEvent();
    }
    private void OnMouseDown() {
        CameraController._instance.SetView(view);
        gameObject.SetActive(false);
    }
    private void UnSubscribeFromEvent() {
        if (subscribedToEvent) {
            subscribedToEvent = false;
            CameraController._instance.ViewChanged -= ResetEvent;
        }
    }
    private void ResetEvent(View view) {
        if (view != this.view)
            gameObject.SetActive(true);
    }
    private void SubscribeToEvent() {
        if (!subscribedToEvent) {
            subscribedToEvent = true;
            CameraController._instance.ViewChanged += ResetEvent;
        }
    }
}
