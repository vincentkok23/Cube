using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;

    // Game Instance Singleton
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
	#endregion
	#region grid variables
	public int SelectedItem;
    public int rotations = 0;
    public GameObject[] ItemIndexes;
    public GridManager grid;


    

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("GridManager").GetComponent<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rotations++;
            SelectedItem++;
            if (rotations > 2)
            {
                SelectedItem -= rotations;
                rotations = 0;
            }
           
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(ray, ray,Mathf.Infinity);
            //Debug.Log(hit.collider.name);
            if (hit.collider != null)
            {
                Vector2 input = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                grid.PlaceObjectOnGrid(Mathf.RoundToInt(input.x), Mathf.RoundToInt(input.y), SelectedItem);
            }
        }
        
    }

    public void Place(int index)
    {
        SelectedItem = index;
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
