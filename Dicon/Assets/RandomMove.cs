using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        StartCoroutine(randMove(0f));    
    }


    IEnumerator randMove(float rand)
    {
        yield return new WaitForSeconds(rand);
        float randX = Random.Range(5f, 7f) * ((Random.Range(0, 2) == 0) ? (1) : (-1));
        float randZ = Random.Range(5f, 7f) * ((Random.Range(0, 2) == 0) ? (1) : (-1));
        Vector3 randPos = this.transform.position + new Vector3(randX, 1f, randZ);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(randPos), 8f * Time.deltaTime);
        nav.SetDestination(randPos);
        float _time = nav.remainingDistance / nav.speed;
        StartCoroutine(randMove(_time));
        if (nav.remainingDistance >= float.PositiveInfinity) Invoke("invokeMove", 0f);
        //Debug.Log(this.gameObject.name +", "+ nav.remainingDistance);
    }

    private void invokeMove() { StartCoroutine(randMove(0.1f)); }
}
