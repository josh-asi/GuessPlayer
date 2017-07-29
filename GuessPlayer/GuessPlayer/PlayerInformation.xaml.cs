using GuessPlayer.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessPlayer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerInformation : ContentPage
    {

        MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;

        public PlayerInformation()
        {
            InitializeComponent();
        }

        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            List<GuessPlayerModel> playerInformation = await AzureManager.AzureManagerInstance.GetPlayerInformation();

            PlayerList.ItemsSource = playerInformation;
        }

        async Task UpdateAgeAsync()
        {
            List<GuessPlayerModel> playerInformation = await AzureManager.AzureManagerInstance.GetPlayerInformation();

            foreach (var p in playerInformation)
            {
                if (p.Name == targetPlayer.Text)
                {
                    p.Age = newAge.Text;

                    await AzureManager.AzureManagerInstance.UpdateAge(p);
                }
            }

        }

        

    }
}