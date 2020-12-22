namespace Lider.DPVAT.MODELO.ExternalService.Agent
{
    public class UsuarioDTO
    {
        //Id do Usuario
        public int Id { get; set; }
        //Login: Login enviado para a validação
        public string Login { get; set; }
        //Usuário: Nome do usuário validad
        public string NomeCompleto { get; set; }
        //SUSEP: Código SUSEP da seguradora do usuário
        public string SUSEP { get; set; }
        //Seguradora: Nome da seguradora do usuário
        public string Seguradora { get; set; }
        //Dependência: Razão social da dependência a qual o usuário está registrado
        public string Dependencia { get; set; }
        //Digitalizadora: Nome da digitalizadora associada a dependência do usuári
        public string Digitalizada { get; set; }
        //Codigo de Retorno do WebService
        public string CodigoRetorno { get; set; }
        //Mensagem de retorno
        public string MensagemdeRetorno { get; set; }
        //Lista perfil associado ao usuário
        public string Perfil { get; set; }
        //Mensagem de erro associado a Autenticacao
        public string CustomError { get; set; }
    }
}
