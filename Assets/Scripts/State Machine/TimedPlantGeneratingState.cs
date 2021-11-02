using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlantGeneratingState : TimedPlantState
{

    [SerializeField] float GeneratingTime;

    [SerializeField] SpriteRenderer Prefab;

    float ElapsedGeneratingTime = 0;

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);
        ElapsedGeneratingTime += deltaTime;
        if (ElapsedGeneratingTime > GeneratingTime)
        {
            ElapsedGeneratingTime = 0;
            var obj = Instantiate<SpriteRenderer>(Prefab);
            obj.transform.position = transform.position + new Vector3(Random.Range(-1,1), Random.Range(-1, 1));
            obj.transform.localScale = new Vector3(.5f, .5f, .5f);
            obj.transform.rotation = Quaternion.identity;

        }

    }


    





}
