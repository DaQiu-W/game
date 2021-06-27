using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        private Animator animator;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            animator = GetComponent<Animator>();
	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance && !animator.GetBool("isAttack"))
            {
                agent.updatePosition = true;
                character.Move(agent.desiredVelocity, false, false);
                //设置跑步动画触发的条件
                animator.SetFloat("speed",1f);
            }
            else
            {
                agent.updatePosition = false;
                character.Move(Vector3.zero, false, false);
                //取消跑步动画的条件
                animator.SetFloat("speed", -1f);
            }
                
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
