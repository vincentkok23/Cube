using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{

    public GameObject leftArrow;
    public GameObject rightArrow;
    public void remove()
    {
        Destroy(leftArrow);
        Destroy(rightArrow);
    }
}
