using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[RequireComponent(typeof(Collider2D))]
public class GenericDamage : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] string _otherTag;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_otherTag) && other.isTrigger)
        {
            GenericHealth component = other.GetComponent<GenericHealth>();
            if (component)
            {
                component.Damage(_damage);
            }
        }
    }
}
