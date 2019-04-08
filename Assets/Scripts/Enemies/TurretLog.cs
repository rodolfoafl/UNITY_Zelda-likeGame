using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Enemies;

public class TurretLog : Log {

	[SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _fireDelay;
    float _fireDelaySeconds;
    bool _canFire = true;

    void Update()
    {
        if (_fireDelaySeconds > 0)
        {
            _fireDelaySeconds -= Time.deltaTime;
        }
        if(_fireDelaySeconds <= 0)
        {
            _canFire = true;
            _fireDelaySeconds = _fireDelay;
        }
    }
	public override void CheckTargetDistance()
	{
		if(CurrentState == CharacterState.STAGGER || CurrentState == CharacterState.ATTACK)
        {
            return;
        }

        if (Vector3.Distance(Target.position, transform.position) <= ChaseRadius && Vector3.Distance(Target.position, transform.position) > AttackRadius)
        {
            if(_canFire)
            {
                Vector3 distanceVector = Target.transform.position - transform.position;
                GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
                projectile.GetComponent<Projectile>().Launch(distanceVector);
                _canFire = false;
                ChangeState(CharacterState.WALK);
                Animator.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(Target.position, transform.position) > ChaseRadius)
        {
            Animator.SetBool("wakeUp", false);
        }
	}
}
