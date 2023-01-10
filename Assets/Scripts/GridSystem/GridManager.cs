using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GRID_TYPE { CHOOSE_A_TYPE , EDITOR , TILEDATA };

public class GridManager : MonoBehaviour
{
	//Edit this if you want a bigger grid while USING @TILEDATA
	//[ X , Y ] cords
	static int[,] TileDataSize = new int[18,10]; 


    #region TOUCH AT OWN RISK
	//type of grid
    public GRID_TYPE GRID_TYPE = GRID_TYPE.CHOOSE_A_TYPE;


	//basics for gridmap
	[Header("Grid Propertys")]
	public float Block_Size = 1f;
	public bool BlockRotations = true;
	public bool Centered = true;
	public Transform Parent;

	//debug informations
	[Header("Debug Options")]
	public bool debug_text = false;
	public bool debug_logs = false;

	//the position of the grid
	private Vector3 OriginPosition;
	private string WORLDNAME;

	//the grid size for building your own map inside of game
	[Header("Grid Size")]
	public int Width;
	public int Height;
	//a standard grid map always the same on enter
	public TileData TileData = new TileData(TileDataSize);

	[HideInInspector]public Grid GridMap;

	// Start is called before the first frame update
	void Start()
	{
		if (GRID_TYPE == GRID_TYPE.TILEDATA)
		{
			Width = TileData.x.Length;
			Height = TileData.y.Length;
			if (debug_logs)
			{
				Debug.Log($"TileData 1D array length = {TileData.INDEX.Length}");
				Debug.Log($"total variables needed in 1D array = {Width * Height}");
			}
		}
			

		if (Centered) { OriginPosition = new Vector3(-Width / 2 * Block_Size, -Height / 2 * Block_Size); }


		if (Parent == null) { Parent = this.gameObject.transform; }

        switch (GRID_TYPE)
        {
            case GRID_TYPE.EDITOR:
				GridMap = new Grid(Width, Height, Block_Size, OriginPosition, Parent, debug_text);
				break;
            case GRID_TYPE.TILEDATA:
				GridMap = new Grid(TileData, Block_Size, OriginPosition, Parent, debug_text, BlockRotations);
				break;
            default:
                break;
        }
	}

	private void Update()
	{
		

	}

	#region EDITOR grid things
	public void PlaceObjectOnGrid(int X, int Y, int value)
	{
		//all variables needed
		int x, y;
		int result;
		Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GridMap.GetXY(position, out x, out y);
		result = GridMap.GetValue(x, y);
		Vector3 worldPosition = GridMap.GetWorldPosition(x, y) + new Vector3(GridMap.cellSize, GridMap.cellSize) * 0.5f;
		
		///save object for easyer refrence
		GameObject Object = GameManager.Instance.ItemIndexes[value];

		if(!debug_text) { GridMap.SetValue(X, Y, value,false); }
		else { GridMap.SetValue(X, Y, value, true); }
		
		///Spawn in the objects and set the load value
		GridMap.SetValue(position, value, debug_text);
		if (!BlockRotations) { GridMap.Objects[x, y] = Instantiate(Object, worldPosition, Quaternion.identity, Parent); }
		else { GridMap.Objects[x, y] = Instantiate(Object, worldPosition, Object.transform.rotation, Parent); }
	}

	private void OnApplicationQuit()
	{
		if (GRID_TYPE == GRID_TYPE.EDITOR) { GridMap.SaveGrid(WORLDNAME); }
	}
	#endregion
	#endregion
}
