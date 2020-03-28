using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPCs
{
    [SerializeField]
    private NPCs health;
    [SerializeField]
    private float healthValue = 10000;
    [SerializeField]
    private float maxHealthValue = 10000;
    [SerializeField]
    private float damge;
    [SerializeField]
    private GameObject gameOb;
    void Start()
    {
        health.Initialized(healthValue, maxHealthValue);
    }
    void Update()
    {
        changeHealth();
    }
    public float damgeValue(float damgeVl)
    {
        return damge = damgeVl;
    }
    public GameObject gO(GameObject gameO)
    {
        return gameOb = gameO;
    }
    public void changeHealth()
    {
        if (healthValue > 0)
        {
            healthValue -= damge;
            health.Initialized(healthValue, maxHealthValue);
            damge = 0;
        }
        else
        {
            Destroy(gameOb);
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.count_enemy++;
        }
    }
}
