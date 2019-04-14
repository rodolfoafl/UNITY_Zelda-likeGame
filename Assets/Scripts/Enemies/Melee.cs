using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Enemies;

public class Melee : Log {

    public override void CheckTargetDistance()
    {
        if (CurrentState == CharacterState.STAGGER || CurrentState == CharacterState.ATTACK)
        {
            return;
        }

        if (Vector3.Distance(Target.position, transform.position) <= ChaseRadius && Vector3.Distance(Target.position, transform.position) > AttackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);
            ChangeState(CharacterState.WALK);
            ChangeAnimation(temp - transform.position);
            Rigidbody.MovePosition(temp);
        }
        else if (Vector3.Distance(Target.position, transform.position) <= ChaseRadius && Vector3.Distance(Target.position, transform.position) <= AttackRadius && Target.gameObject.activeInHierarchy)
        {
            if(CurrentState == CharacterState.WALK && CurrentState != CharacterState.STAGGER)
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        CurrentState = CharacterState.ATTACK;
        Animator.SetBool("attack", true);
        yield return new WaitForSeconds(1f);
        CurrentState = CharacterState.WALK;
        Animator.SetBool("attack", false);
    }

}
