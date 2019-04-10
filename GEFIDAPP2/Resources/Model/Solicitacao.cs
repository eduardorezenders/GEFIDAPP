using SQLite;
using System;

namespace GEFIDAPP2.Resources.Model
{
    public class Solicitacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Protocolo { get; set; }
        public string Conteudo { get; set; }
        public string IdCliente { get; set; }
        public int IdPessoa { get; set; }
        public int IdServico { get; set; }
        public int IdStatusOuvidoria { get; set; }
        public int IdTipoPrioridade { get; set; }
        public int IdTipoAssunto { get; set; }
        public DateTime DtRegistro { get; set; }
        public string Local { get; set; }
        public byte[] Foto { get; set; }
        public string Cep { get; set; }
    }
}