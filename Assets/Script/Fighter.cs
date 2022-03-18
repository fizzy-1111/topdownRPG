using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint;
    public int maxhitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    //Imunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push direction
    protected Vector3 pushDirection;

    //All Fighters can receive Damage 
    private void Awake()
    {
        maxHitpoint = hitpoint; 
    }
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.Instance.showText(dmg.damageAmount.ToString(), 20, Color.red, transform.position, Vector3.up * 20, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death(); 
            }
        }
    }

    protected virtual void Death()
    {

    }

}
