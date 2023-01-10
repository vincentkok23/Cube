using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public Player player;
    public float _SPEED;

    public bool _RIGHT;

    public List<Sprite> Arrows;

    //when you enter the button
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = Arrows[1];
        
    }
    //when you leave the button
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = Arrows[0];
        
    }
    //when button is pressed
    private void OnMouseDown()
    {
        if (_RIGHT) { player._speed = _SPEED; }
        else { player._speed = _SPEED; }
        
    }
    private void Update()
    {
        if (player._speed != 0) { Destroy(this.gameObject); }
    }

}
