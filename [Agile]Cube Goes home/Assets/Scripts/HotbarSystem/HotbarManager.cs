using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    #region TOUCH AT OWN RISK
    public Hotbar Hotbar;

    private void Start()
    {
        if (Hotbar.parent == null) { Hotbar.parent = this.transform; }
        Hotbar.RELOAD();
    }

    public void CoroutineLoader(IEnumerator yourCoroutine)
    {
        StartCoroutine(yourCoroutine);
    }
    #endregion

}
