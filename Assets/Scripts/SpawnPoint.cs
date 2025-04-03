using Characters;
using Movement;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private NonPlayerCharacter _prefab;
    [SerializeField] private MovementStrategiesEnum _defaultStrategy;
    [SerializeField] private MovementStrategiesEnum _triggeredStrategy;

    private void Awake()
    {
        NonPlayerCharacter character = Instantiate(_prefab, gameObject.transform.position, Quaternion.identity);
        character.Initialize(_defaultStrategy, _triggeredStrategy);
    }
}