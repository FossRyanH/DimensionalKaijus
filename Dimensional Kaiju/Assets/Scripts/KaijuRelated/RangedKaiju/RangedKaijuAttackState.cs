using UnityEngine;

public class RangedKaijuAttackState : RangedKaijuBaseState
{
    public RangedKaijuAttackState(RangedKaiju rangedKaiju) : base(rangedKaiju)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Attacking");
        MusicManager.Instance.PlayMusic(_rangedKaiju.BattleMusic, true);
        GameManager.Instance.CurrentGameState = GameState.Battle;
    }

    public override void Exit()
    {
        var state = GameManager.Instance.CurrentGameState = GameState.OverWorld;
        GameManager.Instance.HandleStateChangeMusic(state);
    }

    public override void Update()
    {
        if (!DetectPlayer())
        {
            _rangedKaiju.ChangeState(_rangedKaiju.IdleState);
        }
    }
}