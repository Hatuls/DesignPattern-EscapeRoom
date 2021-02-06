using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager _instance;
    Camera myCamera;
    RaycastHit _hitInfo;
    Ray _ray;
    ObjectSO useObject;



    void Start()
    {
        _instance = this;
        myCamera = Camera.main;
        SetSelectedObject(null);
    }
    public void SetSelectedObject(ObjectSO useSelectedObject)
    {
        if (useSelectedObject == null)
        {
            useObject = null;
            return;
        }

        Debug.Log("Now Holding a " + useSelectedObject.objName + " Object.");


        useObject = useSelectedObject;
    }

    ObjectInScene objectInScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectInScene = null;
            _ray = myCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hitInfo, 100f))
            {

                Debug.Log("Clicked on " + _hitInfo.collider.gameObject.name + " while holding " + (useObject == null ? "nothing." : useObject.name));
                _hitInfo.collider.gameObject.TryGetComponent<ObjectInScene>(out objectInScene);

                    
                if (objectInScene != null)
                objectInScene.GotClicked(useObject);

                
                
            }
        }


        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //    if (!Inventory.GetInstance.CheckIfItemtIsSelectable(0))
        //        Inventory.GetInstance.ItemInventoryInteract(0);
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //    if (!Inventory.GetInstance.CheckIfItemtIsSelectable(1))
        //        Inventory.GetInstance.ItemInventoryInteract(1);
        //    else
        //        SetSelectedObject(Inventory.GetInstance.GetInventory[1]);
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //    Inventory.GetInstance.CheckIfItemtIsSelectable(2);
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //    Inventory.GetInstance.CheckIfItemtIsSelectable(3);
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //    Inventory.GetInstance.CheckIfItemtIsSelectable(4);
        //if (Input.GetKeyDown(KeyCode.Alpha6))           
        //    Inventory.GetInstance.CheckIfItemtIsSelectable(5);
        //if (Input.GetKeyDown(KeyCode.Alpha7))
        //    Inventory.GetInstance.CheckIfItemtIsSelectable(6);
        //if (Input.GetKeyDown(KeyCode.Alpha8))
        //    Inventory.GetInstance.CheckIfItemtIsSelectable(7);
        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //    Inventory.GetInstance.CheckIfItemtIsSelectable(8);
    }
}