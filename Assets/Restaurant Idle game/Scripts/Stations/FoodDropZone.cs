using UnityEngine;

public class FoodDropZone : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Plateau plateau;
    
    public bool isFull => plateau.IsFull;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Push(SpawnableFood food)
    {
        plateau.Push(food);
    }
}
