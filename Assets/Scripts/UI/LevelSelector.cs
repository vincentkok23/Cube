using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject LevelIcon;
    public GameObject CheckIcon;
    public GameObject thisCanvas;
    public int numberOfLevel = 50;
    public Vector2 iconSpacing;
    private Rect panelDimensions;
    private Rect iconDimensions;
    public int amountPerPage;
    private int CurrentLevelCount;
    // Start is called before the first frame update
    void Start()
    {
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = LevelIcon.GetComponent<RectTransform>().rect;
        int maxInaRow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int MaxInaCol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        amountPerPage = maxInaRow * MaxInaCol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevel / (float)amountPerPage);
		Debug.Log(totalPages.ToString());
        LoadPanels(totalPages);

    }
    void LoadPanels(int numberOfPanels)
    {
        GameObject panelClone = Instantiate(levelHolder) as GameObject;
        PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();
        swiper.totalPages = numberOfPanels;

        for (int i = 1; i <= numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "page-" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            SetupGrid(panel);
            int numberOfIcons = i == numberOfPanels ? numberOfLevel - CurrentLevelCount : amountPerPage;
            LoadIcons(numberOfIcons, SavePrefs.ClearedList.Count, panel);
        }
        Destroy(panelClone);
    }
    void SetupGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = iconSpacing;

    }
    void LoadIcons(int numberOfIcons, int ClearedLevels,GameObject parentObject)
    {
        for (int i = 1; i <= ClearedLevels; i++)
        {
            CurrentLevelCount++;
            GameObject icon = Instantiate(CheckIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = i.ToString();
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText("" + CurrentLevelCount);
            int levelToLoad = i;
            icon.transform.GetComponent<Button>().onClick.AddListener(delegate { LoadScene(levelToLoad); });
        }

        for (int i = 1; i <= numberOfIcons - ClearedLevels; i++)
        {
            CurrentLevelCount++;
            GameObject icon = Instantiate(LevelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = i.ToString();
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText("" + CurrentLevelCount);
            int levelToLoad = i;
            icon.transform.GetComponent<Button>().onClick.AddListener(delegate { LoadScene(levelToLoad); });
        }
    }

    void LoadScene(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad );
    }

}