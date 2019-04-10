using Android.App;
using Android.OS;
using Android.Widget;
using System;
using GEFIDAPP2.Resources.Model;
using GEFIDAPP2.Resources.DataBaseHelper;
using Android.Support.V7.App;
using System.Collections.Generic;

namespace GEFIDAPP2
{
    [Activity(Label = "GEFIDAPP - Login", Theme = "@style/AppTheme")]
    public class LoginActivity : AppCompatActivity
    {
        private EditText txtCPF;
        private EditText txtSenha;
        private Button btnCriar;
        private Button btnLogin;
        private CheckBox chkLembrar;
        private readonly List<Login> usuario = new List<Login>();
        private DataBase db = new DataBase();
        Android.Content.ISharedPreferences localPreferencias = Application.Context.GetSharedPreferences("Preferencias", Android.Content.FileCreationMode.Private);
        private Validacoes valida = new Validacoes();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_Login);

            btnCriar = FindViewById<Button>(Resource.Id.btnCriar);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            chkLembrar = FindViewById<CheckBox>(Resource.Id.chkManter);
            txtCPF = FindViewById<EditText>(Resource.Id.txtCPF);
            txtSenha = FindViewById<EditText>(Resource.Id.txtSenha);

            var root = FindViewById<LinearLayout>(Resource.Id.LoginLayout);
            root.RequestFocus();

            btnLogin.Click += BtnLogin_Click;
            btnCriar.Click += BtnCriar_Click;

            txtCPF.Text = localPreferencias.GetString("C", null);
            txtSenha.Text = localPreferencias.GetString("S", null);
            chkLembrar.Checked = localPreferencias.GetBoolean("L", false);
            if (chkLembrar.Checked) { btnCriar.Enabled = false; }
        }

        private void BtnCriar_Click(object sender, EventArgs e)
        {
            bool ping = valida.TesteConexao();
            if (ping)
            {
                StartActivity(typeof(RegistrarActivity));
            } else
            {
                Toast.MakeText(this, "Sem Conexão com a internet. Tente mais tarde!!", ToastLength.Short).Show();
            }
            
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Validacoes valida = new Validacoes();
            if (valida.IsCPF(txtCPF.Text) == false)
            {
                Toast.MakeText(this, "CPF Inválido, Verifique os dados informados!!", ToastLength.Short).Show();
                txtCPF.RequestFocus();
                return;
            }

            if (string.IsNullOrEmpty(txtCPF.Text))
            {
                Toast.MakeText(this, "CPF obrigatório!!", ToastLength.Short).Show();
                txtCPF.RequestFocus();
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                Toast.MakeText(this, "Senha obrigatória!!", ToastLength.Short).Show();
                txtSenha.RequestFocus();
                return;
            }

            Login usuario = new Login()
            {
                Cpf = txtCPF.Text,
                Senha = txtSenha.Text
            };
            bool txtOK = db.GetUsuario(usuario);
            if (txtOK == true)
            {
                SetPreferencias();
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Conta não encontrada, veirifique os dados informados!!", ToastLength.Short).Show();
                txtCPF.RequestFocus();
            }
        }

        private void SetPreferencias()
        {
            Android.Content.ISharedPreferencesEditor usuarioEdit = localPreferencias.Edit();
            if (chkLembrar.Checked == true)
            {
                usuarioEdit.PutString("C", txtCPF.Text);
                usuarioEdit.PutString("S", txtSenha.Text);
                usuarioEdit.PutBoolean("L", true);
                usuarioEdit.Commit();
            }
            else
            {
                usuarioEdit.PutString("C", null);
                usuarioEdit.PutString("S", null);
                usuarioEdit.PutBoolean("L", false);
                usuarioEdit.Commit();
            }
        }
    }
}
