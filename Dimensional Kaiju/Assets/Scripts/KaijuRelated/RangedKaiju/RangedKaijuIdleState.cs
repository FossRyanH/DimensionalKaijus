using UnityEngine;

public class RangedKaijuIdleState : RangedKaijuBaseState
{
    public RangedKaijuIdleState(RangedKaiju rangedKaiju) : base(rangedKaiju)
    {
    }

    public override void Enter()
    {
        _animName = "Idle";
        base.Enter();
        Debug.Log("Idle");
    }

    public override void Update()
    {
        if(DetectPlayer())
        {
            _rangedKaiju.ChangeState(_rangedKaiju.AttackState);
        }
    }
}