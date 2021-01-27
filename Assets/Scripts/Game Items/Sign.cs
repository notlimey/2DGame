using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject DialogBoxSign;
    public Text DialogTextSign;
    public string Dialog;
    public bool PlayerInRangeSign;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && PlayerInRangeSign && !PauseManager._gameIsPaused)
        {
            if(DialogBoxSign.activeInHierarchy)
            {
                DialogBoxSign.SetActive(false);
            }else
            {
                DialogBoxSign.SetActive(true);
                DialogTextSign.text = Dialog;
            }
        }
        if(PauseManager._gameIsPaused)
        {
            DialogBoxSign.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInRangeSign = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRangeSign = false;
            DialogBoxSign.SetActive(false);
        }
    }
}
