using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int coin = 10;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.Instance.coins += coin;
            GameManager.Instance.showText("+ " + coin + " coins", 30,Color.yellow, transform.position, Vector3.up *50, 0.5f);
            
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
    }
}
