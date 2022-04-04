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
        float DistanceBetween = Vector3.Distance(enemyBrain.Target.transform.position, transform.position);
        //Debug.Log(DistanceBetween + "between");
        if (DistanceBetween < Distance)
        {
            aiActionData.TargetSpottet = true;
            //Debug.Log("VI FA^NDT HAM SGU DRENGENE");
            //Debug.Log(DistanceBetween);
        }
        else
        {
            aiActionData.TargetSpottet = false;
            //Debug.Log(Distance);
            //Debug.Log("OK WTF");
            //Debug.Log(DistanceBetween);
        }
        return aiActionData.TargetSpottet;

    }

    protected void OnDrawGizmos()
    {
        /*if(UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Distance);
            Gizmos.color = Color.white;
        }*/
    }
}


