using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : Door
{
    
    public override Vector3 Use() {
        GameManager.isClear = true;
        SceneManager.LoadScene("EndScene");
        
        return Vector3.zero;
    }
}
