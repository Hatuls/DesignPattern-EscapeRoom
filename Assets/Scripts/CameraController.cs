using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float transitionSpeed;
    [SerializeField] private View startView;
    public event System.Action StartedTransition;
    public event System.Action<View> ViewChanged;
    private View currentView;
    private static bool inTransition = false;
    public static bool GetInTransition => inTransition;
    public static CameraController _instance;
    private void Awake() {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
        currentView = startView;
    }
    private void Start() {
        SetTransitionEnd(currentView);
    }
    public void SetView(View newView) {
        if (!newView || inTransition)
            return;
        if (currentView != newView) {
            inTransition = true;
            StartedTransition();
            LeanTween.cancel(gameObject);
            LeanTween.move(gameObject, newView.transform.position, transitionSpeed);
            LeanTween.rotateY(gameObject, newView.transform.rotation.eulerAngles.y, transitionSpeed).setOnComplete(() => { SetTransitionEnd(newView); });
        }
    }
    private void SetTransitionEnd(View view) {
        inTransition = false;
        currentView = view;
        ViewChanged(view);
        Debug.Log("Changed View");
        //Notify UImanager about new view 
    }
}
