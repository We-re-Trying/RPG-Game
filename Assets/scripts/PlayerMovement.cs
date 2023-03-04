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

    public int currentHealth;
    public int maxHealth = 20;
    public int str = 1;

    public int exp;
    public int expThreshold = 100;
    public int healthIncrease = 5;
    public int strIncrease = 1;

    private float moveHorizontal, moveVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Probably need to change these for scene transitions
        currentHealth = maxHealth; 
        exp = 0;
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        // Animation variable code
        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

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

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
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
}