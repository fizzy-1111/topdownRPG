using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    // Start is called before the first frame update
    protected BoxCollider2D boxCollider;
    public float speed = 0.5f;
    protected float x;
    protected float y;
    RaycastHit2D hit;
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
   
    protected virtual void UpdateMotor(Vector3 input)
    {
        if (input.x > 0) transform.localScale = Vector3.one;
        else if (input.x < 0) transform.localScale = new Vector3(-1, 1, 1);



        input += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(input.x, 0), Mathf.Abs(input.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(input.x * Time.deltaTime * speed, 0, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, input.y), Mathf.Abs(input.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, input.y * Time.deltaTime * speed, 0);
           
        }
    }
}
