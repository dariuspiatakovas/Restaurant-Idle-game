using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager instance;


    [Header(" Elements ")]
    [SerializeField] private Customer customerPrefab;


    private void Awake()
    {
    if (instance == null)
        instance = this;
    else
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Customer Pop(Vector3 spawnPosition)
    {
        return Instantiate(customerPrefab, spawnPosition, Quaternion.identity, transform);
    }

}
