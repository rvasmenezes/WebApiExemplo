namespace Lider.DPVAT.MODELO.ExternalService.Agent.Interfaces
{
    public interface ILoginExternalAgent
    {
        UsuarioDTO LoginExterno(string Username, string Passwords);
    }
}
