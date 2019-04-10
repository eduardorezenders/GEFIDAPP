using System.Threading;
using Android.App;
using Android.OS;
using Android.Widget;
using GEFIDAPP2.Resources.DataBaseHelper;

namespace GEFIDAPP2
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        private DataBase db = new DataBase();
        private readonly Validacoes valida = new Validacoes();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
                CriarBancoDados();
        }

        private void CriarBancoDados()
        {
            bool txtOK = db.CriarBancoDeDados();
            if (txtOK == true)
            {
                Toast.MakeText(this, "Dados carregados com sucesso!!", ToastLength.Short).Show();
                Thread.Sleep(3000);
                StartActivity(typeof(LoginActivity)); 
            }
            else
            {
                Toast.MakeText(this, "*** ERRO *** No carregamento dos dados!!", ToastLength.Short).Show();
                Finish();
            }
        }
    }
}
