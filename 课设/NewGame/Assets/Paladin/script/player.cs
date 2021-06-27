using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("speed", Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetBool("isAttackUp", true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            anim.SetBool("isAttackUp", false);
        }
	}
}
