using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private Wave wave;

    // Stats
    public int hp = 20;
    public float speed = 5f;
    public int scoreWorth = 100;
    public int moneyWorth = 1;
    public int damage = 1;
    public int multiplier = 1;
    public float attackDistance = 1f;
    
    // Targets
    public GameObject bed;
    private BedHp bedScript;
    public GameObject player;
    private PlayerCore playerScript;
    public GameObject shop;
    private Guns gun;
    public float distance = 3f;
    private float distanceToPlayer;
    private float distanceToBed;

    private GameObject lastTarget;
    NavMeshAgent agent;
    Animator anim;

    void Start()
    {
        bed = GameObject.Find("bed");
        player = GameObject.Find("Player");
        wave = GameObject.Find("Enemies").GetComponent<Wave>();
        playerScript = player.GetComponent<PlayerCore>();
        gun = playerScript.guns.GetComponent<Guns>();

        multiplier = Random.Range(1, 4);
        transform.localScale = new Vector3(0.5f,0.5f,0.5f) + new Vector3(0.05f * multiplier, 0.05f * multiplier, 0.05f * multiplier);
        hp *= multiplier;
        speed /= multiplier;
        scoreWorth *= multiplier;
        moneyWorth *= multiplier;
        damage *= multiplier;

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        lastTarget = bed;
        agent.speed = speed;
        agent.angularSpeed = 1200 * multiplier;
        agent.Warp(transform.position);

        MoveToTarget(bed);
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("TakeHit") || anim.GetCurrentAnimatorStateInfo(0).IsName("Death") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            return;
        }
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        distanceToBed = Vector3.Distance(bed.transform.position, transform.position);
        if ((distanceToPlayer <= attackDistance || distanceToBed <= attackDistance + 1))
        {
            FaceTarget();
            anim.Play("Attack" + Random.Range(1, 3));
        }
        else if (distanceToPlayer <= distance && lastTarget == bed)
            MoveToTarget(player);
        else if (Vector3.Distance(player.transform.position, transform.position) >= distance && lastTarget == player)
            MoveToTarget(bed);

    }

    private void FaceTarget()
    {
        Vector3 direction;
        if (distanceToBed <= attackDistance)
            direction = (bed.transform.position - transform.position).normalized;
        else
            direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void MoveToTarget(GameObject currentTarget)
    {
        agent.SetDestination(currentTarget.transform.position);

        if (speed >= 5f)
            anim.Play("Run");
        else if (speed <= 1.3f)
            anim.Play("Walk2");
        else anim.Play("Walk1");

        lastTarget = currentTarget;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            gun.ChangeMoney(moneyWorth);
            wave.enemyDied();
            transform.parent.GetComponent<Score>().GetPoints(scoreWorth);
            Destroy(gameObject);
        }
        if (Random.Range(1, 100) <= 50 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            anim.Play("TakeHit");
    }

    public void Attack()
    {
        if(distanceToBed <= attackDistance + 2)
        {
            if (bedScript == null)
                bedScript = bed.GetComponent<BedHp>();
            bedScript.ChangeHp(-damage);
        }
        else
        {
            if(playerScript == null)
                playerScript = player.GetComponent<PlayerCore>();
            Collider[] collider;
            collider = Physics.OverlapSphere(transform.position, attackDistance, 8);
            playerScript.ChangeHp(-damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
