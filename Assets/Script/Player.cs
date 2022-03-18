using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    Vector3 moveDelta;
    // Update is called once per frame
    private SpriteRenderer spriteRenderer;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        moveDelta = new Vector3(x, y, 0);
        UpdateMotor(moveDelta);
    }
    public void SwapSprite(int skinID)
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.Instance.playerSprites[skinID];
    }
    public void OnlevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }
}
