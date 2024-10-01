using UnityEngine;

public class RangedKaijuBaseState : IState
{
    protected RangedKaiju _rangedKaiju;
    protected static string _animName;
    int _kaijuAnimation = Animator.StringToHash($"{_animName}");

    public RangedKaijuBaseState(RangedKaiju rangedKaiju)
    {
        _rangedKaiju = rangedKaiju;
    }

    public virtual void Enter()
    {
        _rangedKaiju.Animator.PlayInFixedTime(_kaijuAnimation);
    }

    public virtual void Exit()
    {
        // 
    }

    public virtual void PhysicsUpdate()
    {
        // 
    }

    public virtual void Update()
    {
        // 
    }

    protected bool DetectPlayer()
    {
        Vector2 circleCenter = _rangedKaiju.transform.position;
        float circleRadius = 5f;
        int layerMask = LayerMask.GetMask("Player");

        bool isHit = Physics2D.CircleCast(circleCenter, circleRadius, Vector2.zero, 0, layerMask);

        return isHit;
    }

}