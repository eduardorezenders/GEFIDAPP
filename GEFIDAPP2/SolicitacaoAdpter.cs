using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using GEFIDAPP2.Resources.Model;

namespace GEFIDAPP2
{
    public class SolicitacaoAdapter : BaseAdapter<Solicitacao>
    {
        private readonly Activity context;
        private readonly List<Solicitacao> solicitacoes;
        public SolicitacaoAdapter(Activity context, List<Solicitacao> solicitacoes)
        {
            this.context = context;
            this.solicitacoes = solicitacoes;
        }
        public override Solicitacao this[int position] => solicitacoes[position];
        public override int Count => solicitacoes == null ? 0 : solicitacoes.Count; 
        public override long GetItemId(int position)
        {
            return solicitacoes[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.solicitacao_item, parent, false);

            TextView txtTitulo = view.FindViewById<TextView>(Resource.Id.tituloTextView);
            TextView txtDiretor = view.FindViewById<TextView>(Resource.Id.diretorTextView);
            TextView txtLancamento = view.FindViewById<TextView>(Resource.Id.dataLancamentoTextView);
            TextView txtStatus = view.FindViewById<TextView>(Resource.Id.statusTextView);
            TextView txtLocal = view.FindViewById<TextView>(Resource.Id.LocalTextView);
            ImageView _imageView = view.FindViewById<ImageView>(Resource.Id.photoViewer);
            txtTitulo.Text = "Protodolo: " + solicitacoes[position].Protocolo;
            int tamanho = solicitacoes[position].Conteudo.Length;
            tamanho = tamanho / 2;
            txtDiretor.Text = "Conteúdo: " + solicitacoes[position].Conteudo.Substring(0, tamanho) + "...";
            txtLancamento.Text = "Criado em : " + solicitacoes[position].DtRegistro.ToShortDateString();
            txtLocal.Text = "Local: " + solicitacoes[position].Local;
            txtStatus.Text = "Status: " + solicitacoes[position].IdStatusOuvidoria;
            return view;
        }
    }
}