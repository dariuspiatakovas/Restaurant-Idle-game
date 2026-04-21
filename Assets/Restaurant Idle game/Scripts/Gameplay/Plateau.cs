using UnityEngine;

public class Plateau : MonoBehaviour
{
    [Header( " Elements ")]
    [SerializeField] private Transform foodPositionsParent;


    [Header(" Settings ")]
    [SerializeField] private int maxCapacity;
    private bool isFull;
    public bool IsFull => isFull;

    public bool IsEmpty => GetFirstFullPosition() == null;

    private float positionsYOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFull = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Push(SpawnableFood foodInstance)
    {
        FoodPosition foodPosition = GetFirstEmptyFoodPosition();
        foodPosition.Push(foodInstance);

        RearrangeFoodPositions(foodInstance);

        if (GetFirstEmptyFoodPosition() == null)
        {
            if (foodPositionsParent.childCount < maxCapacity)
                CreateNewFoodPosition();
            else
                isFull = true;
        }
    }


    public SpawnableFood Pop()
    {
        FoodPosition foodPosition = GetLastFullPosition();

        if (foodPosition == null)
            return null;

        isFull = false;

        return foodPosition.Pop();
    }

    private FoodPosition GetLastFullPosition()
    {
        for (int i = foodPositionsParent.childCount -1; i >= 0; i--)
        {
            if (!foodPositionsParent.GetChild(i).TryGetComponent(out FoodPosition foodPosition))
                continue;

            if (!foodPosition.IsEmpty)
                return foodPosition;
        }

        return null; 
    }

    private FoodPosition GetFirstFullPosition()
    {
        for (int i =0; i < foodPositionsParent.childCount; i++)    
        {
            if (!foodPositionsParent.GetChild(i).TryGetComponent(out FoodPosition foodPosition))
                continue;

            if (!foodPosition.IsEmpty)
                return foodPosition;
        }

        return null;
    }


    private void CreateNewFoodPosition()
    {
        FoodPosition foodPositionInstance = new GameObject(" Food Position " + foodPositionsParent.childCount).AddComponent<FoodPosition>();
        foodPositionInstance.transform.SetParent(foodPositionsParent);

        int bottomChildIndex = foodPositionInstance.transform.GetSiblingIndex() - 1;

        foodPositionInstance.transform.localPosition = foodPositionsParent.GetChild(bottomChildIndex).localPosition +
            Vector3.up * positionsYOffset;

        foodPositionInstance.transform.localRotation = Quaternion.identity;

        isFull = false;
    }

    private void RearrangeFoodPositions (SpawnableFood foodInstance)
    {
        positionsYOffset = foodInstance.CleanYOffsetOnPlateau;

        for (int i = 0; i < foodPositionsParent.childCount; i++)
            foodPositionsParent.GetChild(i).localPosition = Vector3.up * i * positionsYOffset;
    }

    private FoodPosition GetFirstEmptyFoodPosition()
    {
        for (int i = 0; i < foodPositionsParent.childCount; i++)
        {
            if (!foodPositionsParent.GetChild(i).TryGetComponent(out FoodPosition foodPosition))
                continue;

            if(foodPosition.IsEmpty)
                return foodPosition;
        }

        return null;
    }
}
