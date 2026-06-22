using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public Transform spawnPoint;   // Ponto de spawn dos inimigos
    public int maxEnemies = 5;     // Número máximo de inimigos
    public float spawnDelay = 2.0f; // Atraso entre spawns

    private int currentEnemyCount = 0;

    private void Start()
    {
        // Iniciar o spawn de inimigos
        InvokeRepeating("SpawnEnemy", 0.0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies)
            return;

        // Instanciar um inimigo no ponto de spawn
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Ajustar o inimigo de acordo com suas necessidades, por exemplo, defina sua IA, vida, etc.

        currentEnemyCount++;
    }

    public void OnEnemyKilled()
    {
        currentEnemyCount--;

        // Aqui você pode adicionar lógica adicional quando um inimigo é morto, se necessário.
    }
}
