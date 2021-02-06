using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WorldViewTarget : MonoBehaviour
{
    [SerializeField] private View activeView;
    [SerializeField] private View targetView;
    private bool subscribedToEvent = false;
    private void Start() {
        SubscribeToEvent();
    }
    private void OnDestroy() {
        UnSubscribeFromEvent();
    }
    private void OnMouseDown() {
        CameraController._instance.SetView(targetView);
        gameObject.SetActive(false);
    }
    private void UnSubscribeFromEvent() {
        if (subscribedToEvent) {
            subscribedToEvent = false;
            CameraController._instance.ViewChanged -= CheckViewEvent;
        }
    }
    private void CheckViewEvent(View view) {
        if (view == activeView)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
    private void SubscribeToEvent() {
        if (!subscribedToEvent) {
            subscribedToEvent = true;
            CameraController._instance.ViewChanged += CheckViewEvent;
        }
    }
}
