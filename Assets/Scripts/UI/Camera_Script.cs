using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{


        bool wasDraggingCamera = false;
        Vector3 lastScreenMousePosition;
        Ray lastMousePosition;

        void Update()
        {
            UpdateDrag();
        }

        void UpdateDrag()
        {
            var willDragCamera = wasDraggingCamera;
            wasDraggingCamera = Input.GetMouseButton(2);
            var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (willDragCamera && Input.mousePosition != lastScreenMousePosition)
                transform.position = transform.position - (mousePosition.origin - lastMousePosition.origin);
            lastScreenMousePosition = Input.mousePosition;
            lastMousePosition = mousePosition;
        }


}
