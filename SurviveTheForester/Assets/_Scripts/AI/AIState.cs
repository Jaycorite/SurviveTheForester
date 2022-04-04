using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private EnemyAIBrain enemyBrain = null;
    [SerializeField]
    private List<AIAction> actions = null;
    [SerializeField]
    private List<AITransition> transitions = null;

    private void Awake()
    {
        enemyBrain = transform.root.GetComponent<EnemyAIBrain>();
    }

    public void UpdateState()
    {

        bool result = false;
        bool firstHit = false;
        foreach (var action in actions)
        {
            action.TakeAction();
        }
        foreach (var transition in transitions)
        {
            //player in range -> True -> Back to Idle
            //Player visible -> True -> Chase
            
            transition.Decisions.ForEach(d => {
                result = d.MakeADecision();
            });


            if (result && !firstHit)
            {
                firstHit = true;
                if (result)
                {
                    enemyBrain.ChangeToState(transition.PositiveResult);
                    //Debug.Log(result + "hmmmmmmm");
                }
                else
                {
                    enemyBrain.ChangeToState(transition.NegativeResult);
                    //Debug.Log(result + "hmmmmmmm");
                }
            }
            else if (result && firstHit)
            {
                firstHit = false;
            }
            else
            {
                if (result)
                {
                    enemyBrain.ChangeToState(transition.PositiveResult);
                    //Debug.Log(result + "hmmmmmmm");
                    //Debug.Log(result + "HVAD");
                }
                else
                {
                    enemyBrain.ChangeToState(transition.NegativeResult);
                    //Debug.Log(result);
                }
            }
            //Debug.Log(enemyBrain.CurrentState);
        }
        
    }
}
