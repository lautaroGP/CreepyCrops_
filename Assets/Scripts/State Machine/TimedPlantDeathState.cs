using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlantDeathState : TimedPlantState
{
    public override void CustomUpdate(float deltaTime)
    {
        TimeElapsed += deltaTime;
        if (TimeElapsed > TimeInterval)
        {
            EndState();
        }
    }
    public override void EndState()
    {
        Destroy(SM.gameObject);
    }
}
