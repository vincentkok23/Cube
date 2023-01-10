using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    Vector3 offset;
    public bool canDrag = true;
    public bool snapGrid = false;
    public Vector2 Offset;
    public Vector2 Size;
    [HideInInspector]public Grid grid;
    public Hotbar hotbar;
    private int index;

    public void Start()
    {
        grid = GameObject.Find("GridManager").GetComponent<GridManager>().GridMap;
        hotbar = GameObject.Find("HotbarManager").GetComponent<HotbarManager>().Hotbar;
        for (int i = 0; i < GameManager.Instance.ItemIndexes.Length; i++)
        {
            if (this.gameObject == GameManager.Instance.ItemIndexes[i])
            {
                index = 1;
                return;
            }
        }
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
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (hotbar.EDITOR)
        {
            GameObject a = Instantiate(this.gameObject,offset,this.gameObject.transform.rotation);
            a.GetComponent<SpriteRenderer>().sortingOrder = 0;

            return;
        }
        if (!canDrag)
            return;




        GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
    public void OnMouseUp()
    {
        if (hotbar.EDITOR)
        {
            int x, y;
            grid.GetXY(gameObject.transform.position,out x,out y);

            grid.GridMap[x, y] = index;
            grid.Objects[x, y] = this.gameObject;
        }

        canDrag = false;
        this.gameObject.layer = 0;

        this.gameObject.GetComponent<BoxCollider2D>().offset = offset;
        this.gameObject.GetComponent<BoxCollider2D>().size = Size;

        Debug.Log("letted go off object");

        this.gameObject.transform.parent = null;
        Destroy(this);
    }

    public void SnapToGrid()
    {

    }
}
