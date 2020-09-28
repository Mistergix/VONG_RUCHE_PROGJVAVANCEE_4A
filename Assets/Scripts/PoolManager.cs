using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _referencePrefab;
	[SerializeField]
	private int numberOfInstancesAtStart;
    private List<GameObject> copies;
    private void Start()
    {
        copies = new List<GameObject>();
        for (int i = 0; i < numberOfInstancesAtStart; i++)
        {
            GameObject go = Instantiate(_referencePrefab, transform);
            go.SetActive(false);
            copies.Add(go);
        }
    }

    public GameObject RequestACopy()
    {
        return _RequestACopy();
    }

    private GameObject _RequestACopy()
    {
        foreach (var copy in copies)
        {
            if (! copy.activeInHierarchy)
            {
                copy.SetActive(true);
                return copy;
            }
        }

        GameObject go = Instantiate(_referencePrefab, transform);
        copies.Add(go);

        return go;
    }

    public static void RecycleGameObject(GameObject go)
    {
        go.SetActive(false);
    }
}
