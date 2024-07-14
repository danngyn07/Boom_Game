using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer characterSR;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject weapon;
    AudioManager audioManager;

    public int playerCurrentHealth;
    public int playerMaxHealth;
    public float moveSpeed;

    private Vector2 movement;
    public Transform playerPos;
    // Start is called before the first frame update
    public void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        animator.GetComponent<Animation>();
        healthBar.GetComponent<HealthBar>();
        audioManager = FindObjectOfType<AudioManager>();
        playerMaxHealth = FindObjectOfType<ThietLap>().health;
        moveSpeed = FindObjectOfType<ThietLap>().speed;

        playerCurrentHealth =  playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    // Update is called once per frame
    public void Update()
    {
        movement.x =  Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        DontGoOutside();
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("IsWalk2", true);
            if (movement.x < 0)
            {
                characterSR.transform.localScale = new Vector3(-1, 1f, 0);
            }
            if (movement.x > 0)
            {
                characterSR.transform.localScale = new Vector3(1f, 1f, 0);
            }
        }
        else
        {
            animator.SetBool("IsWalk2", false);
        }

        if (playerCurrentHealth <= 0)
        {
            animator.SetBool("PlayerDead", true);
            weapon.SetActive(false);
            FindObjectOfType<GameManager>().GameOver();
        }
        
    }
    void DontGoOutside()
    {
        if (playerPos.position.x < -9.8f) playerPos.position = new Vector3(-9.8f , transform.position.y , 0);
        if (playerPos.position.x > 9.8f) playerPos.position = new Vector3(9.8f, transform.position.y, 0);
        if (playerPos.position.y < -9.8f) playerPos.position = new Vector3(transform.position.x , -9.8f, 0);
        if (playerPos.position.y > 9.8f) playerPos.position = new Vector3(transform.position.x , 9.8f, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            InvokeRepeating("TakeDamage", 0, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CancelInvoke("TakeDamage");
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    void TakeDamage()
    {
        int enemyDamage = Random.Range(2,7);
        playerCurrentHealth -= enemyDamage;
        StartCoroutine(DamageFlash());
        healthBar.setHealth(playerCurrentHealth);
        audioManager.PlaySFX(audioManager.enemyAttack , 1);
        audioManager.PlaySFX(audioManager.playerTakeDam , 0.5f);
    }
    public void CallBackPlayer()
    {
        weapon.SetActive(true);
        animator.SetBool("PlayerDead", false);

        playerCurrentHealth = FindObjectOfType<ThietLap>().health;
        healthBar.setHealth(playerCurrentHealth);
    }

    public IEnumerator DamageFlash()
    {
        characterSR.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        characterSR.color = Color.white;
    }
}
