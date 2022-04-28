using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    public float speed;
    public float duration;
    public int damage;
    public float angle;
    public float attackDelay = 0.1f;

    void Start()
    {
        StartCoroutine("CircleDamage");
        Destroy(gameObject, duration);
    }

    void Update()
    {
        RotateAround();
    }

    void RotateAround()
    {
        angle = speed * Time.deltaTime;
        transform.RotateAround(
            GameManager.Instance.player.skillPos.position, 
            Vector3.forward,
            angle);
    }

    IEnumerator CircleDamage()
    {
        while (true)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f, LayerMask.GetMask("Enemy"));
            //Debug.Log(transform.position + " , " + transform.localScale.x / 2f);
            //Debug.Log("CircleDamage cnt : " + hits.Length);

            if (hits.Length > 0)
            {
                Debug.Log("Circle len" + hits.Length);
                foreach(Collider2D hit in hits)
                {
                    IDamageable target = hit.transform.GetComponent<IDamageable>();
                    target?.Hit(damage);

                    Debug.Log(damage);
                }
            }

            yield return new WaitForSeconds(attackDelay);
        }
    }

}
