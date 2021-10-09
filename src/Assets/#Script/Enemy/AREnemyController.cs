using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AREnemyController : MonoBehaviour
{
    public float lookRadius = 10f;  //敌人在一定范围内寻找玩家
    float timer;
    Transform target;
   //NavMeshAgent agent;
    public Animator mouseAnimator;

    private float speed = 0.09f;
    private float stoppingDistance =0.16f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    //    agent = GetComponent<NavMeshAgent>();
        target = ARPlayerManager.instance.player.transform;
    }
    // Update is called once per frame
    void Update()
    { faceTarget();
        timer += Time.deltaTime;  //老鼠已经站起来
        if (target == null)
            return;
        if (timer >=5.5f) {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
               // agent.SetDestination(target.position);
                OntoDestinationJJ(target.position);
                //if (distance <= agent.stoppingDistance)
                if (distance <= stoppingDistance)
                {
                    //当前敌人已经停下并开始攻击
                    //攻击之前敌人应该面对player
                    faceTarget();
                    mouseAnimator.SetBool("isAttacking", true);
                }
                else {
                    faceTarget();
                    mouseAnimator.SetBool("isAttacking", false);
                }
            }
            else
            {
                mouseAnimator.SetBool("isAttacking", false);
            }
            mouseAnimator.SetBool("isWalking", true);
        }
    }
    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
   void OntoDestinationJJ(Vector3 targetPostion)
    {
        if (Vector3.Distance(mouseAnimator.transform.position, target.position) >= stoppingDistance) {
            mouseAnimator.transform.position = Vector3.MoveTowards(transform.position, targetPostion, Time.deltaTime * speed);
        }
    }

}
