using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Block_type { CHOOSE_A_TYPE, SPEED, SLOW, JUMP, GRAVITY };
public class BlockEffect : MonoBehaviour
{
    public Block_type Block_Type = Block_type.CHOOSE_A_TYPE;

    public float CubeSpeedMultiplier = 0.5f;
    public float bounce = 20f;
    public float tempSpeed;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        GameObject player = collision.gameObject;

        switch (Block_Type)
        {
            case Block_type.CHOOSE_A_TYPE:
                break;
            case Block_type.SPEED:
                SPEED();
                break;
            case Block_type.SLOW:
                SLOW();
                break;
            case Block_type.JUMP:
                JUMP(player);
                break;
            case Block_type.GRAVITY:
                GRAVITY(player);
                break;
            default:
                break;
        }
    }

    void SPEED()
    {
        //GameManager.Instance.CubeSpeed += CubeSpeedMultiplier;
    }

    void SLOW()
    {
       // GameManager.Instance.CubeSpeed -= CubeSpeedMultiplier;
    }

    void JUMP(GameObject player)
    {
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
    }

    void GRAVITY(GameObject player)
    {
        player.GetComponent<Rigidbody2D>();
    }

}




