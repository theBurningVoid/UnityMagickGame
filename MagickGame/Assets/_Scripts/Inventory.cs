using UnityEngine;
using System.Collections;

//the current basic rules for the inventory system
//a. each item takes up only one slot
//b. items of the same type do not stack (at least for now, we can decide to change this later)
//rules updated: 11/5/2016 -Jonathan Rueckert






//A class for storing all the basic info about an item needed for the inventory system
//note: all items are made to be contained in inventory slots at all times
public class InventoryItem
{
	//TODO figure out what info this class needs to store and thus make the class


}


//A class made to represent a single inventory slot
//each slot can contain only 1 item at a time and a single item does not need multiple slots to contain it...
//CURRENTLY ^
public class InventorySlot
{
	//the item this inventory slot currently contains, null if the slot is empty
	public InventoryItem item{ get; private set; }//can be publicly read but only private write 



	//a method for setting the item field to the "newItem"
	//this is a hard set meaning it does not care if the "item" field is already occupied
	//use with caution as it can effectively delete items
	//do also note that it takes an item parameter whilst most other methods in this class take an inventoryslot as the parameter
	public void HardSetItem(InventoryItem newItem)
	{
		item = newItem;
	}




	//a method used to attempt to transfer this inventory slot's item to the "destination" inventory slot
	//if the "destination" cannot accept the item (e.x. the "destination" already has an item)
	//then the return value will be false and the transfer will not occur
	//but if the transfer was a success then true will be returned
	public bool AttemptTransferTo(InventorySlot destination)
	{
		if (destination.CanAcceptItem ()) {
			destination.item = this.item;
			this.item = null;
			return true;
		}
		return false;
	}


	//a method used to determine if this inventory slot can accept an inventory item
	//currently based souly on whether or not this slot's item field is null
	public bool CanAcceptItem()
	{
		return item == null;
	}
}