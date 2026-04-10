using UnityEngine;

public class SpawnableFood : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float CleanYOffsetOnPlateau;
    public float cleanYOffsetOnPlateau => CleanYOffsetOnPlateau;
}
