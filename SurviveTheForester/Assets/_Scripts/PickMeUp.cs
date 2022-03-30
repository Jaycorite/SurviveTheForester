using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PickMeUp : MonoBehaviour, IInteractable
{
    SpriteGlow.SpriteGlowEffect glow;
    [SerializeField]
    InventoryUI inventory;

    // Start is called before the first frame update
    void Start()
    {
        glow = GetComponent<SpriteGlow.SpriteGlowEffect>();
        glow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Focus()
    {
        glow.enabled = true;
    }

    public void PrimaryUse()
    {
        inventory.AddItem(this.gameObject);
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Pick_Up");
    }

    public void SecondaryUse()
    {
        throw new System.NotImplementedException();
    }

    public void Unfocus()
    {
        glow.enabled = false;
    }
}
