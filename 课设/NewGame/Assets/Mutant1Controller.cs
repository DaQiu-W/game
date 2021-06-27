using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant1Controller : MonoBehaviour {
    private AudioSource audioSource;
    private Animator anim;
    // Use this for initialization
    private bool isDead = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 碰撞开始
    private void OnTriggerEnter(Collider other)
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            //判断是否攻击的参数
            anim.SetBool("isAttack", true);
            
            if (anim.GetBool("isAttack") && !isDead)
            {
                if (!audioSource.isPlaying)
                {
                Debug.Log(audioSource.clip);
                audioSource.Play();
                isDead = true;

                }

            }
            else
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }

    }

    // 碰撞结束
    void OnTriggerExit(Collider other)
    {
        Debug.Log("结束");
        //speed = -1f;
        //anim.SetBool("isAttack", false);
    }

    // 碰撞持续中
    void OnTriggerStay(Collider other)
    {

    }
}
