using Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransation : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    [SerializeField] CinemachineConfiner2D confiner;
    [SerializeField] string nextSceneName;
    [SerializeField] Direction direction;  
    [SerializeField] float additivePos = 2f;

    enum Direction { up, down, Left, Right }

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
        if (collision.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundry;
            confiner.InvalidateCache();

            UpdatePlayerPosition(collision.gameObject);
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }


    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        switch (direction) 
        {
            case Direction.up:
                newPos.y += additivePos;
                break;
            case Direction.down:
                newPos.y -= additivePos;
                break;
            case Direction.Left:
                newPos.x += additivePos;
                break;
            case Direction.Right:
                newPos.x -= additivePos;
                break;
        }

        player.transform.position = newPos;
    }





}
