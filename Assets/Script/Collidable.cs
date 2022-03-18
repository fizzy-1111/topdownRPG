using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hit =new Collider2D[10];
    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hit); 
        for(int i = 0; i < hit.Length; i++)
        {
            if (hit[i] == null) continue;
            OnCollide(hit[i]);
            hit[i] = null;  
        }
    }
    protected virtual void OnCollide(Collider2D coll)
    {

    }
}
