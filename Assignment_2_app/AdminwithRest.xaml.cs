using Assignment_2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for AdminwithRest.xaml
    /// </summary>
    public partial class AdminwithRest : Window
    {
        HttpClient client = new HttpClient();
        public AdminwithRest()
        {
            client.BaseAddress = new Uri("https://localhost:7135/assignment2/");

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")

                );


            InitializeComponent();
        }

        private async void select_btn_Click(object sender, RoutedEventArgs e)
        {
            var server_response = await client.GetStringAsync("GetProductbyId/" + int.Parse(searchId.Text));

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            productName.Text = response_JSON.product.productName;
            productId.Text = response_JSON.product.productId.ToString();
            amount.Text = response_JSON.product.amount.ToString();
            price.Text = response_JSON.product.price.ToString();
            
        }

        private async void showAll_Click(object sender, RoutedEventArgs e)
        {
            var server_response = await client.GetStringAsync("GetAllProducts");

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            resultsGrid.ItemsSource = response_JSON.products;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sales salesWindow = new Sales();
            salesWindow.Show();
        }
    }
}
