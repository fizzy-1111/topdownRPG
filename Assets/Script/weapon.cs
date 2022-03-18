using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : Collidable
{
    public int[] damagePoint = { 1,2,3,4,5,6,7};
    public float[] pushForce = { 5f ,5.5f,6f,6.5f,7f,7.5f,8f};

    //Upgrade 
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Swing
    private float cooldown = 0.5f;
    private float lastSwing;

    private Animator anim;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        base.Start();
       
        anim = GetComponent<Animator>();

    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
               
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing(); 
            }
        }
    }
    private void Swing()
    {
        anim.SetTrigger("swing");
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                return;
            }
            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel], 
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
    public void UpgradeWeapon()
    {

        weaponLevel++;
        spriteRenderer.sprite = GameManager.Instance.weaponSprites[weaponLevel];
    }
    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.Instance.weaponSprites[weaponLevel];
    }
}
