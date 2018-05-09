using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUIDetails : MonoBehaviour 
{
	Item item;
	Button selectedItemButton, itemInteractButton;
	Text itemNameText, itemDescriptionText, itemInteractButtonText;
	/* modif tuto 12*/

	public Text statText;
	  /* fin de mdif*/

	void Start()
	{
		itemNameText = transform.FindChild ("Item_Name").GetComponent<Text>();
		itemDescriptionText = transform.FindChild ("Item_Description").GetComponent<Text> ();
		itemInteractButton = transform.FindChild ("Button").GetComponent<Button> ();
		itemInteractButtonText = itemInteractButton.transform.FindChild ("Text").GetComponent<Text> ();

		/* modif */
		gameObject.SetActive (false);
	}

	public void SetItem(Item item, Button selectedButton)
	{
		/* Modif Tuto 11*/
		gameObject.SetActive (true);
		/* fin de modif*/
		/*modif tuto 12*/
		statText.text = "";
		if (item.Stats != null) 
		{
			foreach(BaseStat stat in item.Stats)
			{
				statText.text += stat.StatName + ": " + stat.BaseValue + "\n";
			}
		}
		/*fin de modfi tuto12*/

		itemInteractButton.onClick.RemoveAllListeners();
		this.item = item;
		selectedItemButton = selectedButton;
		itemNameText.text = item.ItemName;
		itemDescriptionText.text = item.Description;
		itemInteractButtonText.text = item.ActionName;
		itemInteractButton.onClick.AddListener (OnItemInteract);
	}
	public void OnItemInteract()
	{
		if (item.ItemType == Item.ItemTypes.Consumable) 
		{
			InventoryController.Instance.ConsumeItem (item);
			Destroy (selectedItemButton.gameObject);
		} 
		else if (item.ItemType == Item.ItemTypes.Weapon) 
		{
			InventoryController.Instance.EquipItem (item);
			Destroy (selectedItemButton.gameObject);
		}
		/*modificado en tuto 11*/
		item = null;
		gameObject.SetActive (false);
	}
}
