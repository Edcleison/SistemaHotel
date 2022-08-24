namespace SistemaHotel.Model
{
    public class Usuario
    {


        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string CogidoReserva { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
            this.Id = 0;          
            this.NomeUsuario= "";          
            this.CogidoReserva = "";
            this.Login = "";
            this.Senha = "";
        }


    }
}