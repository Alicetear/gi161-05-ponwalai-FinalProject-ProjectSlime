using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransation : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    [SerializeField] CinemachineConfiner2D confiner;  

    [System.Obsolete]
    private void Awake()
    {
        if (confiner == null)
        {
            confiner = FindObjectOfType<CinemachineConfiner2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && confiner != null)
        {
            confiner.m_BoundingShape2D = mapBoundry;
            confiner.InvalidateCache();
        }
    }
}
