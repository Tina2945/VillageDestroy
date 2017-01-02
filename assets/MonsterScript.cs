using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MonsterScript : MonoBehaviour
{
    private Animator animator;
    private float MinimumHitPeriod = 1f;
    private float HitCounter = 0;
    public float HP = 100;
    public float MoveSpeed;
    public GameObject FollowTarget;
    private Rigidbody rigidBody;
    public CollisionListScript PlayerSensor;
    public CollisionListScript AttackSensor;
    public GameObject effect;
    public GameObject blood;
    // Use this for initialization
    public void AttackPlayer()
    {
        if (AttackSensor.CollisionObjects.Count > 0)
        {
            AttackSensor.CollisionObjects[0].transform.GetChild(0).GetChild(0).SendMessage("Hit", 10);
            blood.SetActive(true);

        }
       
            
    }
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody>();
    }
   
    
    void Update()
    {
        blood.SetActive(false);
        if (PlayerSensor.CollisionObjects.Count > 0)
        {
            FollowTarget = PlayerSensor.CollisionObjects[0].gameObject;
        }
        if (HP > 0 && HitCounter > 0)
        {
            HitCounter -= Time.deltaTime;
        }
        else
        {
            if (HP > 0)
            {
                if (FollowTarget != null)
                {
                    Vector3 lookAt = FollowTarget.gameObject.transform.position;
                    lookAt.y = this.gameObject.transform.position.y;
                    this.transform.LookAt(lookAt);
                    animator.SetBool("Run", true);
                    if (AttackSensor.CollisionObjects.Count > 0)
                    {
                        animator.SetBool("Attack", true);
                        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                    else
                    {
                        animator.SetBool("Attack", false);
                        rigidBody.velocity = this.transform.forward * MoveSpeed;
                    }
                }
            }
            else
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
    public void Hit(float value)
    {
        if (HitCounter <= 0)
        {
            HitCounter = MinimumHitPeriod;
            HP -= value;
            animator.SetFloat("HP", HP);
            animator.SetTrigger("Hit");
            effect.SetActive(true);
            if (HP <= 0) { BuryTheBody(); }
        }
    }
    void BuryTheBody()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Collider>().enabled = false;
        this.transform.DOMoveY(-0.8f, 1f).SetRelative(true).SetDelay(1).OnComplete(() =>
        {
            this.transform.DOMoveY(-0.8f, 1f).SetRelative(true).SetDelay(3).OnComplete(() =>
            {
                GameObject.Destroy(this.gameObject);
            });
        });
    }
}