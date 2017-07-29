using GuessPlayer.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessPlayer
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<GuessPlayerModel> playerTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://guessplayer.azurewebsites.net");
            this.playerTable = this.client.GetTable<GuessPlayerModel>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<List<GuessPlayerModel>> GetPlayerInformation()
        {
            return await this.playerTable.ToListAsync();
        }
    }
}