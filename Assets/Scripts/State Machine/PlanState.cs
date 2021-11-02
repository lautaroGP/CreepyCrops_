using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlanState : MonoBehaviour
{
    [SerializeField] SpriteRenderer _SpriteRenderer;

    [SerializeField] PlantStateIds currentStateId = PlantStateIds.Planted;
    [SerializeField] int GrowthInterval = 5000;
    [SerializeField] int GeneratingInterval = 5000;
    [SerializeField] int GenerateResourseInterval = 1000;
    [SerializeField] int GrowingInterval = 5000;
    [SerializeField] int DyingInterval = 5000;
    Timer timer = new Timer();


    [SerializeField] Sprite SpritePlanted;
    [SerializeField] Sprite SpriteGrowing;
    [SerializeField] Sprite SpriteGenerating;
    [SerializeField] Sprite SpriteDying;
    float ElapsedTime=0;

    private void FixedUpdate()
    {
        ElapsedTime += Time.fixedDeltaTime;
        switch (currentStateId)
        {
            case PlantStateIds.Planted:
                //if (!timer.Enabled)
                //{
                //    _SpriteRenderer.sprite = SpritePlanted;

                //    timer = new System.Timers.Timer();
                //    timer.Elapsed += new ElapsedEventHandler(OnTimedEventPlanted);
                //    timer.Interval = GrowthInterval;
                //    timer.Enabled = true;

                    
                    
                //}
               if (ElapsedTime > GrowthInterval)
                {
                    currentStateId = PlantStateIds.Growing;
                    _SpriteRenderer.sprite = SpriteGrowing;
                    ElapsedTime = 0;
                }
                break;

            case PlantStateIds.Growing:
                //if (!timer.Enabled)
                //{

                //    timer = new System.Timers.Timer();
                //    timer.Elapsed += new ElapsedEventHandler(OnTimedEventGrowing);
                //    timer.Interval = GrowingInterval;
                //    timer.Enabled = true;
                //}
                if (ElapsedTime > GrowingInterval)
                {
                    currentStateId = PlantStateIds.Generating;
                    _SpriteRenderer.sprite = SpriteGenerating;
                    ElapsedTime = 0;
                }
                break;

            case PlantStateIds.Generating:
                //if (!timer.Enabled)
                //{
                //    _SpriteRenderer.sprite = SpriteGenerating;
                //    timer = new System.Timers.Timer();
                //    timer.Elapsed += new ElapsedEventHandler(OnTimedEventGenerating);
                //    timer.Interval = GeneratingInterval;
                //    timer.Enabled = true;
                //}
                if (ElapsedTime > GeneratingInterval)
                {
                    currentStateId = PlantStateIds.Dying;
                    _SpriteRenderer.sprite = SpriteDying;
                    ElapsedTime = 0;
                }

                break;

            case PlantStateIds.Dying:
                //if (!timer.Enabled)
                //{
                //    _SpriteRenderer.sprite = SpriteDying;
                //    timer = new System.Timers.Timer();
                //    timer.Elapsed += new ElapsedEventHandler(OnTimedEventDying);
                //    timer.Interval = DyingInterval;
                //    timer.Enabled = true;
                //}
                if (ElapsedTime >DyingInterval)
                {
                    Destroy(gameObject);
                   
                }
                break;
        }
    }

    //private void OnTimedEventPlanted(object source, ElapsedEventArgs e)
    //{
    //    currentStateId = PlantStateIds.Growing;

    //    timer.Enabled = false;
    //    timer.Dispose();
    //}
    //private void OnTimedEventGrowing(object source, ElapsedEventArgs e)
    //{
    //    currentStateId = PlantStateIds.Generating;
    //    timer.Enabled = false;
    //    timer.Dispose();
    //}
    //private void OnTimedEventGenerating(object source, ElapsedEventArgs e)
    //{
    //    currentStateId = PlantStateIds.Dying;
    //    timer.Enabled = false;
    //    timer.Dispose();
    //}
    //private void OnTimedEventDying(object source, ElapsedEventArgs e)
    //{

    //    timer.Enabled = false;
    //    timer.Dispose();
    //    if (_SpriteRenderer)
    //    {
    //        //_SpriteRenderer.sprite = null;
    //        //var comp = _SpriteRenderer.GetComponent<SpriteRenderer>();
    //        //Destroy(comp.gameObject);
    //        destroy = true;

    //    }
    //    //Destroy(GetComponent<SpriteRenderer>().gameObject);
    //}


    public enum PlantStateIds
    {
        Planted,
        Growing,
        Generating,
        Dying
    }
}
