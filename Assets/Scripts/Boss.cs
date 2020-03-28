using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : AnimationEnemy {
    private const double e = 2;
    [SerializeField]
    public float health = 50000;
    [SerializeField]
    public float maxhealth = 50000;
    [SerializeField]
    private Image content;
    [SerializeField]
    private float dmg = 2000;
    [SerializeField]
    private float PhysicalAttackDamage = 1500;

    private float currentFill;

    public GameObject player;

    public Vector3 bossDirection;

    public GameObject bullet;

    public GameObject bigbullet;

    public GameObject BlueBullet;

    public GameObject PhysicalAttack;

    [SerializeField]
    private float damge;
    [SerializeField]
    private GameObject gameOb;

    private float AttackDelay = 0, speedShot = 4f,
        PhysicalAttackDelay = 0, Skill2Delay = 0;

    private Vector3 StartPosition;

    // Use this for initialization
    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartPosition = this.transform.position;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        Damage(damge);
        content.fillAmount = currentFill;
        PhysicalAttackDelay += Time.deltaTime;
        AttackDelay += Time.deltaTime;
        Skill2Delay += Time.deltaTime;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.count_boss++;
            player.CountEnemy();
            player.BonusGold(10000);
            player.BonusExp(2000);
            player.BonusIDamage(20);
            player.BonusIExp(20);
            player.BonusIHP(20);
            player.BonusISpeed(25);
        }

        float vtx = player.transform.position.x - this.transform.position.x,
            vty = player.transform.position.y - this.transform.position.y,
            distance = vtx * vtx + vty * vty;

        float range = 5;
        if (distance < e && PhysicalAttackDelay > 0.9)
        {
            player.SendMessageUpwards("Damage", PhysicalAttackDamage);
            Vector3 posision = new Vector3(0f, -1f, 0f);
            GameObject bulletclone = Instantiate(PhysicalAttack, transform.position + posision, transform.rotation) as GameObject;
            Destroy(bulletclone, 0.1f);
            PhysicalAttackDelay = 0;
        }

        if (distance < range * range)
        {
            if (AttackDelay >= 1)
            {
                Skill1();
                AttackDelay = 0;
            }
            if(player.transform.position.y + 0.9f < this.transform.position.y)
            {
                if (Skill2Delay >= 5)
                {
                    Skill2();
                    Skill2Delay = 0;
                }
            }
            else
            {
                if (Skill2Delay >= 5)
                {
                    Skill3();
                    Skill2Delay = 0;
                }
            }
        }

    }

    void Skill3()
    {
        Vector3 Vector = new Vector3(-1, 0, 0);
        var rotation = Quaternion.LookRotation(Vector);
        Vector.Normalize();
        rotation.x = 0;
        rotation.y = 0;
        GameObject bulletclone1 = Instantiate(BlueBullet, transform.position, rotation) as GameObject;
        bulletclone1.GetComponent<Rigidbody2D>().velocity = Vector * -speedShot;
        Destroy(bulletclone1, 3f);
        GameObject bulletclone2 = Instantiate(BlueBullet, transform.position, rotation) as GameObject;
        bulletclone2.GetComponent<Rigidbody2D>().velocity = Vector * speedShot;
        Destroy(bulletclone2, 3f);
    }

    void Skill2()
    {
        Vector3 Vector = new Vector3(0, 1, 0);
        Vector3 Vector2 = new Vector3(1, 0, 0);
        var rotation = Quaternion.LookRotation(Vector);
        Vector.Normalize();
        rotation.x = 0;
        rotation.y = 0;
        GameObject bulletclone1 = Instantiate(bigbullet, transform.position - Vector, rotation) as GameObject;
        bulletclone1.GetComponent<Rigidbody2D>().velocity = Vector * -speedShot;
        Destroy(bulletclone1, 3f);
        GameObject bulletclone2 = Instantiate(bigbullet, transform.position + Vector2, rotation) as GameObject;
        bulletclone2.GetComponent<Rigidbody2D>().velocity = Vector * -speedShot;
        Destroy(bulletclone2, 3f);
        GameObject bulletclone3 = Instantiate(bigbullet, transform.position - Vector2, rotation) as GameObject;
        bulletclone3.GetComponent<Rigidbody2D>().velocity = Vector * -speedShot;
        Destroy(bulletclone3, 3f);
    }

    void Skill1()
    {
        Fire(-1, 0);
        Fire(-1, -1);
        Fire(0, -1);
        Fire(1, -1);
        Fire(1, 0);
    }

    void Fire(float x, float y)
    {
        Vector3 Vector = new Vector3(x, y, 0);
        var rotation = Quaternion.LookRotation(Vector);
        Vector.Normalize();
        rotation.x = 0;
        rotation.y = 0;
        GameObject bulletclone = Instantiate(bullet, transform.position, rotation) as GameObject;
        bulletclone.GetComponent<Rigidbody2D>().velocity = Vector * speedShot;
        Destroy(bulletclone, 2f);
    }

    void Damage(float dmg)
    {
        health -= dmg * 0.75f;
        currentFill = health / maxhealth;
    }

    public float damgeValue(float damgeVl)
    {
        return damge = damgeVl;
    }
    public GameObject gO(GameObject gameO)
    {
        return gameOb = gameO;
    }
}
