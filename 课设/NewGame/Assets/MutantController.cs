using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour {

    private Animator anim;
    private AudioSource audioSource;
    private bool isDead = false;
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

    }

    // 碰撞开始
    private void OnTriggerEnter(Collider other)
    {   
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //设置是否攻击参数
            anim.SetBool("isAttack",true);
            //设置是否死亡参数
            anim.SetBool("isDead", true);
            //播放死亡音频
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
    }

    // 碰撞持续中
    void OnTriggerStay(Collider other)
    {

    }
}
