using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out FoodSpawnerStation station))
            HandleFoodSpawnerStationTriggered(station);
    }

    private void HandleFoodSpawnerStationTriggered(FoodSpawnerStation station)
    {
        GetComponent<HoldFoodAbility>().HandleInFoodSpawnerStation(station);
    }
}
