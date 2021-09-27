namespace Module6Assingment
{
    public class Item
    {
        private string _itemName;
        private int _itemQuantity;
        private double _pricePerUnit;


        public Item(string itemName, int itemQuantity, double pricePerUnit)
        {
            _itemName = itemName;
            _itemQuantity = itemQuantity;
            _pricePerUnit = pricePerUnit;
        }

        public void SetItemName(string name)
        {
            name = _itemName;
        }

        public string GetItemName()
        {
            return _itemName;
        }

        public void SetItemQuantity(int quantity)
        {
            int q = _itemQuantity;
            _itemQuantity = q - quantity;
        }

        public int GetItemQuantity()
        {
            return _itemQuantity;
        }

        public void SetPrice(double price)
        {
            price = _pricePerUnit;
        }

        public double GetPrice()
        {
            return _pricePerUnit;
        }
    }
}
