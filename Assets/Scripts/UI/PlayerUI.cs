using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI lifeText;

    [SerializeField]
    private Image shootImage, spawnImage;

    private Player player;

    private Coroutine shootUICoroutine;
    private Coroutine spawnUICoroutine;

    public void Init(Player player)
    {
        this.player = player;

        LifeTextUpdate();
    }

    public void OnPlayerTakeDamage()
    {
        LifeTextUpdate();
    }

    public void OnPlayerShoot()
    {
        if(shootUICoroutine != null)
        {
            StopCoroutine(shootUICoroutine);
        }
        
        shootUICoroutine = StartCoroutine(ShootUI());
    }

    public void OnPlayerSpawnBoat()
    {
        if (spawnUICoroutine != null)
        {
            StopCoroutine(spawnUICoroutine);
        }

        spawnUICoroutine = StartCoroutine(SpawnUI());
    }

    private void LifeTextUpdate()
    {
        lifeText.text = string.Format("{0}/{1}", player.CurrentLife, player.MaxLife);
    }

    private float elapsedShootTime;

    private IEnumerator ShootUI()
    {
        elapsedShootTime = 0;

        while(elapsedShootTime < player.ShootCooldown)
        {
            elapsedShootTime += Time.deltaTime;

            shootImage.fillAmount = elapsedShootTime / player.ShootCooldown;

            yield return new WaitForEndOfFrame();
        }

        shootImage.fillAmount = 1;
    }

    private float elapsedSpawnTime;

    private IEnumerator SpawnUI()
    {
        elapsedSpawnTime = 0;

        while (elapsedSpawnTime < player.SpawnCoolDown)
        {
            elapsedSpawnTime += Time.deltaTime;

            spawnImage.fillAmount = elapsedSpawnTime / player.SpawnCoolDown;

            yield return new WaitForEndOfFrame();
        }

        spawnImage.fillAmount = 1;
    }
}
