using UnityEngine;

public interface IDialogueControlListener
{
    void Advance();
    void Move(Vector2 move);
    void SkipDialogue();
    void Cancel();
}
