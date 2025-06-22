using System;

namespace ECommerceSearch
{
    public class SearchEngine
    {
        public static Product? LinearSearch(Product[] products, string name)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return product;
            }
            return null;
        }

        public static Product? BinarySearch(Product[] sortedProducts, string name)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(name, sortedProducts[mid].ProductName, true);
                if (comparison == 0)
                    return sortedProducts[mid];
                else if (comparison < 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return null;
        }
    }
}
