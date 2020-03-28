using UnityEngine;
using System.Collections;

public enum soundsGame
{
    die,
    hit,
    menu,
    skill,
    click
}

public class SoundController : MonoBehaviour
{
    public AudioClip soundDie;
    public AudioClip soundHit;
    public AudioClip soundMenu;
    public AudioClip soundSkill;
    public AudioClip soundClick;

    public static SoundController instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }
    public static void PlaySound(soundsGame currentSound)
    {
        switch (currentSound)
        {
            case soundsGame.die:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundDie);
                }
                break;
            case soundsGame.hit:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundHit);
                    instance.Invoke("PlaySoundDie", 0.3f);
                }
                break;
            case soundsGame.menu:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundMenu);
                }
                break;
            case soundsGame.skill:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundSkill);
                }
                break;
            case soundsGame.click:
                    {
                        instance.GetComponent<AudioSource>().PlayOneShot(instance.soundClick);
                    }
                    break;
        }
    }
    private void PlaySoundDie()
    {
        PlaySound(soundsGame.die);
    }

}