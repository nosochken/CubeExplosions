using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Explosion _exception;

    private void Awake()
    {
        _exception = GetComponent<Explosion>();
    }

    private void Update()
    {
        DestroyCube();
    }

    private void DestroyCube()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 20;

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.cyan);

        if (Physics.Raycast(ray, out RaycastHit hit) &&
            (Input.GetMouseButtonDown(0)))
        {
            if (hit.collider.GetComponent(typeof(Cube)))
                _exception.Explode(hit.transform.GetComponent<Cube>());
        }
    }
}