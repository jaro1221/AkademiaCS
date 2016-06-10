namespace Hurtownia.Classes
{
    public class Product
    {
        

        public enum Unit
        {
            kg,
            szt
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Ean { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }

        public float Cost
        {
            get { return Price*Quantity; }
            set { }
        }

        public Unit EnumUnit { get; set; }

        public Product()
        {
        }

        public Product(string name, string code, string ean, float price, float quantity, Unit enumUnit)
        {
            Name = name;
            Code = code;
            Ean = ean;
            Price = price;
            Quantity = quantity;
            Cost = price * quantity;
            EnumUnit = enumUnit;
        }

        
    }
}