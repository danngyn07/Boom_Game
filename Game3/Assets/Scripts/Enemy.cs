using Pathfinding;
using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    AudioManager audioManager;
    public  AIPath aiPath;
    public Animator animE;
    public Player player;
    public SpriteRenderer enemySprite;

    [SerializeField] int enemyHeath;
    public int bulletDam;
    public float delayDeadTime;
    
    // Start is called before the first frame update

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        animE.GetComponent<Animation>();
        player = FindObjectOfType<Player>();
        bulletDam = FindObjectOfType<ThietLap>().dam;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(2f, 2f, 0);
        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-2f, 2f, 0);
        }
        if(enemyHeath <= 0)
        {
            EnemyDie();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            DamageEnemy();
            Destroy(other.gameObject);
        }
        
    }
    void EnemyDie()
    { 
        Destroy(gameObject, delayDeadTime);
        FindObjectOfType<GameManager>().IncreaseScore();

        this.animE.SetBool("isDie", true);
        this.aiPath.enabled = false;
    }
    void DamageEnemy()
    {
        
        enemyHeath -= bulletDam;
        StartCoroutine(EnemyDamFlash());
    }
    public IEnumerator EnemyDamFlash()
    {
        enemySprite.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.white;
        
    }
    

}
