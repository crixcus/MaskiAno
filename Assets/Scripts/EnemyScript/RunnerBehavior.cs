using System.Collections;
using UnityEngine;

public class RunnerBehavior : MonoBehaviour
{
    public float moveSpeed = 8f;               
    public float runAwaySpeed = 12f;           
    public float roamRadius = 10f;            
    public float changeTargetInterval = 2f;    
    public string playerTag = "Player";        

    private Vector3 roamTarget;
    private Transform player;
    private bool isRunningAway = false;
    private float roamTimer;
    private bool isRunningCoroutine = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform;
        ChooseNewRoamTarget();
    }

    public void Update()
    {
        if (!isRunningAway)
        {
            RoamLogic();
        }
    }

    public void FightFlight()
    {
        if (isRunningAway)
        {
            RunAwayLogic();
        }
        else
        {
            RoamLogic();
        }
    }

    void RoamLogic()
    {
        roamTimer += Time.deltaTime;
        if (roamTimer >= changeTargetInterval)
        {
            ChooseNewRoamTarget();
            roamTimer = 0f;
        }

        MoveTowards(roamTarget, moveSpeed);
    }

    void RunAwayLogic()
    {
        if (player == null) return;

        if (!isRunningCoroutine)
        {
            StartCoroutine(RunAwayDuration(10f)); // Run away for 10 seconds
        }

        Vector3 runDirection = (transform.position - player.position).normalized;
        runDirection.y = 0f; // Keep movement on XZ plane

        Vector3 targetPosition = transform.position + runDirection * runAwaySpeed;
        MoveTowards(targetPosition, runAwaySpeed);
    }

    IEnumerator RunAwayDuration(float seconds)
    {
        isRunningCoroutine = true;
        isRunningAway = true;

        yield return new WaitForSeconds(seconds);

        isRunningAway = false;
        isRunningCoroutine = false;
    }


    void MoveTowards(Vector3 target, float speed)
    {
        Vector3 direction = (target - transform.position).normalized;
        direction.y = 0f; 

        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(transform.position + direction);
    }

    void ChooseNewRoamTarget()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-roamRadius, roamRadius),
            0f,
            Random.Range(-roamRadius, roamRadius)
        );
        roamTarget = transform.position + randomOffset;
    }
    public void RunAwayFromPlayer()
    {
        isRunningAway = true;
    }

    public void ResumeRoaming()
    {
        isRunningAway = false;
        roamTimer = changeTargetInterval; 
    }
}
