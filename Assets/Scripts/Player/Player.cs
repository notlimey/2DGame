using System.Collections;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;
    void Start()
    {
        LoadMyPlayer();
        StartCoroutine(AutoSave());
    }

    float[] PlayerPosition = new float[3];

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
    }

    private void OnTriggerEnter2D(Collider2D boxCollider)
    {
        ItemWorld itemWorld = boxCollider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            //Touch item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            PlayerPosition[0] = transform.position.x;
            PlayerPosition[1] = transform.position.y;
            PlayerPosition[2] = transform.position.z;
            SaveSystem.SavePlayer(new PlayerProfile { PlayerName = SelectedProfile.Username, Position = PlayerPosition}, false);
        }
    }

    public void LoadMyPlayer()
    {
        string path = Application.persistentDataPath + "/saves/" + SelectedProfile.Username + "/" + SelectedProfile.Username + ".dat";
        PlayerProfile data = SaveSystem.LoadPlayer(path);

        if (data.Position != null)
        {
            Vector3 position;
            position.x = data.Position[0];
            position.y = data.Position[1];
            position.z = data.Position[2];

            transform.position = position;
        }
    }
}
