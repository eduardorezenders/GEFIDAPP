using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GEFIDAPP2.Resources.DataBaseHelper;
using GEFIDAPP2.Resources.Model;
using Uri = Android.Net.Uri;

namespace GEFIDAPP2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private ListView lvDados;
        private List<Solicitacao> solicitacoesListView = new List<Solicitacao>();
        private DataBase db = new DataBase();
        private readonly string numeroSMS = "21966138677";
        private readonly string msgSMS = "Escreva aqui sua mensagem!";
        private readonly string whatsapp = "com.whatsapp";
        private ArrayList items = new ArrayList();
        private readonly string[] servicos = new Conteudo().Servicos();
        private readonly string[] prioridades = new Conteudo().Prioridades();
        private readonly string[] assuntos = new Conteudo().Assuntos();
        private readonly string[] status = new Conteudo().StatusResposta();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            lvDados = FindViewById<ListView>(Resource.Id.lvDados);
            lvDados.FastScrollEnabled = true;
            solicitacoesListView.RemoveRange(0, solicitacoesListView.Count);
            solicitacoesListView = db.GetSolicitacao();
            var adapter = new SolicitacaoAdapter(this, solicitacoesListView);
            lvDados.Adapter = adapter;
            lvDados.ItemClick += LvDados_ItemClick;
        }

        private void LvDados_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            for (int i = 0; i < lvDados.Count; i++)
            {
                if (e.Position == i)
                {
                    lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Chocolate);
                }
                else
                {
                     lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }

            items.Add(solicitacoesListView[e.Position].Conteudo);
            items.Add(solicitacoesListView[e.Position].Local);
            items.Add(solicitacoesListView[e.Position].DtRegistro);
            items.Add(solicitacoesListView[e.Position].IdServico);
            items.Add(solicitacoesListView[e.Position].IdTipoAssunto);
            items.Add(solicitacoesListView[e.Position].IdTipoPrioridade);
            items.Add(solicitacoesListView[e.Position].IdStatusOuvidoria);

            View view = LayoutInflater.Inflate(Resource.Layout.PopupWindow, null);
            Android.App.AlertDialog builder = new Android.App.AlertDialog.Builder(this).Create();

            TextView txtconteudo = view.FindViewById<TextView>(Resource.Id.txtConteudo);
            TextView txtlocal = view.FindViewById<TextView>(Resource.Id.txtLocal);
            TextView txtservico = view.FindViewById<TextView>(Resource.Id.txtServico);
            TextView txtassunto = view.FindViewById<TextView>(Resource.Id.txtAssunto);
            TextView txtprioridade = view.FindViewById<TextView>(Resource.Id.txtPrioridade);
            TextView txtdataservico = view.FindViewById<TextView>(Resource.Id.txtDataRegistro);
            TextView txtstatus = view.FindViewById<TextView>(Resource.Id.txtStatus);
            txtconteudo.Text = solicitacoesListView[e.Position].Conteudo;
            txtlocal.Text = solicitacoesListView[e.Position].Local;
            txtservico.Text = servicos[solicitacoesListView[e.Position].IdServico];
            txtassunto.Text = assuntos[solicitacoesListView[e.Position].IdTipoAssunto];
            txtprioridade.Text = prioridades[solicitacoesListView[e.Position].IdTipoPrioridade];
            txtstatus.Text = status[solicitacoesListView[e.Position].IdStatusOuvidoria];
            txtdataservico.Text = solicitacoesListView[e.Position].DtRegistro.ToString();

            builder.SetView(view);
            builder.SetCanceledOnTouchOutside(true);
            Button button = view.FindViewById<Button>(Resource.Id.btnSair);
            button.Click += delegate {
                builder.Dismiss();
            };
            builder.Show();
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                //case Resource.Id.action_conta:
                //    {
                //        // add your code  
                //        return true;
                //    }
                //case Resource.Id.action_sobre:
                //    {
                //        // add your code  
                //        return true;
                //    }
                case Resource.Id.action_sair:
                    {
                        StartActivity(typeof(LoginActivity));
                        return true;
                    }
            }
            return base.OnOptionsItemSelected(item);
        }

        bool VerificarApp(String uri)
        {
            try
            {
                ApplicationContext.PackageManager.GetPackageInfo(uri, PackageInfoFlags.Activities);
                return true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                PackageManager.NameNotFoundException erro = e;
                return false;
            }
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(SolicitacaoActivity));
            //View view = (View) sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_solicitacao) // Nova Solicitação
            {
                StartActivity(typeof(SolicitacaoActivity));
            }
            //else if (id == Resource.Id.nav_gallery)
            //{

            //}
            else if (id == Resource.Id.nav_slideshow) // Conta
            {

            }
            else if (id == Resource.Id.nav_manage) // Sobre
            {

            }
            else if (id == Resource.Id.nav_share) // Enviar WhatsApp
            {
                Intent share = new Intent(Intent.ActionSend);
                share.SetType("text/plain");
                share.PutExtra(Intent.ExtraSubject, "GEFIDAPP - Gestão de Fidelização");
                share.PutExtra(Intent.ExtraText, "GEFIDAPP - Gestão de Fidelização: http://gefidapp.gefid.com.br");

                StartActivity(Intent.CreateChooser(share, "Compartilhar link!"));

                if (VerificarApp(whatsapp))
                {                  
                    //Android.Net.Uri uri = Android.Net.Uri.Parse("smsto:" + "55" + numeroSMS);
                    //Intent intent = new Intent(Intent.ActionSend, uri);
                    ////Intent.PutExtra("GEFIDAPP", "55" + numeroSMS + "@s.whatsapp.net");
                    //intent.PutExtra(Intent.ExtraText, msgSMS);
                    ////intent.SetAction(Intent.ActionSend(uri));
                    //intent.SetType("text/plain");
                    //intent.SetPackage(whatsapp);
                    //StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "WhatsApp não está instalado. Impossível enviar a mensagem!", ToastLength.Long).Show();
                }
            }
            else if (id == Resource.Id.nav_send) // Enviar SMS
            {
                if (!PackageManager.HasSystemFeature(PackageManager.FeatureTelephony))
                {
                    Toast.MakeText(this, "Este dispositivo não possui recursos para enviar SMS!", ToastLength.Short);
                }
                else
                {
                    Uri sms_u = Uri.Parse("smsto: " + numeroSMS);
                    Intent sms_i = new Intent(Intent.ActionSendto, sms_u);
                    sms_i.PutExtra("sms_body", msgSMS);
                    StartActivity(sms_i);
                }
            }
            else if (id == Resource.Id.nav_call) // Chamada telefonica
            {
                if (!PackageManager.HasSystemFeature(PackageManager.FeatureTelephony))
                {
                    Toast.MakeText(this, "O dispositivo não suporta este recurso!", ToastLength.Short);
                }
                else
                {
                    Uri uri = Uri.Parse("tel:" + numeroSMS);
                    Intent intent = new Intent(Intent.ActionCall, uri);
                    StartActivity(intent);
                }
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}

