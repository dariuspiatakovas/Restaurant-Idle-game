using UnityEngine;



[RequireComponent(typeof(HoldFoodAbility))]
public class PlayerDetector : MonoBehaviour
{


    [Header( " Components ")]
    private HoldFoodAbility holdFoodAbility;


    private void Awake()

    {
        holdFoodAbility = GetComponent<HoldFoodAbility>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out FoodSpawnerStation station))
            HandleFoodSpawnerStationTriggered(station);


        else if(other.TryGetComponent(out FoodDropZone dropZone))
            HandleInFoodDropZone(dropZone); 
    }

    private void HandleInFoodDropZone(FoodDropZone dropZone)
    {
        holdFoodAbility.HandleInDropZone(dropZone);
    }


    private void HandleFoodSpawnerStationTriggered(FoodSpawnerStation station)
    {
        holdFoodAbility.HandleInFoodSpawnerStation(station);
    }
}
