using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collision : MonoBehaviour
{

    GameManager GM;
    public ParticleSystem playerExplosion;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        playerExplosion.Stop();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CollectableHotDog" || other.tag == "CollectableHamburger") {
            if (!GM.isPlayersMerged)
            {
                HandleTriggerCollectable(other.gameObject);
            }
        }
        if(other.tag == "Obstacle")
        {
            StartCoroutine(HandleTriggerWithObstacle());
        }
        if(other.tag == "FinishLine")
        {
            StartCoroutine(HandleTriggerWithFinishLine());
        }
    }

    private void HandleTriggerCollectable(GameObject other)
    {
        GM.IncreaseCollectedByType(other.tag);
        Destroy(other, 0f);
    }

    private IEnumerator HandleTriggerWithObstacle()
    {
        playerExplosion.Play();
        GM.isGameOver = true;
        GM.isGameStarted = false;
        GM.lostPanel.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        transform.gameObject.SetActive(false);
    }

    private IEnumerator HandleTriggerWithFinishLine()
    {
        if (!GM.isPlayersMerged)
        {
            yield return new WaitForSeconds(2f);
            GM.player.transform.DOMoveX(0, 1f).OnComplete(() =>
                GM.isPlayersMerged = true
            );
        }
        GM.playerReflect.transform.DOMoveX(0, 1f);
        yield return new WaitForSeconds(1f);
        GM.isGameOver = true;
        GM.isGameStarted = false;
        GM.winPanelScoreText.text = $"You Won! You've collected \n {GM.collectedHamburger} burger \n {GM.collectedHotdog} hotdog.";
        GM.winPanel.SetActive(true);
    }

}
