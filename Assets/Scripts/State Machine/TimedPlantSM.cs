using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlantSM : MonoBehaviour
{


    [SerializeField] TimedPlantState Current;
    [SerializeField] SpriteRenderer _SpriteRenderer;
    [SerializeField] Animator _Animator;
    public SpriteRenderer SpriteRenderer => _SpriteRenderer;
    public Animator Animator => _Animator;

    private void Start()
    {
        Current.OnEnter(this);
    }

    private void Update()
    {
        Current.CustomUpdate(Time.deltaTime);
    }

    public void SetState(TimedPlantState st)
    {
        if (st && st!=Current)
        {
            Current = st;
            Current.OnEnter(this);
        }
    }

    private void OnMouseDown()
    {
        Current.OnClick();
    }

}
