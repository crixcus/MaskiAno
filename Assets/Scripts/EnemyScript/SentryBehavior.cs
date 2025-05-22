using System.Collections;
using UnityEngine;

public class SentryBehavior: MonoBehaviour
{
    public SentryBehavior Instance;
    public Transform target;
    public EnemyShoot shooting;

    public float speed = 5f;         
    public bool isChasing = false;

    public float firedelay = 2f;


    public void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if (isChasing && target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
    public void Chase()
    {
        isChasing = true;
        shooting.ShootCommence();
    }

    public void StopChase()
    {
        isChasing = false;
        shooting.StopShooting();
    }
}
