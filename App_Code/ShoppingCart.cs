using System.Collections.Generic;
using System.Web;

/**
 * The ShoppingCart class
 * 
 * Holds the items that are in the cart and provides methods for their manipulation
 */
public class ShoppingCart {

	
	public List<CartItem> Items { get; private set; }




	// Readonly properties can only be set in initialization or in a constructor
	public static readonly ShoppingCart Instance;
	// The static constructor is called as soon as the class is loaded into memory
	static ShoppingCart() {
		// If the cart is not in the session, create one and put it there
		// Otherwise, get it from the session
		if (HttpContext.Current.Session["ASPNETShoppingCart"] == null) {
			Instance = new ShoppingCart();
			Instance.Items = new List<CartItem>();
			HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;
		} else {
			Instance = (ShoppingCart)HttpContext.Current.Session["ASPNETShoppingCart"];
		}
	}

	// A protected constructor ensures that an object can't be created from outside
	protected ShoppingCart() { }




	/**
	 * AddItem() - Adds an item to the shopping 
	 */
	public void AddItem(int productId,int quantity,string ImageUrl) {
		// Create a new item to add to the cart
		CartItem newItem = new CartItem(productId,quantity,ImageUrl);

		// If this item already exists in our list of items, increase the quantity
		// Otherwise, add the new item to the list
		if (Items.Contains(newItem)) {
			foreach (CartItem item in Items) {
				if (item.Equals(newItem)) {
                    item.Quantity=item.Quantity+quantity;
					return;
				}
			}
		} else {
			newItem.Quantity = quantity;
			Items.Add(newItem);
		}
	}

	/**
	 * SetItemQuantity() - Changes the quantity of an item in the cart
	 */
	public void SetItemQuantity(int productId,string ImageUrl, int quantity) {
		// If we are setting the quantity to 0, remove the item entirely
		if (quantity == 0) {
			RemoveItem(productId,ImageUrl);
			return;
		}

		// Find the item and update the quantity
        CartItem updatedItem = new CartItem(productId, quantity, ImageUrl);

		foreach (CartItem item in Items) {
			if (item.Equals(updatedItem)) {
				item.Quantity = quantity;
				return;
			}
		}
	}

	/**
	 * RemoveItem() - Removes an item from the shopping cart
	 */
	public void RemoveItem(int productId,string ImageUrl) {
        CartItem removedItem = new CartItem(productId, ImageUrl);
		Items.Remove(removedItem);
	}



	/**
	 * GetSubTotal() - returns the total price of all of the items
	 *                 before tax, shipping, etc.
	 */
	public decimal GetSubTotal() {
		decimal subTotal = 0;
		foreach (CartItem item in Items)
			subTotal += item.TotalPrice;

		return subTotal;
	}

}
