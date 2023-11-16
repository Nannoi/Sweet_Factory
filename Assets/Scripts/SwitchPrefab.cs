using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPrefab : MonoBehaviour
{
    public GameObject DuckPrefab;
    public GameObject CoinPrefab;
    public GameObject BallPrefab;
    public GameObject FlowerPrefab;
    public Emitter Spawn;

    // Start is called before the first frame update
    void Start()
    {
        if (Spawn == null)
        {
            Debug.LogError("Spawn reference not set. Please assign the Emitter component in the inspector.");
        }
    }

    public void SwitchToDuck()
    {
        if (Spawn != null && DuckPrefab != null)
        {
            Spawn.SetSpawnPrefab(DuckPrefab);
        }
        else
        {
            Debug.LogError("Spawn reference or DuckPrefab not set. Please assign the references in the inspector.");
        }
    }

    public void SwitchToCoin()
    {
        if (Spawn != null && CoinPrefab != null)
        {
            Spawn.SetSpawnPrefab(CoinPrefab);
        }
        else
        {
            Debug.LogError("Spawn reference or CoinPrefab not set. Please assign the references in the inspector.");
        }
    }

    public void SwitchToFlower()
    {
        if (Spawn != null && FlowerPrefab != null)
        {
            Spawn.SetSpawnPrefab(FlowerPrefab);
        }
        else
        {
            Debug.LogError("Spawn reference or FlowerPrefab not set. Please assign the references in the inspector.");
        }
    }

    public void SwitchToBall()
    {
        if (Spawn != null && BallPrefab != null)
        {
            Spawn.SetSpawnPrefab(BallPrefab);
        }
        else
        {
            Debug.LogError("Spawn reference or BallPrefab not set. Please assign the references in the inspector.");
        }
    }
}
