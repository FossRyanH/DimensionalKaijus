using UnityEngine;

[CreateAssetMenu(menuName = "SO/Kaiju/KaijuVariablesSO", fileName = "KaijuVariables", order = 0)]
public class KaijuVariablesSO : ScriptableObject
{
    #region Combat
    [Header("Combat")]
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public int Strength { get; private set; }
    [field: SerializeField] public int Defense { get; private set; }
    [field: SerializeField] public int Agility { get; private set; }
    #endregion

    #region Movement
    [field: SerializeField] public float WanderSpeed { get; private set; }
    [field: SerializeField] public float ChaseSpeed { get; private set; }
    [field: SerializeField] public float AttackMoveSpeed { get; private set; }
    #endregion
}