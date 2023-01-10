using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    Vector3 offset;
    public bool canDrag = true;
    public bool snapGrid = false;
    public Grid grid;

    public void Start()
    {
        grid = GameObject.Find("GridManager").GetComponent<GridManager>().GridMap;
    }

    private void OnMouseDrag()
    {
        if (!canDrag)
            return;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        if (snapGrid)
            transform.position = 
                //grid.GetWorldPosition(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
            new Vector2(Mathf.RoundToInt(transform.position.x / grid.cellSize) * grid.cellSize - grid.cellSize / 2, Mathf.RoundToInt(transform.position.y / grid.cellSize) * grid.cellSize - grid.cellSize/2);
    }
    public void OnMouseDown()
    {
        if (!canDrag)
            return;

        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void OnMouseUp()
    {
        canDrag = false;
        this.gameObject.layer = 0;
        Debug.Log("letted go off object");
    }

    public void SnapToGrid()
    {

    }
}
