using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{

    public bool isReflectedPlayer;
    public Material defaultMaterial;

    GameManager GM;
    Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        defaultMaterial = transform.Find("Burrow").GetComponent<Renderer>().material;
        GM = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (GM.isGameStarted)
        {
            transform.position += new Vector3(0f, 0f, GM.playerMoveSpeed * Time.deltaTime);
            GM.playerGhost.position = new Vector3(0, 0, transform.position.z);
            playerAnimator.SetBool("isRunning", true);
        } else
        {
            playerAnimator.SetBool("isRunning", false);
        }
        if (GM.isPlayersMerged)
        {
            if (!isReflectedPlayer)
            {
                float scalePercentage = Mathf.Clamp(GM.GetCollectedCount() / 2, 1.3f, 2.65f);
                transform.DOScale(Vector3.one * scalePercentage, .5f);
                transform.Find("Burrow").GetComponent<Renderer>().material = GM.playerMergedMaterial;
            } else
            {
                transform.Find("Burrow").GetComponent<Renderer>().material = GM.playerTransparentMaterial;
            }
        }
        else
        {
            if (!isReflectedPlayer)
            {
                transform.DOScale(Vector3.one, .5f);
            }
            transform.Find("Burrow").GetComponent<Renderer>().material = defaultMaterial;
        }
    }

}
