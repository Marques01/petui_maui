namespace Models
{
    public class Product
    {
        private int
            _productId = default;

        private string
            _name = string.Empty,
            _imagePath = string.Empty;

        private decimal
            _price = default;

        public int ProductId { get => _productId; set => _productId = value; }

        public string Name { get => _name; set => _name = value; }

        public string ImagePath { get => _imagePath; set => _imagePath = value; }

        public decimal Price { get => _price; set => _price = value; }

        public MultipartFormDataContent Content { get; set; }

        public Product()
        {
            Content = new();
        }
    }
}
