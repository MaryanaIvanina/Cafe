using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner instance;

    [Tooltip("Prefab клієнта")]
    public GameObject customerPrefab;

    [Tooltip("Точка спавну клієнтів")]
    public Transform spawnPoint;

    [Tooltip("Час між приходами клієнтів")]
    public float spawnInterval = 10f;

    private float timer;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCustomer();
            timer = 0f;
        }
    }

    void SpawnCustomer()
    {
        Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
