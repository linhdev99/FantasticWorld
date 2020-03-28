using UnityEngine;
using UnityEngine.UI;

public class Enemy4 : AnimationEnemy
{
    private const double e = 0.5f;
    public GameObject player;
    public Vector3 enemyDirection;
    [SerializeField]
    public float health = 1500;
    [SerializeField]
    public float maxhealth = 1500;
    [SerializeField]
    private float dmg = 200;

    [SerializeField]
    private Image content;

    private float currentFill;

    public GameObject enemy;

    private float AttackDelay = 0;

    private Vector3 StartPosition;
    private GameObject gameOb;
    private float damge;

    // Use this for initialization
    protected override void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        StartPosition = this.transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        content.fillAmount = currentFill;
        Damage(damge);
        AttackDelay += Time.deltaTime;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.count_enemy++;
            player.CountEnemy();
            player.BonusGold(500);
            player.BonusExp(100);
        }

        float distance = getDistance(player.transform.position, this.transform.position);

        float range = 4;
        if (distance < range * range)
        {
            enemyDirection = player.transform.position - this.transform.position;
            enemyDirection.Normalize();
            transform.Translate(enemyDirection * Time.deltaTime);
            direction.x = enemyDirection.x;
            direction.y = enemyDirection.y;

        }
        else
        {
            enemyDirection = StartPosition - this.transform.position;
            if(getDistance(StartPosition,this.transform.position)<e)
            {
                enemyDirection.x = 0;
                enemyDirection.y = 0;
            }
            enemyDirection.Normalize();
            transform.Translate(enemyDirection * Time.deltaTime);
            direction.x = enemyDirection.x;
            direction.y = enemyDirection.y;
        }

        IsImpact(distance);

        base.Update();
    }

    float getDistance(Vector3 vt1, Vector3 vt2)
    {
        float vtx = vt1.x - vt2.x,
            vty = vt1.y - vt2.y;
            return vtx * vtx + vty * vty;
    }

    void IsImpact(float distance)
    {
        if (((distance <= e)) && AttackDelay >= 1)
        {
            player.SendMessageUpwards("Damage", dmg);

            AttackDelay = 0;
        }
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