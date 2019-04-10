using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Telephony;
using Android.Widget;
using GEFIDAPP2.Resources.DataBaseHelper;
using GEFIDAPP2.Resources.Model;
using System;
using System.Text.RegularExpressions;

namespace GEFIDAPP2
{
    [Activity(Theme = "@style/AppTheme", Label = "GEFIDAPP - Nova Conta")]
    class RegistrarActivity : AppCompatActivity
    {
        EditText txtCPFUsuario;
        EditText txtNomeUsuario;
        EditText txtSenhaUsuario;
        EditText txtSobreNomeUsuario;
        EditText txtEmailUsuario;
        EditText txtCelularUsuario;
        Button btnCriarNovoUsuario;
        Spinner spinnerGenero;
        DataBase db = new DataBase();
        String numero;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_Registrar);

            btnCriarNovoUsuario = FindViewById<Button>(Resource.Id.btnCriarNovoUsuario); 
            txtCPFUsuario = FindViewById<EditText>(Resource.Id.txtCPFUsuario);
            txtNomeUsuario = FindViewById<EditText>(Resource.Id.txtNomeUsuario);
            txtSobreNomeUsuario = FindViewById<EditText>(Resource.Id.txtSobreNomeUsuario);
            txtCelularUsuario = FindViewById<EditText>(Resource.Id.txtCelularUsuario);
            txtSenhaUsuario = FindViewById<EditText>(Resource.Id.txtSenhaUsuario);
            txtEmailUsuario = FindViewById<EditText>(Resource.Id.txtEmailUsuario);

            LinearLayout root = FindViewById<LinearLayout>(Resource.Id.RegistrarLayout);
            root.RequestFocus();

            TelephonyManager mTelephonyMgr;
            mTelephonyMgr = (TelephonyManager)this.GetSystemService(TelephonyService);
            numero = string.IsNullOrEmpty(mTelephonyMgr.Line1Number) ? null : mTelephonyMgr.Line1Number.ToString();
            txtCelularUsuario.Text = numero;

            Conteudo conteudo = new Conteudo();

            spinnerGenero = FindViewById<Spinner>(Resource.Id.spnGeneroUsuario);
            ArrayAdapter<String> spinnerArrayAdapterGenero = new ArrayAdapter<String>(this, Resource.Layout.spinner_item, conteudo.Genero());
            spinnerArrayAdapterGenero.SetDropDownViewResource(Resource.Layout.spinner_item);
            spinnerGenero.Adapter = spinnerArrayAdapterGenero;
            spinnerGenero.ItemSelected += SpinnerGenero_ItemSelected;

            btnCriarNovoUsuario.Click += BtnCriarNovoUsuario_Click;
        }

        public void SpinnerGenero_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = spinner.GetItemAtPosition(e.Position).ToString();
        }

        private void BtnCriarNovoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCPFUsuario.Text=="" || txtCPFUsuario.Length()<11) {
                    Toast.MakeText(this, "CPF Inválido, verifique!!", ToastLength.Short).Show();
                    txtCPFUsuario.RequestFocus();
                    return;
                }
                Validacoes valida = new Validacoes();
                if (valida.IsCPF(txtCPFUsuario.Text) == false)
                {
                    Toast.MakeText(this, "CPF Inválido, Verifique os dados informados!!", ToastLength.Short).Show();
                    txtCPFUsuario.RequestFocus();
                    return;
                }
                if (txtNomeUsuario.Text=="") {
                    Toast.MakeText(this, "Nome deve ser preenchido!!", ToastLength.Short).Show();
                    txtNomeUsuario.RequestFocus();
                    return;
                }
                if (txtSobreNomeUsuario.Text == "")
                {
                    Toast.MakeText(this, "SobreNome deve ser preenchido!!", ToastLength.Short).Show();
                    txtSobreNomeUsuario.RequestFocus();
                    return;
                }
                if (txtCelularUsuario.Text == "")
                {
                    Toast.MakeText(this, "Celular deve ser preenchido!!", ToastLength.Short).Show();
                    txtCelularUsuario.RequestFocus();
                    return;
                }
                if (txtEmailUsuario.Text == "")
                {
                    Toast.MakeText(this, "E-mail deve ser preenchido!!", ToastLength.Short).Show();
                    txtEmailUsuario.RequestFocus();
                    return;
                } else
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(txtEmailUsuario.Text);
                    if (!match.Success)
                    {
                        Toast.MakeText(this, "E-mail deve ser preenchido corretamente!!", ToastLength.Short).Show();
                        txtEmailUsuario.RequestFocus();
                        return;
                    }
                }
                if (txtSenhaUsuario.Text == "")
                {
                    Toast.MakeText(this, "Senha deve ser preenchida!!", ToastLength.Short).Show();
                    txtSenhaUsuario.RequestFocus();
                    return;
                }

                int posicao = spinnerGenero.SelectedItemPosition;
                string g = spinnerGenero.GetItemAtPosition(posicao).ToString();
                switch (g)
                {
                    case "Masculino":
                        g = "M";
                        break;
                    case "Feminino":
                        g = "F";
                        break;
                    case "Outros":
                        g = "O";
                        break;
                    default:
                        Toast.MakeText(this, "Selecione um genêro!!", ToastLength.Short).Show();
                        spinnerGenero.RequestFocus();
                        return;
                }

                Login usuario = new Login()
                {
                    Fone = txtCelularUsuario.Text,
                    IdCliente = "000001",
                    Cpf = txtCPFUsuario.Text,
                    Nome = txtNomeUsuario.Text,
                    Sobrenome = txtSobreNomeUsuario.Text,
                    Senha = txtSenhaUsuario.Text,
                    Email = txtEmailUsuario.Text,
                    DTCadastro = DateTime.Now,
                    Genero = g
                };
                bool txtOK = db.InserirUsuario(usuario);

                if (txtOK==true) {
                    Toast.MakeText(this, "Conta criada com sucesso!!", ToastLength.Short).Show();
                    Finish();
                } else
                {
                    Toast.MakeText(this, "Conta não pode ser criada ou conta já existente!!", ToastLength.Short).Show();
                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}