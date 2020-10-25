using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip destroyEnemy, loseLife, shoot;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        destroyEnemy = Resources.Load<AudioClip>("Explosion3");
        loseLife = Resources.Load<AudioClip>("Hit_Hurt2");
        shoot = Resources.Load<AudioClip>("Laser_Shoot2");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame

        public static void PlaySound(string clip)
        {
            switch (clip)
            {
            case "destroyEnemy":
                audioSrc.PlayOneShot(destroyEnemy);
                break;
            case "loseLife":
                audioSrc.PlayOneShot(loseLife);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shoot);
                break;



            }
        }
    
}
