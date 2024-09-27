using UnityEngine;

public interface IPlayerControlListener
{
    void Movement(Vector2 movement);
    void Interact();
    void OpenMenu();
    void Sprint(bool isSprinting);
    void Attack(bool isAttacking);
    void Skill(bool isUsingSkill);
}
