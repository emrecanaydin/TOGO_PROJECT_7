using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePlay : MonoBehaviour, IDragHandler
{

    GameManager GM;
    private Transform player, playerReflect;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GM.player;
        playerReflect = GM.playerReflect;
    }

    public void OnDrag(PointerEventData eventData)
    {

        Vector3 position = player.position;
        position.x = Mathf.Clamp(position.x + (eventData.delta.x / 100), -3.15f, 3.15f);
        player.position = position;
        playerReflect.position = Vector3.Reflect(player.position, Vector3.right);

        GM.isPlayersMerged = Mathf.Abs(position.x) <= 0.35;

    }
}