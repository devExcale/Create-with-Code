using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{

    public PowerupData Data
    {
        get => PData;
        set
        {
            if (PData != null)
                throw new Exception("Cannot edit Powerup object anymore");

            PData = value;
        }
    }
    protected PowerupData PData;

    protected GameObject IndicatorObj;

    protected virtual void OnEnable()
    {
        IndicatorObj = Instantiate(PData.IndicatorPrefab, transform.position, Quaternion.identity);
        
        Invoke(nameof(Disable), PData.Duration);
    }

    protected virtual void LateUpdate()
    {
        IndicatorObj.transform.position = transform.position;
    }

    protected virtual void OnDestroy()
    {
        Disable();
    }

    protected virtual void Disable()
    {
        Destroy(IndicatorObj);
        Destroy(this);
    }
    
}