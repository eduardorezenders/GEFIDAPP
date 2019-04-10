namespace GEFIDAPP2.Resources.Model
{
    public class StatusOuvidoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}