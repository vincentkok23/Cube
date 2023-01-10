using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    #region TOUCH AT OWN RISK

    private static HotbarManager instance = null;

    // Game Instance Singleton
    public static HotbarManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }


    public Hotbar Hotbar;

    private void Start()
    {
        if (Hotbar.parent == null) { Hotbar.parent = this.transform; }
        if (Hotbar.EDITOR) {
            Hotbar.ItemInventory.Clear();
            for (int i = 0; i < GameManager.Instance.ItemIndexes.Length; i++)
            {
                Hotbar.ItemInventory.Add(GameManager.Instance.ItemIndexes[i]);
            }
            return;
        }
        Hotbar.RELOAD();
    }

    public void CoroutineLoader(IEnumerator yourCoroutine)
    {
        StartCoroutine(yourCoroutine);
    }
    #endregion

}
