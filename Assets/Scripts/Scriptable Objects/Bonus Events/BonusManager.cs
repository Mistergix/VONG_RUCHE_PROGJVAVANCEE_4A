using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private PoolManager bonusPool;
    [SerializeField]
    private float bonusSpawnWaitTime;
    [SerializeField]
    [Range(0, 1)]
    private float xFreeSpace, yFreeSpace;
    [SerializeField]
    private List<BonusEvent> bonusEvents;

    private Vector3 minPos = Vector3.zero, maxPos = Vector3.zero;

    private bool canSpawn;

    private void Start()
    {
        float remainingX = (1 - xFreeSpace) / 2;
        float remainingY = (1 - yFreeSpace) / 2;

        Camera main = Camera.main;

        Vector3 bottom = main.ViewportToWorldPoint(new Vector3(remainingX, remainingY, main.transform.position.y));
        Vector3 top = main.ViewportToWorldPoint(new Vector3(1 - remainingX, 1 - remainingY, main.transform.position.y));

        minPos = new Vector3(bottom.x, 0, bottom.z);
        maxPos = new Vector3(top.x, 0, top.z);
        canSpawn = true;

        StartCoroutine(SpawnRandomBonuses());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(minPos, 0.5f);
        Gizmos.DrawSphere(maxPos, 0.5f);
    }

    private void SpawnBonus()
    {
        GameObject bonusGo = bonusPool.RequestACopy();

        Bonus bonus = bonusGo.GetComponent<Bonus>();

        float x = Random.Range(minPos.x, maxPos.x);
        float y = Random.Range(minPos.z, maxPos.z);

        bonusGo.transform.position = new Vector3(x, -0.5f, y);

        bonus.Init(bonusEvents[Random.Range(0, bonusEvents.Count)]);
    }

    IEnumerator SpawnRandomBonuses()
    {
        SpawnBonus();

        while(canSpawn)
        {
            yield return new WaitForSeconds(bonusSpawnWaitTime);
            SpawnBonus();
        }
    }

    public void BonusHealth(Player affectedPlayer)
    {
        affectedPlayer.OverHeal();
    }

    public void ReduceCooldown(Player affectedPlayer) {
        affectedPlayer.ReduceCD();
    }
}
