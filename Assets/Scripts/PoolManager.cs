using System;
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

    public int Id { get; set; }

    private void Awake()
    {
        copies = new List<GameObject>();

        AddNewCopies();
    }

    public GameObject RequestACopy()
    {
        return _RequestACopy();
    }

    /// <summary>
    /// Instantiates new copies, returns one of the object
    /// </summary>
    /// <returns></returns>
    private GameObject AddNewCopies(bool active = false, bool verbose = false)
    {
        for (int i = 0; i < numberOfInstancesAtStart; i++)
        {
            GameObject go = Instantiate(_referencePrefab, transform);
            go.SetActive(false);
            copies.Add(go);

            if(i == numberOfInstancesAtStart - 1)
            {
                if (verbose)
                {
                    Debug.Log("Added " + numberOfInstancesAtStart + " objects in " + gameObject + "Pool");
                }

                go.SetActive(active);

                return go;
            }
        }

        return new GameObject("POOL ERROR GAME OBJECT");
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

        return AddNewCopies(true, true);
    }

    public static void RecycleGameObject(GameObject go)
    {
        go.SetActive(false);
    }
}
