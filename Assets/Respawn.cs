using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
    public GameObject RespawnPoint;
    public GameObject PlayerPrefab;
    public GameObject DamageUI;

    Image DamageOverlay;
    void Start()
    {
        //PlayerPrefab = GameObject.Find("Player");
        //RespawnPoint = GameObject.Find("RespawnPoint");
        //DamageUI = GameObject.Find("DamageUI");
        DamageOverlay = DamageUI.transform.FindChild("DamageOverlay").GetComponent<Image>();
    }
    
    
    
    void Update()
    {
        if(Input.GetButtonDown("Respawn"))
        {
            Destroy(GameObject.Find("DeathParent"));
            Instantiate(PlayerPrefab, RespawnPoint.transform.position, Quaternion.identity);
            Color overlayColor = DamageOverlay.color;
            overlayColor.a = 0;
            DamageOverlay.color = overlayColor;           
        }
        
    }

}
