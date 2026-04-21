using UnityEngine;

public class HoldFoodAbility : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Plateau plateau;

    [Header(" Grab Timer ")]
    private const float canGrabFoodDelay = .1f;
    private float grabFoodTimer;
    private float dropFoodTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grabFoodTimer = canGrabFoodDelay;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleInFoodSpawnerStation(FoodSpawnerStation station)
    {
        if (plateau.IsFull)
            return;

        if (grabFoodTimer < canGrabFoodDelay)
        { 
          grabFoodTimer += Time.deltaTime;
            return;
        }

        SpawnableFood foodToGrab = station.Pop();

        if (foodToGrab == null)
            return;

        plateau.gameObject.SetActive(true);
        plateau.Push(foodToGrab);

        grabFoodTimer = 0;
    }


    public void HandleInDropZone(FoodDropZone dropZone)
    {
        if (!plateau.gameObject.activeInHierarchy)
            return;

        if (dropZone.isFull)
            return;


        if (dropFoodTimer < canGrabFoodDelay)
        {
            dropFoodTimer += Time.deltaTime;
            return;
        }

        SpawnableFood food = plateau.Pop();

        dropZone.Push(food);

        if (plateau.IsEmpty)
            plateau.gameObject.SetActive(false);

      dropFoodTimer = 0;

    }

}
