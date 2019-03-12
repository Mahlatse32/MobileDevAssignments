using AirBnB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.App.Usage.UsageEvents;

namespace AirBnB
{
    public partial class MainPage : ContentPage
    {
        public List<Search> RecentSearch;
        
        public MainPage()
        {
            InitializeComponent();

            listView.ItemsSource = GetAddress();
            
        }

        List<Search> GetAddress(string SearchText = null)
        {
            
            var address = new List<Search>
            {
                new Search{ Id = 1, Location = "Tzaneen, Limpopo, South Africa", Check = string.Format("{0} - {1}",new DateTime(2017,04,11).ToShortDateString(), new DateTime(2017,06,15).ToShortDateString())},
                new Search{ Id = 2, Location = "Witbank, Mpumalanga, South Africa", Check = string.Format("{0} - {1}",new DateTime(2018,05,18).ToShortDateString(), new DateTime(2018,07,01).ToShortDateString())},
                new Search{ Id = 3, Location = "Johannesburg, Gauteng, South Africa", Check = string.Format("{0} - {1}",new DateTime(2019,03,19).ToShortDateString(), new DateTime(2019,06,17).ToShortDateString())}

            };
            
            if (string.IsNullOrEmpty(SearchText))
                return address;
            else
            {
                RecentSearch = address.Where(x => x.Location.ToUpper().StartsWith(SearchText.ToUpper())).ToList();
                return address.Where(x => x.Location.ToUpper().StartsWith(SearchText.ToUpper())).ToList();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetAddress(e.NewTextValue);
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            GetAddress();

            listView.EndRefresh();
        }

        private void RecentSearchButton_Clicked(object sender, EventArgs e)
        {
            listView.ItemsSource = RecentSearch;
        }
    }
}
