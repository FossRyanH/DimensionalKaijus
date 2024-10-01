using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MenuControllChannel", menuName = "ScriptableObjects/Inputs/Menu Input", order = 1)]
public class MenuControlChannelSO : ScriptableObject
{
    public event Action<Vector2> Move;
    public event Action Accept, Cancel, CloseMenu;

    public void HandleMovement(Vector2 movement) => Move?.Invoke(movement);
    public void HandleAccept() => Accept?.Invoke();
    public void HandleCancel() => Cancel?.Invoke();
    public void HandleCloseMenu() => CloseMenu?.Invoke();
}
