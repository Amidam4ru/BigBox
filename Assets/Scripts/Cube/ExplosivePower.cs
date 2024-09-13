using UnityEngine;

public class ExplosivePower : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 1f;

    private CrushingCube _crushingCube;

    private void Awake()
    {
        _crushingCube = GetComponent<CrushingCube>();
    }

    private void OnEnable()
    {
        _crushingCube.Crushing += BlowUp;
    }

    private void OnDisable()
    {
        _crushingCube.Crushing -= BlowUp;
    }

    public void BlowUp(Vector3 pointOfExplosion)
    {
        Collider[] colliders = Physics.OverlapSphere(pointOfExplosion, _explosionRadius);
        _explosionForce = _explosionForce * transform.localScale.x;

        foreach (Collider hit in colliders)
        {
            Rigidbody _rigidbody = hit.GetComponent<Rigidbody>();

            if (_rigidbody != null)
            {
                _rigidbody.AddExplosionForce(_explosionForce, pointOfExplosion, _explosionRadius, _upwardModifier, ForceMode.Impulse);
            }
        }
    }
}
