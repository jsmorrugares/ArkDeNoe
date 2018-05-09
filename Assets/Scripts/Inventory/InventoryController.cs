using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryController : MonoBehaviour 
{
	public static InventoryController Instance { get; set;}
	public PlayerWeaponController playerWeaponController;
	public ConsumableController consumableController;
	public InventoryUIDetails inventoryDetailsPanel;
	public List<Item> playerItems = new List<Item> ();
	/*public Item sword;
	public Item PotionLog;*/

	void Start()
	{
		if (Instance != null && Instance != this)
			Destroy (gameObject);
		else
			Instance = this;
		
		playerWeaponController = GetComponent<PlayerWeaponController> ();
		consumableController = GetComponent<ConsumableController>();
		GiveItem ("sword");
		GiveItem ("potion_log");
		/*List<BaseStat> swordStats = new List<BaseStat> ();
		swordStats.Add (new BaseStat (6, "Power", "Wour power level"));
		sword = new Item (swordStats, "staff");

		PotionLog = new Item (new List<BaseStat> (), "potion_log", "Drink this to log someting cool!", "Drink", "Log Potion", false);
*/
	}

	public void GiveItem(string itemSlug)
	{
		/*playerItems.Add (ItemDatabase.Instance.GetItem (itemSlug));
		Debug.Log (playerItems.Count + "items in inventory. added : " + itemSlug);*/
		Item item = ItemDatabase.Instance.GetItem (itemSlug);
		playerItems.Add(item);
		Debug.Log (playerItems.Count + "items in inventory . added: " + itemSlug);
		UIEventHandler.ItemAddedToInventory (item);
	}

	public void SetItemDetails(Item item, Button selectedButton)
	{
		inventoryDetailsPanel.SetItem (item, selectedButton);
	}

	public void EquipItem(Item itemToEquip)
	{
		playerWeaponController.EquipWeapon (itemToEquip);
	}
	public void ConsumeItem(Item itemToConsume)
	{
		consumableController.ConsumeItem (itemToConsume);
	}

	/*void Update()
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			playerWeaponController.EquipWeapon (sword);
			consumableController.ConsumeItem (PotionLog);
		}

	}*/
}
