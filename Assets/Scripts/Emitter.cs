using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    [SerializeField] public GameObject Spawnprefab;
    [SerializeField] private float SpawnRate = 0.1f;
    [SerializeField] private int MaxParticle = 3;
    [SerializeField] private Vector2 SizeRange;

    private GameObject[] pool;
    private Color[] colors = { new Color(1.0f, 0.5f, 0.5f), new Color(1.0f, 1.0f, 0.5f), new Color(0.5f, 1.0f, 0.5f), new Color(0.5f, 0.5f, 1.0f) };
    private float colorIntensity = 1.5f;

    void Start()
    {
        InitializePool();
        SpawnObjects();
    }

    private void InitializePool()
    {
        pool = new GameObject[MaxParticle];
        for (int i = 0; i < MaxParticle; i++)
        {
            var particle = Instantiate(Spawnprefab);
            particle.SetActive(false);
            pool[i] = particle;
        }
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnObjects");
    }
    public void SetSpawnPrefab(GameObject newPrefab)
    {
        Spawnprefab = newPrefab;
        InitializePool();
    }

    private void SpawnObjects()
    {
        foreach (var particle in pool)
        {
            if (!particle.activeSelf)
            {
                particle.transform.position = transform.TransformPoint(Random.insideUnitSphere * 0.5f);
                particle.transform.localScale = Random.Range(SizeRange.x, SizeRange.y) * Vector3.one;
                //SetRandomColor(particle);
                particle.SetActive(true);
                break;
            }
        }
        Invoke("SpawnObjects", SpawnRate);
    }

    /*private void SetRandomColor(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            int index = Random.Range(0, colors.Length);
            Color newColor = colors[index] * colorIntensity;
            renderer.material.color = newColor;
        }
        else
        {
            Debug.Log("Renderer component not found in the prefab.");
        }
    }*/
}

