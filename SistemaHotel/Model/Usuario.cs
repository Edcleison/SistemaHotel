namespace SistemaHotel.Model
{
    public class Usuario
    {


        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NomeUsuario { get; set; }
       
        public Usuario()
        {
            this.IdUsuario = 0;          
            this.Login = "";          
            this.Senha = "";
            this.NomeUsuario = "";
        }


    }
}