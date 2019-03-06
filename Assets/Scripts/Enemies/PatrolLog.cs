using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Enemies;

public class PatrolLog : Log {

	[Header("Attributes")]
	[SerializeField] Transform[] _path;
    [SerializeField] Transform _currentGoal;
    [SerializeField] int _currentPoint;
	[SerializeField] float _roundingDistance;

	public override void CheckTargetDistance()
    {
        if(CurrentState == CharacterState.STAGGER || CurrentState == CharacterState.ATTACK)
        {
            return;
        }

        if (Vector3.Distance(Target.position, transform.position) <= ChaseRadius && Vector3.Distance(Target.position, transform.position) > AttackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);
            ChangeAnimation(temp - transform.position);
            Rigidbody.MovePosition(temp);
            Animator.SetBool("wakeUp", true);
        }
        else if(Vector3.Distance(Target.position, transform.position) > ChaseRadius)
        {
			if(Vector3.Distance(transform.position, _path[_currentPoint].position) > _roundingDistance)
			{
				Vector3 temp = Vector3.MoveTowards(transform.position, _path[_currentPoint].position, MoveSpeed * Time.deltaTime);
				ChangeAnimation(temp - transform.position);
				Rigidbody.MovePosition(temp);
			}
			else
			{
				ChangeGoal();
			}
        }
    }

	void ChangeGoal()
	{
		if(_currentPoint == _path.Length - 1)
		{
			_currentPoint = 0;
			_currentGoal = _path[_currentPoint];
		}
		else
		{
			_currentPoint++;
			_currentGoal = _path[_currentPoint];
		}
	}

}
