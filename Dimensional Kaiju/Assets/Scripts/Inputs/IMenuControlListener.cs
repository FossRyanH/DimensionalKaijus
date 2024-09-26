using UnityEngine;

public interface IMenuControlListener
{
    void Move(Vector2 movement);
    void Accept();
    void Cancel();
    void CloseMenu();
}
