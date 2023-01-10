using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hotbar
{
    public HotbarManager manager;

    [Header("Scale hotbar")]
    public Vector2 size;
    public List<GameObject> itemInventory;
    public List<GameObject> ItemInventory
    {
        get { return itemInventory; }
        set { itemInventory = value; RELOAD(); }
    }

    [Header("Item Size Settings")]
    public float itemSize;
    public float itemSizeDiff;
    
    [Header("Spawn Settings")]
    public Transform parent;
    public bool insideParent;
    public bool EDITOR = false;

    [Header("Animation settings")]
    public float speed;
    public float duration;


    //private List<GameObject> spawnedInventoryItems = new List<GameObject>();
    public Hotbar(float width, float height, List<GameObject> items, float itemSize, float itemSizeDiff, float animationSpeed, Transform parent, bool insideParent)
    {
        //size.x = width;
        //size.y = height;

        itemInventory = items;
        this.itemSize = itemSize;
        this.itemSizeDiff = itemSizeDiff;

        //animationSmoothness = animationSpeed;
        
        this.parent = parent;
        this.insideParent = insideParent;
 
        //RELOAD();
    }

    #region [RELOAD | ANIMATION | HOVER | REPLACE]
    // call this when you hover over an object to make it zoom in
    public void HOVER(int item)
    {
        //itemInventory[item].transform.localScale = ANIMATE(itemInventory[item].transform.localScale, 1.25f, 1.25f);
    }
    //replace all the inventory items
    public void REPLACE(List<GameObject> itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    public void REPLACE_ID(GameObject item,int index)
    {
        this.itemInventory[index] = item;
    }
    //reload the hotbar and items in the entierty
    public void RELOAD()
    {
        Debug.Log("Working");
        int j = itemInventory.Count;
        //parent.position -= new Vector3(j * 0.27f, 0f);
        for (int i = 0; i < j; i++)
        {
            GameObject item = itemInventory[i];
            //if (insideParent) { localObject = GameObject.Instantiate(item, new Vector2(parent.position.x - (size.x / 2) + itemSizeDiff + (itemSize * i), parent.position.y), Quaternion.identity,parent); spawnedInventoryItems.Add(localObject); break; }
            if (i ==0 ) { GameObject.Instantiate(item, new Vector2(parent.position.x - (size.x / 2) + itemSizeDiff + (itemSize * i), parent.position.y), Quaternion.identity);
            }
            else if (i==j) { GameObject.Instantiate(item, new Vector2(parent.position.x - (size.x / 2) + itemSizeDiff + (itemSize * i), parent.position.y), Quaternion.identity);
            }
            else {GameObject.Instantiate(item, new Vector2(parent.position.x - (size.x / 2) + itemSizeDiff + (itemSize * i), parent.position.y), Quaternion.identity);            }

            Debug.Log(new Vector2(((parent.position.x - (size.x / 2) + itemSizeDiff + itemSize) + (parent.position.x - (size.x / 2) + itemSizeDiff + itemSize * (i - 1)))/2, parent.position.y));
            
            if (i == j-1)
                parent.position = new Vector2(((parent.position.x - (size.x/2) + itemSizeDiff + itemSize) + (parent.position.x - (size.x / 2) + itemSizeDiff + itemSize * (i -1) ))/2, parent.position.y);
        }
        size.x = j + 1 + j * itemSizeDiff;
        //animate scale in main manager
        manager.CoroutineLoader(RepeatLerp(parent,size,duration));
    }

    public void REMOVE()
    {

        
        manager.CoroutineLoader(RepeatLerp(parent, Vector2.zero, duration));

        Draggable[] myItems = GameObject.FindObjectsOfType(typeof(Draggable)) as Draggable[];

        foreach (Draggable item in myItems)
        {
            GameObject.Destroy(item.gameObject);
            //GameObject.Destroy(item.gameObject);
        }
    }

    public IEnumerator RepeatLerp(Transform a, Vector3 b, float time)
    {
        float i = 0.0f;
        float s = speed;
        float rate = (1.0f / time) * s;
        while (i < 1.0f)
        {
            Debug.Log(s.ToString());
            s *= 1.0025f;
            i += Time.deltaTime * rate;
            a.localScale = Vector3.Slerp(a.localScale, b, i);
            yield return null;
        }
    }
    #endregion

    #region REUSABLE FUNCTIONS FOR LOGIC




    #endregion
}
