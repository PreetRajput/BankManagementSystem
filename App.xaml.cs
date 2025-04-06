using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.Configuration;
using System.Data;
using System.Windows;
using System.IO;

namespace first
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string jsonPath = @"D:\projects\first\Assets\firebase_config.json";

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(jsonPath)
            });

        }
    }

}
