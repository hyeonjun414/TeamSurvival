using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RushMonsterState
{

    Idle,
    Rush,
    Trace
}



public class RushMonster : Monster
{


    private bool is_wait = false;
    private Vector3 aimPos;
    private RushMonsterState state;



    public override void Mover()
    {

        Vector2 dir;


        switch (state)
        {

            case RushMonsterState.Rush:
            {
                   

                    if (Vector2.Distance(aimPos ,transform.position) > 1f)
                    {
                        dir = aimPos - transform.position;
                        AnimDir(dir);
                       
                        transform.Translate(dir.normalized * 20 * Time.fixedDeltaTime);
                    }
                    else
                    {
                        state = RushMonsterState.Idle;
                        GetComponent<Collider2D>().isTrigger = false;
                        Attack();


                    }

            }
            break;
            case RushMonsterState.Trace:
            {

                    if (!monsterAnimator.GetBool("isMove"))
                    {
                        monsterAnimator.SetBool("isMove", true);

                    }

                    if (Vector2.Distance(playerTransform.position, transform.position) > 20f)
                    {
                       dir = playerTransform.position - transform.position;
                        AnimDir(dir);
                        transform.Translate(dir.normalized * velocity * Time.fixedDeltaTime);



                    }                   
                    else 
                    {
                   
                        aimPos = playerTransform.position;
                        state = RushMonsterState.Rush;
                        GetComponent<Collider2D>().isTrigger = true;
                     

                    }

                }
            break;
            case RushMonsterState.Idle:
            {
                    if (monsterAnimator.GetBool("isMove"))
                    {
                        monsterAnimator.SetBool("isMove", false);

                    }
                    dir = playerTransform.position - transform.position;
                    AnimDir(dir);
                    if (!is_wait)
                    {
                        is_wait = true;
                        StartCoroutine(WaitRoutin());
                    }

                    

            }
            break;


        }

      

    }

    IEnumerator WaitRoutin()
    {
        
        float time = 0f;
        while(time < 2f)
        {
            time += Time.deltaTime;

            yield return null;

        }

        is_wait = false;
        state = RushMonsterState.Trace;

    }


}
