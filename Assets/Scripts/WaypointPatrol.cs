using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    // waypointを複数持てるよう配列にする
    [SerializeField] Transform[] waypoints;
    int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        // 目的地までの距離が、インスペクターで設定した到達とみなす範囲より小さいか
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            // indexがwaypoints.lengthに等しい場合、一番最初のwaypointに再設定
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            // 次のwaypointに設定
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}