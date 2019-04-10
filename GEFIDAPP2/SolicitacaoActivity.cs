using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using GEFIDAPP2.Resources.DataBaseHelper;
using GEFIDAPP2.Resources.Model;
using System;
using System.IO;

namespace GEFIDAPP2
{
    [Activity(Theme = "@style/AppTheme",  Label = "GEFIDAPP - Solicitação")]
    class SolicitacaoActivity : AppCompatActivity
    {
        private EditText txtConteudo;
        private EditText txtLocal;
        private EditText txtCEP;
        private Button btnEnviarSolicitacao;
        private ImageButton btnPhotoButton;
        private ImageButton btnTirarPhotoButton;
        private ImageButton btnVideoButton;
        private ImageButton btnCEPButton;
        private Spinner spinnerPrioridade;
        private Spinner spinnerAssunto;
        private Spinner spinnerServico;
        private DataBase db = new DataBase();
        public static readonly int PickImageId = 1000;
        private ImageView _imageView;
        //private readonly VideoView _videoView;
        public string caminhoDaImagem;
        private Validacoes valida = new Validacoes();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_Solicitacao);

            txtConteudo = FindViewById<EditText>(Resource.Id.txtConteudo);
            txtLocal = FindViewById<EditText>(Resource.Id.txtLocal);
            txtCEP = FindViewById<EditText>(Resource.Id.txtCEP);
            btnEnviarSolicitacao = FindViewById<Button>(Resource.Id.btnEnviarSolicitacao);

            LinearLayout root = FindViewById<LinearLayout>(Resource.Id.SolicitacaoLayout);
            root.RequestFocus();
            Conteudo conteudo = new Conteudo();

            spinnerServico = FindViewById<Spinner>(Resource.Id.spnServico);
            ArrayAdapter<String> spinnerArrayAdapterServico = new ArrayAdapter<String>(this, Resource.Layout.spinner_item, conteudo.Servicos());
            spinnerArrayAdapterServico.SetDropDownViewResource(Resource.Layout.spinner_item);
            spinnerServico.Adapter = spinnerArrayAdapterServico;
            spinnerServico.ItemSelected += SpinnerServico_ItemSelected;

            spinnerAssunto = FindViewById<Spinner>(Resource.Id.spnAssunto);
            ArrayAdapter<String> spinnerArrayAdapterAssunto = new ArrayAdapter<String>(this, Resource.Layout.spinner_item, conteudo.Assuntos());
            spinnerArrayAdapterAssunto.SetDropDownViewResource(Resource.Layout.spinner_item);
            spinnerAssunto.Adapter = spinnerArrayAdapterAssunto;
            spinnerAssunto.ItemSelected += SpinnerAssunto_ItemSelected;

            spinnerPrioridade = FindViewById<Spinner>(Resource.Id.spnPrioridade);
            ArrayAdapter<String> spinnerArrayAdapter = new ArrayAdapter<String>(this, Resource.Layout.spinner_item, conteudo.Prioridades());
            spinnerArrayAdapter.SetDropDownViewResource(Resource.Layout.spinner_item);
            spinnerPrioridade.Adapter = spinnerArrayAdapter;
            spinnerPrioridade.ItemSelected += SpinnerPrioridade_ItemSelected;

            _imageView = FindViewById<ImageView>(Resource.Id.photoViewer);

            btnCEPButton = FindViewById<ImageButton>(Resource.Id.btnCEP);
            btnCEPButton.Click += BtnCEPButton_ClickAsync;

            btnPhotoButton = FindViewById<ImageButton>(Resource.Id.photoButton);
            btnPhotoButton.Click += BtnPhotoButton_Click;

            btnTirarPhotoButton = FindViewById<ImageButton>(Resource.Id.tirarPhotoButton);
            btnTirarPhotoButton.Click += BtnTirarPhotoButton_Click;

            btnVideoButton = FindViewById<ImageButton>(Resource.Id.videoButton);
            btnVideoButton.Click += BtnVideoButton_Click;

            btnEnviarSolicitacao.Click += BtnEnviarSolicitacao_Click; 
        }

        private void BtnCEPButton_ClickAsync(object sender, EventArgs e)
        {
            bool ping = valida.TesteConexao();
            if (!ping)
            {
                Toast.MakeText(this, "Sem Conexão com a internet. Tente mais tarde!!", ToastLength.Short).Show();
                txtCEP.RequestFocus();
                return;
            }

            if (string.IsNullOrEmpty(txtCEP.Text))
            {
                Toast.MakeText(this, "Digite um CEP para pesquisar!!", ToastLength.Short).Show();
                txtCEP.RequestFocus();
                return;
            }
            else
            {
                using (br.com.correios.apps.AtendeClienteService ws = new br.com.correios.apps.AtendeClienteService()) {
                    try
                    {
                        br.com.correios.apps.enderecoERP dados = ws.consultaCEP(txtCEP.Text);
                        txtLocal.Text = dados.end + ", " + dados.bairro + ", " + dados.cidade + ", " + dados.uf;
                    }
                    catch
                    {
                        txtLocal.Text = "";
                        Toast.MakeText(this, "CEP não encontrado. Por favor verifique!!", ToastLength.Short).Show();
                    }                    
                }
            }
        }

        private void BtnVideoButton_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("video/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Selecione um vídeo."), PickImageId);
        }

        private void BtnTirarPhotoButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }

        private void BtnPhotoButton_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Selecione uma imagem."), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;

                FileInfo arq = new FileInfo(uri.Path); 
                if (arq.Length>300) {
                    Toast.MakeText(this, "Tamanho MÁXIMO da imagem deve ser de 300Kbyte!!", ToastLength.Short).Show();
                    return;
                }

                _imageView.SetImageURI(uri);
                caminhoDaImagem = uri.Path;
            }
            else
            {
                base.OnActivityResult(requestCode, resultCode, data);
                Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                _imageView.SetImageBitmap(bitmap);
            }
        }

        private void SpinnerServico_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinnerServico = (Spinner)sender;
            string toastServico = spinnerServico.GetItemAtPosition(e.Position).ToString();
        }

        private void SpinnerAssunto_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinnerAssunto = (Spinner)sender;
            string toastAssunto = spinnerAssunto.GetItemAtPosition(e.Position).ToString();
        }

        public void SpinnerPrioridade_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinnerPrioridade = (Spinner)sender;
            string toastPrioridade = spinnerPrioridade.GetItemAtPosition(e.Position).ToString();
        }

        private void BtnEnviarSolicitacao_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtConteudo.Text))
                {
                    Toast.MakeText(this, "Digite o conteúdo da solicitação!!", ToastLength.Short).Show();
                    txtConteudo.RequestFocus();
                    return;
                }

                int posicao = spinnerServico.SelectedItemPosition;
                string servico = spinnerServico.GetItemAtPosition(posicao).ToString();
                int idservico = Int32.Parse(servico.Substring(1, 3));
                if (idservico == 0)
                {
                    Toast.MakeText(this, "Selecione um serviço!!", ToastLength.Short).Show();
                    spinnerServico.RequestFocus();
                    return;
                }

                int a = spinnerAssunto.SelectedItemPosition;
                switch (a)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        break;
                    default:
                        Toast.MakeText(this, "Selecione um assunto!!", ToastLength.Short).Show();
                        spinnerAssunto.RequestFocus();
                        return;
                }

                int p = spinnerPrioridade.SelectedItemPosition;
                switch (p)
                {
                    case 1:
                    case 2:
                    case 3:
                        break;
                    default:
                        Toast.MakeText(this, "Selecione uma prioridade!!", ToastLength.Short).Show();
                        spinnerPrioridade.RequestFocus();
                        return;
                }

                Random randNum = new Random(6);
                long numero = randNum.Next();
                String protocolo = "S" + "82392" + numero.ToString() + DateTime.Now.Year.ToString();

                Validacoes valida = new Validacoes();
                bool ping = valida.TesteConexao();
                if (!ping)
                {
                    Toast.MakeText(this, "Sem Conexão. Trabalhando localmente", ToastLength.Short).Show();
                }

                Solicitacao solicitacao = new Solicitacao()
                {
                    Protocolo = protocolo,
                    Conteudo = txtConteudo.Text,
                    IdCliente = "000001",
                    IdServico = idservico,
                    IdPessoa = 1,
                    IdStatusOuvidoria = 1,
                    IdTipoAssunto = a,
                    IdTipoPrioridade = p,
                    DtRegistro = DateTime.Now,
                    Local = txtLocal.Text,
                    Foto = null
                };
                bool txtOK = db.InserirSolicitacao(solicitacao);

                if (txtOK == true)
                {
                    Toast.MakeText(this, "Solicitação enviada com sucesso!!", ToastLength.Short).Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Solicitação não pode ser enviada!!", ToastLength.Short).Show();
                }

            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

    }
}
