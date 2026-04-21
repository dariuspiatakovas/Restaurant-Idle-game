using UnityEngine;

public class FoodPosition : MonoBehaviour
{
    [Header(" Elements ")]
    private SpawnableFood food;
    
    [Header(" Settings")]
    private bool isEmpty;
    public bool IsEmpty => isEmpty;
    

    private void Awake()
    {
        isEmpty = true;
    }


    void Start()
    {
        isEmpty = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

   public void Push(SpawnableFood foodInstance)
    {
        food = foodInstance;

        foodInstance.transform.SetParent(transform);
        foodInstance.transform.localPosition = Vector3.zero;

        isEmpty = false;
    }

    public SpawnableFood Pop()
    {
        isEmpty = true;

        SpawnableFood foodToReturn = food;
        food = null;

        return foodToReturn;
    }
}
