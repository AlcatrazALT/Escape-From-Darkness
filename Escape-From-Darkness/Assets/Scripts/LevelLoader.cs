using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    bool isPlayerInZone;

    public string levelToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        isPlayerInZone = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && isPlayerInZone)
        {
            Application.LoadLevel(levelToLoad);
            GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().levelLoader);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        if(otherCollision.tag == "Player")
        {
            isPlayerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D otherCollision)
    {
        if (otherCollision.tag == "Player")
        {
            isPlayerInZone = false;
        }
    }
}
