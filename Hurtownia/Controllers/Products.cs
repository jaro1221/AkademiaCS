using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Hurtownia.Classes;

namespace Hurtownia.Controllers
{
    public class Products
    {
        public static ObservableCollection<Product> ProductsList { get; set; } = new ObservableCollection<Product>();
        public static int NumberOfProducts { get; set; }
        public static string FilePath { get; set; } = Environment.CurrentDirectory + "..\\Files\\products.xml";

        public static ObservableCollection<string> GetProductsListAsString()
        {
            ObservableCollection<string> StringsList = new ObservableCollection<string>();
            foreach (var product in ProductsList)
            {
                StringsList.Add(product.Name);
            }
            return StringsList;
        }

        private static void SetNumberOfProducts()
        {
            NumberOfProducts = ProductsList.Count;
        }

        internal static void AddProduct(string name, float quantity)
        {
            foreach (var product in ProductsList)
            {
                if (product.Name == name)
                {
                    product.Quantity = product.Quantity + quantity;
                }
            }
            SaveProducts();
        }

        public static void AddProduct(Product newProduct)
        {
            ProductsList.Add(newProduct);
            SaveProducts();
            SetNumberOfProducts();

        }

        public static void DeleteProduct(int index)
        {
            ProductsList.RemoveAt(index);
            SaveProducts();
            SetNumberOfProducts();
        }

        private static bool SaveProducts()
        {
            try
            {
                using (var sw = new StreamWriter(FilePath))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Product>));
                    serializer.Serialize(sw, ProductsList);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool LoadProducts()
        {
            try
            {
                ProductsList.Clear();
                using (var sr = new StreamReader(FilePath))
                {
                    var deSerializer = new XmlSerializer(typeof(ObservableCollection<Product>));
                    var tmpCollection =
                        (ObservableCollection<Product>)deSerializer.Deserialize(sr);
                    foreach (var item in tmpCollection)
                    {
                        ProductsList.Add(item);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    var sw = new StreamWriter(FilePath);
                }
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static ObservableCollection<Product> SearchProduct(string query)

        {
            ObservableCollection<Product> foundProducts = new ObservableCollection<Product>();

            foreach (var product in ProductsList)
            {
                string name = product.Name.ToLower();
                string code = product.Code.ToLower();
                string ean = product.Ean;

                if (name.Contains(query) || code.Contains(query) || ean.Contains(query))
                {
                    foundProducts.Add(product);
                }

            }

            return foundProducts;

        }


        public static Product GetProduct(int index)
        {
            Product product = ProductsList[index];
            return product;
        }

        public static void EditProduct(Product editedProduct, int index)
        {
            ProductsList.RemoveAt(index);
            ProductsList.Insert(index, editedProduct);
            SaveProducts();
        }

        public static void EditProduct(int index, Product product)
        {
            foreach (var product1 in ProductsList)
            {
                if (product1.Name == product.Name)
                {
                    product1.Quantity = product1.Quantity + product.Quantity;
                }
            }
            SaveProducts();

        }

        public static Product GetProduct(string name)
        {
            foreach (var product in ProductsList)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
