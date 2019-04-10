using Android.Content;
using Plugin.Connectivity;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GEFIDAPP2
{
    public class Validacoes
    {
        public bool TesteConexao()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (System.IO.Stream stream = client.OpenRead("http://187.102.176.94"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            //Plugin.Connectivity.Abstractions.IConnectivity connectivity = CrossConnectivity.Current;
            //if (!CrossConnectivity.IsSupported)
            //{
            //    if (!connectivity.IsConnected)
            //    {
            //        return connectivity.IsConnected;
            //    }
            //    else
            //    {
            //        bool reachable = connectivity.IsRemoteReachable("http://187.102.176.94");
            //        return reachable;
            //    }
            //}
            //else
            //{
            //    CrossConnectivity.Dispose();
            //    return false;
            //}
        }

        public Task<bool> AlertAsync(Context contexto, string title, string message, string positiveButton, string negativeButton)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            using (Android.App.AlertDialog.Builder adb = new Android.App.AlertDialog.Builder(contexto))
            {
                adb.SetTitle(title);
                adb.SetMessage(message);
                adb.SetPositiveButton(positiveButton, (sender, args) => { tcs.TrySetResult(true); });
                adb.SetNegativeButton(negativeButton, (sender, args) => { tcs.TrySetResult(false); });
                adb.Show();
            }
            return tcs.Task;
        }

        public bool IsCPF(string valor)
        {
            if (valor == "")
                return false;

            string cpf = valor;

            int d1, d2;
            int soma = 0;
            string digitado = "";
            string calculado = "";

            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] n = new int[11];

            // Se o tamanho for < 11 entao retorna como inválido
            if (cpf.Length != 11)
                return false;

            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {
                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(cpf.Substring(0, 1));
                n[1] = Convert.ToInt32(cpf.Substring(1, 1));
                n[2] = Convert.ToInt32(cpf.Substring(2, 1));
                n[3] = Convert.ToInt32(cpf.Substring(3, 1));
                n[4] = Convert.ToInt32(cpf.Substring(4, 1));
                n[5] = Convert.ToInt32(cpf.Substring(5, 1));
                n[6] = Convert.ToInt32(cpf.Substring(6, 1));
                n[7] = Convert.ToInt32(cpf.Substring(7, 1));
                n[8] = Convert.ToInt32(cpf.Substring(8, 1));
                n[9] = Convert.ToInt32(cpf.Substring(9, 1));
                n[10] = Convert.ToInt32(cpf.Substring(10, 1));
            }
            catch
            {
                return false;
            }

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
                soma += (peso1[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0)
                d1 = 0;
            else
                d1 = 11 - resto;

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
                soma += (peso2[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            resto = soma % 11;
            if (resto == 1 || resto == 0)
                d2 = 0;
            else
                d2 = 11 - resto;

            calculado = d1.ToString() + d2.ToString();
            digitado = n[9].ToString() + n[10].ToString();

            // Se os ultimos dois digitos calculados bater com
            // os dois ultimos digitos do cpf entao é válido
            if (calculado == digitado)
                return (true);
            else
                return (false);
        }

        public bool NomeValido(string nome)
        {
            Regex rgx = new Regex(@"^[aA-zZ]+((s[aA-zZ]+)+)?$"); return rgx.IsMatch(nome) ? true : false;
        }

        public bool ContemLetras(string letras)
        {
            return letras.Where(c => char.IsLetter(c)).Count() > 0 ? true : false;
        }

        public bool ContemNumeros(string numeros)
        {
            return numeros.Where(c => char.IsNumber(c)).Count() > 0 ? true : false;
        }

        public bool ContemLetrasEnumeros(string texto)
        {
            return ContemLetras(texto) && ContemNumeros(texto) ? true : false;
        }

        public bool NumeroInteiroValido(string numero)
        {
            Regex rgx = new Regex(@"^[0-9]+$"); return rgx.IsMatch(numero) ? true : false;
        }

        public bool NumeroRealValido(string numeroreal)
        {
            Regex rgx = new Regex(@"^[0-9]+?(.|,[0-9]+)$"); return rgx.IsMatch(numeroreal) ? true : false;
        }

        public bool CepValido(string cep)
        {
            Regex rgx = new Regex(@"^d{5}-?d{3}$"); return rgx.IsMatch(cep) ? true : false;
        }

        public bool EmailValido(string email)
        {
            Regex rgx = new Regex(@"^[A-Za-z0-9](([_.-]?[a-zA-Z0- 9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*).([A-Za-z]{2,})$");
            return rgx.IsMatch(email) ? true : false;
        }

        public bool UrlValida(string http)
        {
            Regex rgx = new Regex(@"^((http)|(https)|(ftp))://([- w]+.)+w{2,3}(/ [%-w]+(.w{2,})?)*$");
            return rgx.IsMatch(http) ? true : false;
        }

        public bool IpValido(string ip) { Regex rgx = new Regex(@"^bd{1,3}.d{1,3}.d{1,3}.d{1,3}b$"); if (rgx.IsMatch(ip)) { return true; } else { return false; } }

        public bool DataValida(string data)
        {
            Regex rgx = new Regex(@"^((0[1-9]|[12]d)/(0[1-9]|1[0-2])|30/(0[13- 9]|1[0-2])|31/(0[13578]|1[02]))/d{4}$");
            return rgx.IsMatch(data) ? true : false;
        }

        public bool TelefoneValido(string telefone)
        {
            Regex rgx = new Regex(@"^([0-9]{2})s[0-9]{4}-[0-9]{4}$");
            return rgx.IsMatch(telefone) ? true : false;
        }

        public bool CpfValido(string cpf)
        {
            if (cpf.Length == 0)
            {
                return false;
            }

            if (cpf.Length != 11)
            {
                return false;
            }

            switch (cpf)
            {
                case "11111111111":
                case "00000000000":
                case "2222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999":
                    return false;
                default:
                    break;
            }

            Regex rgx = new Regex(@"^d{3}.?d{3}.?d{3}-?d{2}$"); return rgx.IsMatch(cpf) ? true : false;
        }

        public bool CnpjValido(string cnpj)
        {
            if (cnpj.Length != 14)
            {
                return false;
            }

            switch (cnpj)
            {
                case "11111111111111": return false;
                case "00000000000000": return false;
                case "22222222222222": return false;
                case "33333333333333": return false;
                case "44444444444444": return false;
                case "55555555555555": return false;
                case "66666666666666": return false;
                case "77777777777777": return false;
                case "88888888888888": return false;
                case "99999999999999": return false;
            }

            Regex rgx = new Regex(@"^d{2}.?d{3}.?d{3}/?d{4}-?d{2}$"); return rgx.IsMatch(cnpj) ? true : false;
        }
    }
}