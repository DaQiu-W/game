using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant3Controller : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    private bool isAttacked = false;
    private bool isDead = false;
    private AudioSource audioSource;
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
        Debug.Log("碰撞了");
        Debug.Log(other.gameObject);


        if (Input.GetKey(KeyCode.Alpha1))
        {

            anim.SetBool("isAttack", true);
            Debug.Log(anim.GetBool("isAttack"));

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
    }

    // 碰撞持续中
    void OnTriggerStay(Collider other)
    {

    }
}
