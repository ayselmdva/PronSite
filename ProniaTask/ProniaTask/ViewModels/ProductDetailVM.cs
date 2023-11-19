namespace ProniaTask.ViewModels
{
    public class ProductDetailVM
    {

        public Product CurrentProduct { get; set; }
        public List<Product> RelatedProducts { get; set; } = null!;
    }
}
