using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlantState : MonoBehaviour
{
    [SerializeField] protected TimedStateFunction Function;
    [SerializeField] protected Sprite Sprite;
    [SerializeField] protected int TimeInterval;
    [SerializeField] protected TimedPlantState NextState;
    [SerializeField] string AnimationTrigger;

    protected float TimeElapsed = 0;
    protected TimedPlantSM SM;

    public void OnEnter(TimedPlantSM sm)
    {
        SM = sm;
        
        SM.SpriteRenderer.sprite = Sprite;
        
        //SM.Animator.SetTrigger(AnimationTrigger);
        TimeElapsed = 0;
    }

    public virtual void CustomUpdate(float deltaTime)
    {
        TimeElapsed += deltaTime;
        if(TimeElapsed > TimeInterval)
        {
            EndState();
        }
    }

    public virtual void EndState()
    {
        SM.SetState(NextState);
    }

    public virtual void OnClick()
    {
        Destroy(SM.gameObject);
    }

}
