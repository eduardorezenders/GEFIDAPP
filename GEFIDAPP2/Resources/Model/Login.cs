using SQLite;
using System;

namespace GEFIDAPP2.Resources.Model
{
    public class Login
    {
        [PrimaryKey, MaxLength(11)]
        public string Cpf { get; set; }
        [MaxLength(6)]
        public string IdCliente { get; set; }
        [MaxLength(15)]
        public string Senha { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(50)]
        public string Sobrenome { get; set; }
        [MaxLength(1)]
        public string Genero { get; set; }
        [MaxLength(2)]
        public string Ddd { get; set; }
        [MaxLength(9)]
        public string Fone { get; set; }
        public string Email { get; set; }
        public DateTime DTCadastro { get; set; }
        public bool Conectado { get; set; }
    }
}