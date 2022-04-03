using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    protected Animator enemyAnimator;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void SetWalkAnimation(bool val)
    {
        enemyAnimator.SetBool("Walk", val);
    }

    public void AnimateEnemy(float velocity)
    {
            SetWalkAnimation (velocity > 0);
    }
}