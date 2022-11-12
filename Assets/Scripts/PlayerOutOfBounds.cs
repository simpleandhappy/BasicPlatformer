using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject == Player.Instance.gameObject){
            Player.Instance.RestartLevel();
        }
    }
}
