using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerVariablesSO", menuName = "ScriptableObjects/Stats/Player/PlayerVariables", order = 0)]
public class PlayerVariablesSO : ScriptableObject
{
    #region Movement Related
    [Header("Movement Variables")]
    [SerializeField] public float WalkSpeed = 150f;
    [SerializeField] public float SprintSpeed = 300f;
    #endregion

    #region CombatRelated
    [Header("Combat")]
    [SerializeField] public int MaxHealth { get; set; }
    [SerializeField] public int Strength { get; private set; }
    [SerializeField] public int Defense { get; private set; }
    [SerializeField] public int Agility { get; private set; }
    #endregion
}
