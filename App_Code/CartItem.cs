using System;


public class CartItem : IEquatable<CartItem> {


	// A place to store the quantity in the cart
	// This property has an implicit getter and setter.
	public int Quantity { get; set; }

	private int _productId;
	public int ProductId {
		get { return _productId; }
		set {
			// To ensure that the Prod object will be re-created
			_product = null;
			_productId = value;
		}
	}

	private Product _product = null;
	public Product Prod {
		get {
			// Lazy initialization - the object won't be created until it is needed
			if (_product == null) {
                _product = Product.GetProductBYID(ProductId);
			}
			return _product;
		}
	}

	public string Name {
		get { return Prod.ProductName; }
	}

	public decimal UnitPrice {
        get
        {
            return Prod.Actualprice;
; }
	}

	public decimal TotalPrice {
		get { return UnitPrice * Quantity; }
	}
    public string imageUrl
    {
        get;
        set;
    }


	// CartItem constructor just needs a productId
    public CartItem(int productId, int quantity, string ImageUrl)
    {
		this.ProductId = productId;
        this.imageUrl = ImageUrl;
        this.Quantity = quantity;
	}
    public CartItem(int productId, string ImageUrl)
    {
        this.ProductId = productId;
        this.imageUrl = ImageUrl;
     
    }
	/**
	 * Equals() - Needed to implement the IEquatable interface
	 *    Tests whether or not this item is equal to the parameter
	 *    This method is called by the Contains() method in the List class
	 *    We used this Contains() method in the ShoppingCart AddItem() method
	 */
	public bool Equals(CartItem item) {
		return (item.ProductId == this.ProductId);
	}
}
