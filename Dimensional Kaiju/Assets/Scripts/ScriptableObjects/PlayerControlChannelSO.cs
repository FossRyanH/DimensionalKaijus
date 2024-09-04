using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerControlChannelSO", menuName = "ScriptableObjects/Inputs/PlayerControlChannelSO", order = 0)]
public class PlayerControlChannelSO : ScriptableObject
{
    public event Action<Vector2> Movement;
    public event Action Interact, Cancel, OpenMenu, Sprint;
    
    public void HandleMovement(Vector2 movement) => Movement?.Invoke(movement);
    public void HandleInteract() => Interact?.Invoke();
    public void HandleOpenMenu() => OpenMenu?.Invoke();
    public void HandleSprint() => Sprint?.Invoke();
    public void HandleCancel() => Cancel?.Invoke();
}
