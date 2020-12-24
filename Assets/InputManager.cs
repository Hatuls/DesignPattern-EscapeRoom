using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager _instance;
    Camera myCamera;
    RaycastHit _hitInfo;
    Ray _ray;
    ObjectAbst useObject;



    void Start()
    {
        _instance = this;
        myCamera = Camera.main;
    }
    public void SetUseObject(ObjectAbst useSelectedObject)
    {

        useObject = useSelectedObject;

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(useObject);
            _ray = myCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hitInfo, 100f))
            {
                Debug.Log(_hitInfo.collider.gameObject.name);

                _hitInfo.collider.gameObject.GetComponent<ObjectInScene>().GotClicked(useObject);

            }

        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
            Inventory._instance.CheckIfObjectIsSelectable(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Inventory._instance.CheckIfObjectIsSelectable(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Inventory._instance.CheckIfObjectIsSelectable(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Inventory._instance.CheckIfObjectIsSelectable(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Inventory._instance.CheckIfObjectIsSelectable(4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            Inventory._instance.CheckIfObjectIsSelectable(5);
        if (Input.GetKeyDown(KeyCode.Alpha7))
            Inventory._instance.CheckIfObjectIsSelectable(6);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            Inventory._instance.CheckIfObjectIsSelectable(7);
        if (Input.GetKeyDown(KeyCode.Alpha9))
            Inventory._instance.CheckIfObjectIsSelectable(8);
        if (Input.GetKeyDown(KeyCode.Alpha0))
            Inventory._instance.CheckIfObjectIsSelectable(9);
    }
}