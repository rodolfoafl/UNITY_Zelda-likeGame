using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [SerializeField] FloatValue _maxHealth;
    [SerializeField] float _currentHealth;

    #region Properties
    public FloatValue MaxHealth
    {
        get
        {
            return _maxHealth;
        }

        set
        {
            _maxHealth = value;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

        protected set
        {
            _currentHealth = value;
        }
    }
    #endregion

    private void Start()
    {
        _currentHealth = _maxHealth.RuntimeValue;
    }

    public virtual void Heal(float amountToHeal)
    {
        _currentHealth += amountToHeal;
        if(_currentHealth > _maxHealth.RuntimeValue)
        {
            _currentHealth = _maxHealth.RuntimeValue;
        }
    }

    public virtual void FullHeal()
    {
        _currentHealth = _maxHealth.RuntimeValue;
    }

    public virtual void Damage(float amountToDamage)
    {
        _currentHealth -= amountToDamage;
        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public virtual void InstantDeath()
    {
        _currentHealth = 0;
    }
}
