using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] NavMeshAgent agent;

    public float speed;

    //Timer
    public float scatterBaseTime;
    public float chaseBaseTime;
    [SerializeField] private float scatterTime;
    [SerializeField] private float chaseTime;


    enum ChaseState
    {
        Scatter,
        Chase
    }
    ChaseState state = ChaseState.Chase;

    private void Update()
    {
        #region

        switch (state)
        {
            case ChaseState.Chase:
                if (chaseTime > 0)
                {
                    chaseTime -= Time.deltaTime;
                    Chase();
                }
                else
                {
                    state = ChaseState.Scatter;
                    chaseTime = scatterBaseTime;
                }
                break;
            case ChaseState.Scatter:
                if (scatterTime > 0)
                {
                    scatterTime -= Time.deltaTime;
                    Scatter();
                }
                else
                {
                    state = ChaseState.Chase;
                    chaseTime = chaseBaseTime;
                }
                break;
        }

        #endregion
    }

    public virtual void Scatter()
    {

    }

    public virtual void Chase()
    {
        agent.SetDestination(target.transform.position);
    }
}
