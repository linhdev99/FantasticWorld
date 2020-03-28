using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Spell : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb;
    string direc;
    public float healthEnemy;
    private Boss boss;
    private Enemy2 enemy2;
    private Enemy3 enemy3;
    private Enemy4 enemy4;
    void Start()
    {
        direc = PlayerPrefs.GetString("direction");
        if (direc == "1")
        {
            rb.velocity = transform.up * speed;
        }
        else if (direc == "2")
        {
            rb.velocity = -transform.up * speed; // down
        }
        else if (direc == "3")
        {
            rb.velocity = -transform.right * speed; //left
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
        StartCoroutine(timer(0.65f));
    }
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        boss = GetComponent<Boss>();
        enemy2 = GetComponent<Enemy2>();
        enemy3 = GetComponent<Enemy3>();
        enemy4 = GetComponent<Enemy4>();
        
    }
    private IEnumerator timer(float sec)
    {
        yield return new WaitForSeconds(sec);
        rb.velocity = transform.right * 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            GetComponent<Animator>().SetTrigger("impact");
            rb.velocity = transform.right * 0;
            GameObject gO = collision.gameObject;
            boss = gO.GetComponent<Boss>();
            float damage = PlayerPrefs.GetFloat("playerDamge");
            boss.SendMessageUpwards("Damage", damage);
            boss.gO(gO);
        }
        else if (collision.tag == "Enemy2")
        {
            GetComponent<Animator>().SetTrigger("impact");
            rb.velocity = transform.right * 0;
            GameObject gO = collision.gameObject;
            enemy2 = gO.GetComponent<Enemy2>();
            float damage = PlayerPrefs.GetFloat("playerDamge");
            enemy2.SendMessageUpwards("Damage", damage);
            enemy2.gO(gO);
        }
        else if (collision.tag == "Enemy3")
        {
            GetComponent<Animator>().SetTrigger("impact");
            rb.velocity = transform.right * 0;
            GameObject gO = collision.gameObject;
            enemy3 = gO.GetComponent<Enemy3>();
            float damage = PlayerPrefs.GetFloat("playerDamge");
            enemy3.SendMessageUpwards("Damage", damage);
            enemy3.gO(gO);
        }
        else if (collision.tag == "Enemy4")
        {
            GetComponent<Animator>().SetTrigger("impact");
            rb.velocity = transform.right * 0;
            GameObject gO = collision.gameObject;
            enemy4 = gO.GetComponent<Enemy4>();
            float damage = PlayerPrefs.GetFloat("playerDamge");
            enemy4.SendMessageUpwards("Damage", damage);
            enemy4.gO(gO);
        }
    }
}
