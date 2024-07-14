using Pathfinding;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemy;
    public float TimeBtwSpawn = 2f;
    Vector2 enemySpawnPos;
    // Update is called once per frame
    void Update()
    { 

        int enemyIndex = Random.Range(0, enemy.Length);

        enemy[enemyIndex].GetComponent<AIDestinationSetter>().target = GameObject.FindWithTag("Player").transform;

        enemySpawnPos.x = Random.Range(-9f, 9f);
        enemySpawnPos.y = Random.Range(-9f, 9f);
        
        TimeBtwSpawn -= Time.deltaTime;
        
        if (TimeBtwSpawn < 0)
        {
            TimeBtwSpawn = 2f;
            Instantiate(enemy[enemyIndex], enemySpawnPos, transform.rotation);
            
        }


    }
}
