using Characters;
using DefaultNamespace;
using Movement;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private NonPlayerCharacter _prefab;
    [SerializeField] private MovementStrategiesEnum _defaultStrategy;
    [SerializeField] private MovementStrategiesEnum _triggeredStrategy;
    [SerializeField] private ControlPointsHolder _controlPointsHolder;
    [SerializeField] private Hero _hero;

    private void Awake()
    {
        NonPlayerCharacter character = Instantiate(_prefab, gameObject.transform.position, Quaternion.identity);
        character.Initialize(_defaultStrategy, _triggeredStrategy, _controlPointsHolder,_hero);
    }
}