using UnityEngine;
using UnityEngine.UI;

public class WalkupToSign : MonoBehaviour
{
    public GameObject dialogBoxSign;
    public Text dialogTextSign;
    public string dialog;
    public bool playerInRangeSign;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRangeSign && !PauseManager.isPaused)
        {
            if(dialogBoxSign.activeInHierarchy)
            {
                dialogBoxSign.SetActive(false);
            }else
            {
                dialogBoxSign.SetActive(true);
                dialogTextSign.text = dialog;
            }
        }
        if(PauseManager.isPaused)
        {
            dialogBoxSign.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRangeSign = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRangeSign = false;
            dialogBoxSign.SetActive(false);
        }
    }
}
