using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecisions : AIDecision
{
    [field: SerializeField]
    [field: Range(0.1f, 10)]
    public float Distance { get; set; } = 5;

    public override bool MakeADecision()
    {
        if(Vector3.Distance(enemyBrain.Target.transform.position, transform.position) < Distance)
        {
            if(aiActionData.TargetSpottet==false)
            {
                aiActionData.TargetSpottet = true;
                return true;
            }
        }
        else
        {
            aiActionData.TargetSpottet = false;
            return false;
        }
           return aiActionData.TargetSpottet;
       
    }

    protected void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Distance);
            Gizmos.color = Color.white;
        }
    }
}


