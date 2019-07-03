using UnityEngine;

public class PlayerHealth : GenericHealth
{
    [SerializeField] Signal _healthSignal;

    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        MaxHealth.RuntimeValue = CurrentHealth;
        _healthSignal.Raise();
    }
}
