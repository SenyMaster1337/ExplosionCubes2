using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(Vector3 ExplodePosition)
    {
        var ExplodableObjects = GetExplodableObjects();

        if (ExplodableObjects != null)
        {
            foreach (Rigidbody explodableObject in ExplodableObjects)
            {
                explodableObject.AddExplosionForce(_explosionForce, ExplodePosition, _explosionRadius);
            }
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> explosion = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                explosion.Add(hit.attachedRigidbody);
            }
        }

        return explosion;
    }
}
