using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantable_SM : MonoBehaviour

{
    private StateIds currentStateId = StateIds.Empty;
    [SerializeField] SpriteRenderer _SpriteRenderer;
    [SerializeField] Material materialInicial;
    [SerializeField] Material MaterialOnMouseHover;
    [SerializeField] SpriteRenderer SpriteChild;
    [SerializeField] Sprite Sprite1;
    [SerializeField] Sprite Sprite2;
    [SerializeField] Sprite Sprite3;

    SpriteRenderer IntzitedChild;

    Material _materialPrevio;
    bool _IsMouseOver = false;


    private void FixedUpdate()
    {
        switch (currentStateId)
        {
            case StateIds.Empty:
                break;
            case StateIds.Planted:
                if (!IntzitedChild)
                {
                    var collid = _SpriteRenderer.GetComponent<Collider2D>();
                    collid.enabled = true;
                    currentStateId = StateIds.Empty;
                }
                break;
        }
    }
    public void OnMouseDown()
    {
        switch (currentStateId)
        {
            case StateIds.Empty:

                InstantiatePrefab(SpriteChild, _SpriteRenderer.transform);
                currentStateId = StateIds.Planted;
                var colli = _SpriteRenderer.GetComponent<Collider2D>();
                colli.enabled = false;
                break;

            case StateIds.Planted:

                break;
        }
    }

    public void InstantiatePrefab(SpriteRenderer PlantPrefab, Transform SpawnPos)
    {
        IntzitedChild = Instantiate<SpriteRenderer>(PlantPrefab, SpawnPos);
        IntzitedChild.transform.localPosition = Vector3.zero;
        IntzitedChild.transform.localRotation = Quaternion.identity;
    }
    private void Start()
    {
        int rInt = Random.Range(1, 6);
        switch (rInt)
        {
            case 1:
            case 4:
            case 5:
                _SpriteRenderer.sprite = Sprite1;
                break;
            case 2:
                _SpriteRenderer.sprite = Sprite2;
                break;
            case 3:
                _SpriteRenderer.sprite = Sprite3;
                break;

        }
    }

    private void Awake()
    {
        
        _SpriteRenderer.material = materialInicial;
    }

    private void OnMouseUp()
    {
        _SpriteRenderer.material = materialInicial;
        _SpriteRenderer.color = Color.white;
        _IsMouseOver = false;
    }

    private void OnMouseOver()
    {
        if (!_IsMouseOver)
        {
            _SpriteRenderer.color = Color.red;
            _materialPrevio = _SpriteRenderer.material;
            _SpriteRenderer.material = MaterialOnMouseHover;
        }
        _IsMouseOver = true;

    }
    private void OnMouseExit()
    {
        _IsMouseOver = false;
        _SpriteRenderer.material = materialInicial;
        _SpriteRenderer.color = Color.white;
    }
}

public enum StateIds
{
    Empty,
    Planted
}
