using UnityEngine;

public class HoldFoodAbility : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Plateau plateau;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleInFoodSpawnerStation(FoodSpawnerStation station)
    {
        if (plateau.IsFull)
            return;

        SpawnableFood foodToGrab = station.Pop();

        if (foodToGrab == null)
            return;

        plateau.gameObject.SetActive(true);
        plateau.Push(foodToGrab);
    }
}
