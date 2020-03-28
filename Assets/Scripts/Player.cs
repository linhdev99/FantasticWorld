using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public partial class Player : Character
{
    // Health
    [SerializeField]
    private Stat health;
    //[SerializeField]
    private float healthValue = 10000;
    //[SerializeField]
    private float maxHealthValue = 10000;
    private float dmg;

    // Experience
    [SerializeField]
    private Stat exp;
    // [SerializeField]
    private float expValue = 1000;
    //[SerializeField]
    private float maxExpValue = 1000;

    //Skill 1
    [SerializeField]
    private Stat skillOne;
    // [SerializeField]
    private float skillOneValue = 0;
    // [SerializeField]
    private float maxSkillOneValue = 50;

    //Skill 2
    [SerializeField]
    private Stat skillTwo;
    //[SerializeField]
    private float skillTwoValue = 0;
    //[SerializeField]
    private float maxSkillTwoValue = 100;

    //Skill 3
    [SerializeField]
    private Stat skillThree;
    //[SerializeField]
    private float skillThreeValue = 0;
    // [SerializeField]
    private float maxSkillThreeValue = 150;

    //Skill 4
    [SerializeField]
    private Stat skillFour;
    //[SerializeField]
    private float skillFourValue = 0;
    //[SerializeField]
    private float maxSkillFourValue = 200;

    [SerializeField]
    private StatText textHealth;

    [SerializeField]
    private StatText textExp;

    [SerializeField]
    private SetText textLvl;

    [SerializeField]
    private GameObject[] spellPrefab;

    [SerializeField]
    private Transform[] exitPoints;

    private Transform pos;

    public int vTemp = 4;
    public bool waiting = true;

    private GameObject gOEffectSkill;

    [SerializeField]
    private ChangeData data_player;
    [SerializeField]
    private ReadPosition pos_player;

    private float damage_0;
    private float damage_1;
    private float damage_2;
    private float damage_3;
    private float damage_4;
    private float item_1;
    private float item_2;
    private float item_3;
    private float item_4;
    private float level;
    private bool waitItem2 = false;
    private bool waitItem4 = false;
    private float gold;
    //private Transform target;

    [SerializeField]
    private Stat MenuHP;
    [SerializeField]
    private Stat MenuExp;
    [SerializeField]
    private SetText1 MenuTxtHP;
    [SerializeField]
    private SetText1 MenuTxtExp;
    [SerializeField]
    private SetText1 MenuTxtGold;
    [SerializeField]
    private SetText1 MenuTxtDamage0;
    [SerializeField]
    private SetText1 MenuTxtDamage1;
    [SerializeField]
    private SetText1 MenuTxtDamage2;
    [SerializeField]
    private SetText1 MenuTxtDamage3;
    [SerializeField]
    private SetText1 MenuTxtDamage4;
    [SerializeField]
    private SetText1 MenuTxtItem1;
    [SerializeField]
    private SetText1 MenuTxtItem2;
    [SerializeField]
    private SetText1 MenuTxtItem3;
    [SerializeField]
    private SetText1 MenuTxtItem4;
    [SerializeField]
    private GameObject MenuInfomation;
    private bool isMenuShow = false;
    private string str_notice = "";
    [SerializeField]
    private SetText1 Notice;
    private bool isNoticeShow = true;
    [SerializeField]
    private GameObject ListNotice;
    public Transform myTarget
    {
        get;
        set;
    }
    [SerializeField]
    private ReadMission readMission;
    private string[] ID_M = new string[8];
    private string[] NAME_M = new string[8];
    private int[] STATUS_M = new int[8];
    private int[] MAX_COUNT_M = new int[8];
    private int[] CUR_COUNT_M = new int[8];
    private bool isDMShow = false;
    [SerializeField]
    private GameObject DialogMission;
    [SerializeField]
    private SetText1 setNameMission;
    [SerializeField]
    private SetText1 setRateMission;
    public int count_enemy = 0;
    public int count_boss = 0;
    [SerializeField]
    private GameObject NoticeMain;
    private bool checkPlayerDie = false;
    protected override void Start()
    {
        pos = GetComponent<Transform>();
        setData();
        readMissionAll();
        health.Initialized(healthValue, maxHealthValue);
        //myTarget = GameObject.Find("Target").transform;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!checkPlayerDie)
        {
            GetInput();
        }
        if (Input.GetKey(KeyCode.P) && Input.GetKeyDown(KeyCode.P))
        {
            if (checkPlayerDie)
            {
                Revival();
            }
        }
        BuyItem();
        IsAttacked(dmg);
        NoticeDie();
        if (myTarget != null)
        {
            InLineOfSign();
        }
        base.Update();
    }

    private void changePosition()
    {
        data_player.POSX = pos.position.x;
        data_player.POSY = pos.position.y;
        //Debug.Log(pos.position.x);
    }
    public void readMissionAll()
    {
        PlayerPrefs.SetInt("CHECK_MISSION", 0);
        readMission.Reading();
        for (int i = 0; i < 8; i++)
        {
            ID_M[i] = readMission.ID[i];
            NAME_M[i] = readMission.NAME[i];
            STATUS_M[i] = readMission.STATUS[i];
            MAX_COUNT_M[i] = readMission.MAX_COUNT[i];
            CUR_COUNT_M[i] = readMission.CUR_COUNT[i];
            if (STATUS_M[i] == 1)
            {
                PlayerPrefs.SetInt("CHECK_MISSION", 1);
                count_enemy = CUR_COUNT_M[i];
                count_boss = CUR_COUNT_M[i];
            }
        }
    }
    private void setData()
    {
        // MaxExp = Level * 1000 + [((Level-1) * 2170) % 249] * 10;
        // MaxHp = MaxExp * 10;
        data_player.ReadString();
        healthValue = data_player.HEALTH;
        maxHealthValue = data_player.MAX_HEALTH;
        expValue = data_player.EXP;
        maxExpValue = data_player.MAX_EXP;
        maxSkillOneValue = data_player.TIME_SKIIL_1;
        maxSkillTwoValue = data_player.TIME_SKIIL_2;
        maxSkillThreeValue = data_player.TIME_SKIIL_3;
        maxSkillFourValue = data_player.TIME_SKIIL_4;
        speed = data_player.SPEED;
        damage_0 = data_player.DAMAGE_0;
        damage_1 = data_player.DAMAGE_1;
        damage_2 = data_player.DAMAGE_2;
        damage_3 = data_player.DAMAGE_3;
        damage_4 = data_player.DAMAGE_4;
        item_1 = data_player.ITEM_1;
        item_2 = data_player.ITEM_2;
        item_3 = data_player.ITEM_3;
        item_4 = data_player.ITEM_4;
        level = data_player.LEVEL;
        gold = data_player.GOLD;
        textLvl.setText(data_player.LEVEL.ToString());
        pos.position = new Vector3(data_player.POSX, data_player.POSY, 0);

        health.Initialized(healthValue, maxHealthValue);
        exp.Initialized(expValue, maxExpValue);
        skillOne.Initialized(skillOneValue, maxSkillOneValue);
        skillTwo.Initialized(skillTwoValue, maxSkillTwoValue);
        skillThree.Initialized(skillThreeValue, maxSkillThreeValue);
        skillFour.Initialized(skillFourValue, maxSkillFourValue);

        textHealth.Initialized(healthValue, maxHealthValue);
        textExp.Initialized(expValue, maxExpValue);
        PlayerPrefs.SetFloat("playerDamge", 0f);

        MenuItem();
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.F1) && Input.GetKeyDown(KeyCode.F1))
        {
            changePosition();
            data_player.Change();
            str_notice += "\nSave success...";
            Notice.setText(str_notice);
        }
        if (Input.GetKey(KeyCode.V) && Input.GetKeyDown(KeyCode.V))
        {
            if (isNoticeShow)
            {
                isNoticeShow = false;
                ListNotice.SetActive(isNoticeShow);
            }
            else
            {
                isNoticeShow = true;
                ListNotice.SetActive(isNoticeShow);
            }
        }
        if (Input.GetKey(KeyCode.B) && Input.GetKeyDown(KeyCode.B))
        {
            if (isMenuShow)
            {
                isMenuShow = false;
                MenuInfomation.SetActive(isMenuShow);
                //str_notice += "\nClose Equip!";
            }
            else
            {
                isMenuShow = true;
                MenuInfomation.SetActive(isMenuShow);
                //str_notice += "\nOpen Equip!";
            }
            MenuItem();
            Notice.setText(str_notice);
        }
        if (Input.GetKey(KeyCode.N) && Input.GetKeyDown(KeyCode.N))
        {
            if (isDMShow)
            {
                isDMShow = false;
                DialogMission.SetActive(isDMShow);
                //str_notice += "\nClose Dialog Mission!";
            }
            else
            {
                isDMShow = true;
                DialogMission.SetActive(isDMShow);
                //str_notice += "\nOpen Dialog Mission!";
            }
            ShowDialogMission();
            Notice.setText(str_notice);
        }
        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem1();
            MenuItem();
        }
        if (Input.GetKey(KeyCode.Alpha2) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem2();
            MenuItem();
        }
        if (Input.GetKey(KeyCode.Alpha3) && Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem3();
            MenuItem();
        }
        if (Input.GetKey(KeyCode.Alpha4) && Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem4();
            MenuItem();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
            vTemp = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
            vTemp = 2;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
            vTemp = 3;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
            vTemp = 4;
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Start SKill Normal");
            if (!isAttacking)// && !isMoving)
            {
                SoundController.PlaySound(soundsGame.hit);
                StartCoroutine(waitSkill(0));
                PlayerPrefs.SetFloat("playerDamge", damage_0);
            }
            else
            {
                //Debug.Log("Can't use skill Normal");
            }
        }
        if (Input.GetKey(KeyCode.Q) && skillOneValue <= 0)
        {
            //Debug.Log("Start SKill 1");
            if (!isAttacking && !isMoving)
            {
                SoundController.PlaySound(soundsGame.skill);
                attackRoutine = StartCoroutine(Attack());
                skillOneValue = maxSkillOneValue;
                StartCoroutine(waitSkill(1));
                PlayerPrefs.SetFloat("playerDamge", damage_1);
            }
            else
            {
                //Debug.Log("Can't use skill 1");
            }
        }
        if (Input.GetKey(KeyCode.W) && skillTwoValue <= 0)
        {
            //Debug.Log("Start SKill 2");
            if (!isAttacking && !isMoving)
            {
                SoundController.PlaySound(soundsGame.skill);
                attackRoutine = StartCoroutine(Attack());
                skillTwoValue = maxSkillTwoValue;
                StartCoroutine(waitSkill(2));
                PlayerPrefs.SetFloat("playerDamge", damage_2);
            }
            else
            {
                //Debug.Log("Can't use skill 2");
            }
        }
        if (Input.GetKey(KeyCode.E) && skillThreeValue <= 0)
        {
            //Debug.Log("Start SKill 3");
            if (!isAttacking && !isMoving)
            {
                SoundController.PlaySound(soundsGame.skill);
                attackRoutine = StartCoroutine(Attack());
                skillThreeValue = maxSkillThreeValue;
                StartCoroutine(waitSkill(3));
                PlayerPrefs.SetFloat("playerDamge", damage_3);
            }
            else
            {
                //Debug.Log("Can't use skill 3");
            }
        }
        if (Input.GetKey(KeyCode.R) && skillFourValue <= 0)
        {
            //Debug.Log("Start SKill Ulti");
            if (!isAttacking && !isMoving)
            {
                SoundController.PlaySound(soundsGame.skill);
                attackRoutine = StartCoroutine(Attack());
                skillFourValue = maxSkillFourValue;
                StartCoroutine(waitSkill(4));
                PlayerPrefs.SetFloat("playerDamge", damage_4);
            }
            else
            {
                //Debug.Log("Can't use skill Ulti");
            }
        }
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("attack", isAttacking);
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("danh xong");
        StopAttack();
    }
    private IEnumerator waitSkill(int skill)
    {
        Transform currentTarget = myTarget;
        switch (skill)
        {
            case 0:
                {
                    isAttacking = true;
                    animator.SetBool("attack", isAttacking);
                    castSpell(0);
                    yield return new WaitForSeconds(2f);
                    StopAttack();
                    //Debug.Log("Done Cast");
                    break;
                }
            case 1:
                {
                    isAttacking = true;
                    animator.SetBool("attack", isAttacking);
                    castSpell(1);
                    for (float i = maxSkillOneValue; i >= 0; i--)
                    {
                        skillOneValue = i;
                        skillOne.Initialized(skillOneValue, maxSkillOneValue);
                        yield return new WaitForSeconds(0.1f);
                    }
                    StopAttack();
                    //Debug.Log("Done Cast");
                    break;
                }
            case 2:
                {
                    isAttacking = true;
                    animator.SetBool("attack", isAttacking);
                    castSpell(2);
                    for (float i = maxSkillTwoValue; i >= 0; i--)
                    {
                        skillTwoValue = i;
                        skillTwo.Initialized(skillTwoValue, maxSkillTwoValue);
                        yield return new WaitForSeconds(0.1f);
                    }
                    StopAttack();
                    //Debug.Log("Done Cast");
                    break;
                }
            case 3:
                {
                    isAttacking = true;
                    animator.SetBool("attack", isAttacking);
                    castSpell(3);
                    for (float i = maxSkillThreeValue; i >= 0; i--)
                    {
                        skillThreeValue = i;
                        skillThree.Initialized(skillThreeValue, maxSkillThreeValue);
                        yield return new WaitForSeconds(0.1f);
                    }
                    StopAttack();
                    // Debug.Log("Done Cast");
                    break;
                }
            case 4:
                {
                    isAttacking = true;
                    animator.SetBool("attack", isAttacking);
                    castSpell(4);
                    for (float i = maxSkillFourValue; i >= 0; i--)
                    {
                        skillFourValue = i;
                        skillFour.Initialized(skillFourValue, maxSkillFourValue);
                        yield return new WaitForSeconds(0.1f);
                    }
                    StopAttack();
                    //Debug.Log("Done Cast");
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    public void castSpell(int numSkill)
    {
        if (numSkill == 0 || numSkill == 4)
        {
            if (vTemp == 1)
            {
                gOEffectSkill = Instantiate(spellPrefab[numSkill], exitPoints[vTemp - 1].position, Quaternion.identity);
            }
            else if (vTemp == 2)
            {
                gOEffectSkill = Instantiate(spellPrefab[numSkill + 1], exitPoints[vTemp - 1].position, Quaternion.identity);
            }
            else if (vTemp == 3)
            {
                gOEffectSkill = Instantiate(spellPrefab[numSkill + 2], exitPoints[vTemp - 1].position, Quaternion.identity);
            }
            else
            {
                gOEffectSkill = Instantiate(spellPrefab[numSkill + 3], exitPoints[vTemp - 1].position, Quaternion.identity);
            }
        }
        else
        {
            gOEffectSkill = Instantiate(spellPrefab[numSkill + 7], exitPoints[vTemp - 1].position, Quaternion.identity);
        }
        gOEffectSkill.GetComponent<SpriteRenderer>().sortingOrder = 5;
        PlayerPrefs.SetString("direction", vTemp.ToString());
        Destroy(gOEffectSkill, 0.7f);
    }
    private bool InLineOfSign()
    {
        //Debug.Log("click");
        if (myTarget != null)
        {
            Vector3 targetDirection = (myTarget.transform.position - transform.position).normalized;
            Debug.DrawRay(transform.position, targetDirection, Color.red);
        }
        return false;
    }
    private void MenuItem()
    {
        MenuHP.Initialized(healthValue, maxHealthValue);
        MenuExp.Initialized(expValue, maxExpValue);
        MenuTxtHP.setText("HP : " + healthValue + "/" + maxHealthValue);
        MenuTxtExp.setText("EXP: " + expValue + "/" + maxExpValue);
        MenuTxtGold.setText(data_player.GOLD.ToString() + "$");
        MenuTxtDamage0.setText(data_player.DAMAGE_0.ToString());
        MenuTxtDamage1.setText(data_player.DAMAGE_1.ToString());
        MenuTxtDamage2.setText(data_player.DAMAGE_2.ToString());
        MenuTxtDamage3.setText(data_player.DAMAGE_3.ToString());
        MenuTxtDamage4.setText(data_player.DAMAGE_4.ToString());
        MenuTxtItem1.setText(data_player.ITEM_1.ToString());
        MenuTxtItem2.setText(data_player.ITEM_2.ToString());
        MenuTxtItem3.setText(data_player.ITEM_3.ToString());
        MenuTxtItem4.setText(data_player.ITEM_4.ToString());
    }
    public void UseItem1() //HP
    {
        if (healthValue == maxHealthValue || item_1 == 0)
        {
            //Debug.Log("Can't use item!");
        }
        else
        {
            float HP_UP = maxHealthValue * 0.1f;
            data_player.HEALTH = healthValue + HP_UP;
            data_player.ITEM_1 = item_1 - 1;
            if (data_player.HEALTH >= data_player.MAX_HEALTH)
            {
                data_player.HEALTH = data_player.MAX_HEALTH;
            }
            changePosition();
            data_player.Change();
            setData();
            health.Initialized(healthValue, maxHealthValue);
            textHealth.Initialized(healthValue, maxHealthValue);
            str_notice += "\nUse HP up!";
            Notice.setText(str_notice);
        }
    }
    public void UseItem2() //Damage
    {
        if (item_2 == 0 || damage_0 > data_player.DAMAGE_0 || waitItem2)
        {
            //Debug.Log("Can't use item!");
        }
        else
        {
            item_2--;
            data_player.ITEM_2 = item_2;
            data_player.WriteString();
            StartCoroutine(ChangeDamageTime(10f));
            str_notice += "\nUse Damage up!";
            Notice.setText(str_notice);
        }
    }
    public void UseItem3() //Exp
    {
        if (item_3 == 0)
        {
            //Debug.Log("Can't use item!");
        }
        else
        {
            item_3--;
            data_player.ITEM_3 = item_3;
            float ExpUP = 1000;
            while (ExpUP > 0)
            {
                expValue += ExpUP;
                ExpUP = expValue - maxExpValue;
                if (expValue > maxExpValue)
                {
                    level++;
                    // MaxExp = Level * 1000 + [((Level-1) * 2170) % 249] * 10;
                    maxExpValue = level * 100 + (((level - 1) * 217) % 249);
                    maxHealthValue = healthValue = maxExpValue * 5;
                    expValue = 0;
                }
            }
            data_player.LEVEL = level;
            data_player.MAX_EXP = maxExpValue;
            data_player.EXP = expValue;
            data_player.HEALTH = healthValue;
            data_player.MAX_HEALTH = maxHealthValue;
            data_player.DAMAGE_0 = 50 + 50 * (level - 1) / 10;
            data_player.DAMAGE_1 = 75 + 75 * (level - 1) / 10;
            data_player.DAMAGE_2 = 100 + 100 * (level - 1) / 10;
            data_player.DAMAGE_3 = 135 + 135 * (level - 1) / 10;
            data_player.DAMAGE_4 = 200 + 200 * (level - 1) / 10;
            changePosition();
            data_player.Change();
            setData();
            str_notice += "\nUse Exp up!";
            Notice.setText(str_notice);
        }
    }
    public void UseItem4() //Speed
    {
        if (item_4 == 0 || speed > data_player.SPEED || waitItem4)
        {
            // Debug.Log("Can't use item!");
        }
        else
        {
            item_4--;
            data_player.ITEM_4 = item_4;
            data_player.WriteString();
            StartCoroutine(ChangeSpeedTime(10f));
            str_notice += "\nUse Speed up!";
            Notice.setText(str_notice);
        }
    }
    public IEnumerator ChangeDamageTime(float time)
    {
        waitItem2 = true;
        float DAMAGE_UP = damage_0 * 10f;
        damage_0 = DAMAGE_UP;
        yield return new WaitForSeconds(time);
        damage_0 = data_player.DAMAGE_0;
        waitItem2 = false;
    }
    public IEnumerator ChangeSpeedTime(float time)
    {
        waitItem4 = true;
        float SPEED_UP = speed * 5f;
        speed = SPEED_UP;
        yield return new WaitForSeconds(time);
        speed = data_player.SPEED;
        waitItem4 = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ChangeMap")
        {
            NextMap(collision.name);
        }
    }
    private void NextMap(string str_map)
    {
        if (!checkMission())
        {
            str_notice += "\nYou need receive the mission!";
            Notice.setText(str_notice);
            return;
        }
        if (str_map == "NextMap1")
        {
            str_notice += "\nWelcome to Ice Land!";
            Notice.setText(str_notice);
            data_player.MAP = 1;
            data_player.POSX = pos_player.START_1_X;
            data_player.POSY = pos_player.START_1_Y;
            data_player.Change();
            setData();
            SceneManager.LoadScene("Map" + data_player.MAP);
        }
        else if (str_map == "NextMap2")
        {
            str_notice += "\nWelcome to BKU Cave!";
            Notice.setText(str_notice);
            data_player.MAP = 2;
            data_player.POSX = pos_player.START_2_X;
            data_player.POSY = pos_player.START_2_Y;
            data_player.Change();
            setData();
            SceneManager.LoadScene("Map" + data_player.MAP);
        }
        else if (str_map == "NextMap3")
        {
            str_notice += "\nWelcome to Mirare Village!";
            Notice.setText(str_notice);
            data_player.MAP = 3;
            data_player.POSX = pos_player.START_3_X;
            data_player.POSY = pos_player.START_3_Y;
            data_player.Change();
            setData();
            SceneManager.LoadScene("Map" + data_player.MAP);
        }
        else if (str_map == "BackMap")
        {
            if (data_player.MAP == 1)
            {
                data_player.POSX = pos_player.M0_1_X;
                data_player.POSY = pos_player.M0_1_Y;
                str_notice += "\nWelcome to Hizo City!";
            }
            else if (data_player.MAP == 2)
            {
                data_player.POSX = pos_player.M0_2_X;
                data_player.POSY = pos_player.M0_2_Y;
                str_notice += "\nWelcome to Mikasa City!";
            }
            else if (data_player.MAP == 3)
            {
                data_player.POSX = pos_player.M0_3_X;
                data_player.POSY = pos_player.M0_3_Y;
                str_notice += "\nWelcome to Mega City!";
            }
            Notice.setText(str_notice);
            data_player.MAP = 0;
            data_player.Change();
            setData();
            SceneManager.LoadScene("Map" + data_player.MAP);
        }
    }
    private void BuyItem()
    {
        if (PlayerPrefs.GetInt("ItemDamage") == 1)
        {
            PlayerPrefs.SetInt("ItemDamage", 0);
            if (gold >= 2000)
            {
                gold -= 2000;
                data_player.GOLD = gold;
                data_player.ITEM_2 = data_player.ITEM_2 + 1;
                changePosition();
                data_player.Change();
                setData();
                str_notice += "\nBuy item Damage Up!";
                Notice.setText(str_notice);
            }
        }
        if (PlayerPrefs.GetInt("ItemHP") == 1)
        {
            PlayerPrefs.SetInt("ItemHP", 0);
            if (gold >= 1000)
            {
                gold -= 1000;
                data_player.GOLD = gold;
                data_player.ITEM_1 = data_player.ITEM_1 + 1;
                changePosition();
                data_player.Change();
                setData();
                str_notice += "\nBuy item HP Up!";
                Notice.setText(str_notice);
            }
        }
        if (PlayerPrefs.GetInt("ItemEXP") == 1)
        {
            PlayerPrefs.SetInt("ItemEXP", 0);
            if (gold >= 5000)
            {
                gold -= 5000;
                data_player.GOLD = gold;
                data_player.ITEM_3 = data_player.ITEM_3 + 1;
                changePosition();
                data_player.Change();
                setData();
                str_notice += "\nBuy item EXP Up!";
                Notice.setText(str_notice);
            }
        }
        if (PlayerPrefs.GetInt("ItemSpeed") == 1)
        {
            PlayerPrefs.SetInt("ItemSpeed", 0);
            if (gold >= 500)
            {
                gold -= 500;
                data_player.GOLD = gold;
                data_player.ITEM_4 = data_player.ITEM_4 + 1;
                changePosition();
                data_player.Change();
                setData();
                str_notice += "\nBuy item Speed Up!";
                Notice.setText(str_notice);
            }
        }
    }


    void Damage(float damage)
    {
        dmg = damage;
    }

    void IsAttacked(float damage)
    {
        healthValue -= dmg;
        health.Initialized(healthValue, maxHealthValue);
        textHealth.Initialized(healthValue, maxHealthValue);
        dmg = 0;
    }

    public void ShowDialogMission()
    {
        readMission.Reading();
        int checkMission = 0;
        for (int i = 0; i < 8; i++)
        {
            if (STATUS_M[i] == 1)
            {
                checkMission++;
                setNameMission.setText(NAME_M[i]);
                setRateMission.setText(CUR_COUNT_M[i] + "/" + MAX_COUNT_M[i]);
                return;
            }
        }
        if (checkMission == 0)
        {
            setNameMission.setText("Empty");
            setRateMission.setText("0/0");
        }
    }
    public void GetMission()
    {
        count_enemy = 0;
        count_boss = 0;
        for (int i = 0; i < 8; i++)
        {
            if (PlayerPrefs.GetString("ID_MISSION") == ID_M[i] && PlayerPrefs.GetInt("CHECK_MISSION") == 0)
            {
                //Debug.Log(ID_M[i]);
                STATUS_M[i] = 1;
                readMission.STATUS[i] = 1;
                readMission.Change();
                readMissionAll();
                PlayerPrefs.SetInt("CHECK_MISSION", 1);
                return;
            }
        }
    }
    public void CountEnemy()
    {
        for (int i = 0; i < 8; i++)
        {
            if (STATUS_M[i] == 1)
            {
                if (ID_M[i] == "M7")
                {
                    if (count_boss >= MAX_COUNT_M[i])
                    {
                        count_enemy = MAX_COUNT_M[i];
                    }
                    CUR_COUNT_M[i] = count_boss;
                    readMission.CUR_COUNT[i] = count_boss;
                    readMission.Change();
                    readMissionAll();
                    return;
                }
                if (count_enemy >= MAX_COUNT_M[i])
                {
                    count_enemy = MAX_COUNT_M[i];
                }
                CUR_COUNT_M[i] = count_enemy;
                readMission.CUR_COUNT[i] = count_enemy;
                readMission.Change();
                readMissionAll();
                return;
            }
        }
    }
    public void BonusGold(int quantity)
    {
        gold += quantity;
        data_player.GOLD = gold;
        str_notice += "\nReceive " + quantity + "$ Gold";
        Notice.setText(str_notice);
    }
    public void BonusExp(int quantity)
    {
        float ExpUP = quantity;
        while (ExpUP > 0)
        {
            expValue += ExpUP;
            ExpUP = expValue - maxExpValue;
            if (expValue > maxExpValue)
            {
                level++;
                maxExpValue = level * 100 + (((level - 1) * 217) % 249);
                maxHealthValue = maxExpValue * 5;
                healthValue = maxHealthValue;
                expValue = 0;
            }
        }
        data_player.LEVEL = level;
        data_player.MAX_EXP = maxExpValue;
        data_player.EXP = expValue;
        data_player.HEALTH = healthValue;
        data_player.MAX_HEALTH = maxHealthValue;
        data_player.DAMAGE_0 = 50 + 50 * (level - 1) / 10;
        data_player.DAMAGE_1 = 75 + 75 * (level - 1) / 10;
        data_player.DAMAGE_2 = 100 + 100 * (level - 1) / 10;
        data_player.DAMAGE_3 = 135 + 135 * (level - 1) / 10;
        data_player.DAMAGE_4 = 200 + 200 * (level - 1) / 10;
        changePosition();
        data_player.Change();
        setData();
        str_notice += "\nReceive " + quantity + " Exp";
        Notice.setText(str_notice);
    }
    public void BonusIHP(int quantity)
    {
        item_1 += quantity;
        data_player.ITEM_1 = item_1;
        str_notice += "\nReceive " + quantity + " Item HP UP";
        Notice.setText(str_notice);
    }
    public void BonusIDamage(int quantity)
    {
        item_2 += quantity;
        data_player.ITEM_2 = item_2;
        str_notice += "\nReceive " + quantity + " Item Damage UP";
        Notice.setText(str_notice);
    }
    public void BonusIExp(int quantity)
    {
        item_3 += quantity;
        data_player.ITEM_3 = item_3;
        str_notice += "\nReceive " + quantity + " Item Exp UP";
        Notice.setText(str_notice);
    }
    public void BonusISpeed(int quantity)
    {
        item_4 += quantity;
        data_player.ITEM_4 = item_4;
        str_notice += "\nReceive " + quantity + " Item Speed UP";
        Notice.setText(str_notice);
    }
    public bool CheckSuccessMission()
    {
        for (int i = 0; i < 8; i++)
        {
            if (STATUS_M[i] == 1 && count_enemy >= MAX_COUNT_M[i])
            {
                if (count_boss < 1 && ID_M[i] == "M7")
                {
                    return false;
                }
                PlayerPrefs.SetInt("CHECK_MISSION", 0);
                count_enemy = 0;
                count_boss = 0;
                STATUS_M[i] = 0;
                CUR_COUNT_M[i] = 0;
                readMission.STATUS[i] = 0;
                readMission.CUR_COUNT[i] = 0;
                readMission.Change();
                readMissionAll();
                BonusGold(3000);
                BonusIDamage(5);
                BonusIHP(5);
                BonusISpeed(10);
                BonusExp(2500);
                return true;
            }
        }
        return false;
    }
    public void NoticeDie()
    {
        if (healthValue <= 0)
        {
            NoticeMain.SetActive(true);
            //MainCavas.SetActive(false);
            checkPlayerDie = true;
            direction = Vector2.zero;
            isDie = true;
        }
    }
    public void Revival()
    {
        NoticeMain.SetActive(false);
        //MainCavas.SetActive(true);
        data_player.POSX = pos_player.START_0_X;
        data_player.POSY = pos_player.START_0_Y;
        data_player.HEALTH = data_player.MAX_HEALTH;
        data_player.MAP = 0;
        data_player.Change();
        SceneManager.LoadScene("Map0");
    }
    public bool checkMission()
    {
        for (int i = 0; i < 8; i++)
        {
            if (STATUS_M[i] == 1)
            {
                return true;
            }
        }
        return false;
    }
}
