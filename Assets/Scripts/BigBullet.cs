using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour {

    public GameObject player;

    private float dmg = 1000f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Hit");
            Destroy(gameObject);
            player.SendMessageUpwards("Damage", dmg);
        }
        else if (collision.CompareTag("Topographic"))
        {
            //Debug.Log("Hit Collider");
            Destroy(gameObject);
        }
    }
}
