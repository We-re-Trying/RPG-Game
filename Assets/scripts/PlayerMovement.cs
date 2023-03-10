using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    Rigidbody2D rb;

    public bool isAttacking = false;
    private Collider2D hitBox;
    public Vector2 hitBoxSize = new Vector2(.5f, .5f), hitBoxLocation;

    public int currentHealth;
    public int maxHealth = 20;
    public int str = 1;

    public int exp;
    public int expThreshold = 100;
    public int healthIncrease = 5;
    public int strIncrease = 1;

    private float moveHorizontal, moveVertical;
    Vector2 currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Probably need to change these for scene transitions
        currentHealth = maxHealth; 
        exp = 0;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveHorizontal = 0f;
            moveVertical = 0f;
        }


        attack();
        animate();
    }

    void FixedUpdate()
    {
        if (!isAttacking)
        {
            rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    

    public void attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void addExp(int expGains)
    {
        exp += expGains;

        if (exp >= expThreshold)
        {
            levelUp();
        }
    }

    public void levelUp()
    {
        maxHealth += healthIncrease;
        str += strIncrease;

        // Get leftover exp to keep towards next level up
        exp -= expThreshold;
    }

    public void animate()
    {
        // Animation variable code
        currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (moveHorizontal < 0 && currentVelocity.x <= 0)
        {
            animator.SetInteger("DirectionX", -1);
        }
        else if (moveHorizontal > 0 && currentVelocity.x >= 0)
        {
            animator.SetInteger("DirectionX", 1);
        }
        else
        {
            animator.SetInteger("DirectionX", 0);
        }
        if (moveVertical < 0 && currentVelocity.y <= 0)
        {
            animator.SetInteger("DirectionY", -1);
        }
        else if (moveVertical > 0 && currentVelocity.y >= 0)
        {
            animator.SetInteger("DirectionY", 1);
        }
        else
        {
            animator.SetInteger("DirectionY", 0);
        }
    }

    public void isAttackingOn()
    {
        //Debug.Log("isAttackingOn()");
        isAttacking = true;
        Invoke("isAttackingOff", 1f); // Failsafe
    }

    public void isAttackingOff()
    {
        //Debug.Log("isAttackingOff()");
        isAttacking = false;
    }
}