using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameEnding gameEnding;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            // AからBのベクトルは、B-Aである
            // Vector3.up = (0, 1, 0)
            Vector3 direction = player.position - transform.position + Vector3.up;

            // raycasterの作成
            Ray ray = new Ray(transform.position, direction);

            RaycastHit raycastHit;
            // outパラメータを使うことで、bool値だけでなくメソッドから情報を取得できる
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}