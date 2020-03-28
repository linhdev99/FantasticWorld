using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour
{
    private Scrollbar sb;
    public float val = 1;
    // Use this for initialization
    void Start()
    {
        sb = GetComponent<Scrollbar>();
        sb.value = val;
        StartCoroutine(Scroll(20));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Scroll(float time)
    {
        if (val == 1)
        {
            for (float i = 100; i >= 0; i--)
            {
                val = i / 100;
                sb.value = val;
                yield return new WaitForSeconds(time / 100);
            }
            StartCoroutine(Scroll(20));
        }
        if (val != 1)
            for (float i = 0; i <= 100; i++)
            {
                val = i / 100;
                sb.value = val;
                yield return new WaitForSeconds(time / 100);
            }
    }
}
