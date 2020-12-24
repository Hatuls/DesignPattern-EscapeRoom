
using UnityEngine;

public class ObjectInScene : MonoBehaviour
{
 [SerializeField] ObjectAbst thisObject;

    public ObjectAbst GetObjectAbst { get { return thisObject; } }
    private void Start()
    {
        thisObject.gameObject = this.gameObject;
    }


    public void GotClicked(ObjectAbst selectedObject) {

        thisObject.WorldInteraction(selectedObject);
    
    }
}
