using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : AnimationEnemy {

    private const double e = 0.2f;

    public GameObject player;

    public Vector3 enemyDirection;
    [SerializeField]
    public float health = 1000;
    [SerializeField]
    public float maxhealth = 1000;
    [SerializeField]
    private float dmg = 100;

    [SerializeField]
    private Image content;
    private float currentFill;

    public GameObject bullet;

    private float AttackDelay = 0, speedShot = 4f;

    private Vector3 StartPosition;
    private GameObject gameOb;
    private float damge;

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
        AttackDelay += Time.deltaTime;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.count_enemy++;
            player.CountEnemy();
            player.BonusGold(100);
            player.BonusExp(65);
        }

        float distance = getDistance(player.transform.position, this.transform.position);

        float range = 5;
        float rangeAttack = 2;
        if (distance <= range * range && distance >= rangeAttack * rangeAttack)
        {
            enemyDirection = player.transform.position - this.transform.position;
            enemyDirection.Normalize();
            transform.Translate(enemyDirection * Time.deltaTime);
            direction.x = enemyDirection.x;
            direction.y = enemyDirection.y;
            //Debug.Log("X: " + direction.x);
        }
        else if(distance > range * range)
        {
            enemyDirection = StartPosition - this.transform.position;
            if (getDistance(StartPosition, this.transform.position) < e)
            {
                enemyDirection.x = 0;
                enemyDirection.y = 0;
            }
            enemyDirection.Normalize();
            transform.Translate(enemyDirection * Time.deltaTime);
            direction.x = enemyDirection.x;
            direction.y = enemyDirection.y;
        }
        else
        {
            if (AttackDelay >= 1)
            {
                Vector3 playerdirection = player.transform.position - this.transform.position;
                var rotation = Quaternion.LookRotation(playerdirection);
                playerdirection.Normalize();
                rotation.x = 0;
                rotation.y = 0;
                GameObject bulletclone = Instantiate(bullet, transform.position, rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = playerdirection * speedShot;
                Destroy(bulletclone, 2f);
                AttackDelay = 0;
            }
        }

        base.Update();
    }

    float getDistance(Vector3 vt1, Vector3 vt2)
    {
        float vtx = vt1.x - vt2.x,
            vty = vt1.y - vt2.y;
        return vtx * vtx + vty * vty;
    }

    void Damage(float dmg)
    {
        health -= dmg;
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
