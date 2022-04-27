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
    private Vector2 aimPos;
    private RushMonsterState state;



    public override void Mover()
    {

        Vector2 dir = new Vector2();


        switch (state)
        {

            case RushMonsterState.Rush:
            {
                   

                    if (Vector2.Distance(aimPos ,transform.position) > 0.1f)
                    {
                        dir = aimPos - new Vector2(transform.position.x , transform.position.y);
                        transform.Translate(dir * 15 * Time.deltaTime);
                    }
                    else
                    {
                        state = RushMonsterState.Idle;
                        GetComponent<Collider2D>().isTrigger = false;
                        monsterAnimator.speed = 1;
                    }

            }
            break;
            case RushMonsterState.Trace:
            {

                    if (!monsterAnimator.GetBool("isMove"))
                    {
                        monsterAnimator.SetBool("isMove", true);

                    }

                    if (Vector2.Distance(playerTransform.position, transform.position) > 10f)
                    {
                       dir = playerTransform.position - new Vector3(transform.position.x, transform.position.y , 0);
                        transform.Translate(dir * velocity * Time.deltaTime);



                    }                   
                    else 
                    {
                   
                        aimPos = playerTransform.position;
                        state = RushMonsterState.Rush;
                        GetComponent<Collider2D>().isTrigger = true;
                        monsterAnimator.speed = 2;

                    }

                }
            break;
            case RushMonsterState.Idle:
            {
                    if (monsterAnimator.GetBool("isMove"))
                    {
                        monsterAnimator.SetBool("isMove", false);

                    }
                    dir = playerTransform.position - new Vector3(transform.position.x, transform.position.y, 0);
                    if (!is_wait)
                    {
                        is_wait = true;
                        StartCoroutine(WaitRoutin());
                    }

            }
            break;


        }

        AnimDir(dir);

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
