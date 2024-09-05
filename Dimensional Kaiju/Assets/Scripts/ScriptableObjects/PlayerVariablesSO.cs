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
}
