using ApiEventos.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace ApiEventos.Application.Conversoes
{
    public class SenhaParaHash
    {
        public static byte[] HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha)) // garante que a senha não está vazia
            {
                throw new DomainException("Senha é obrigatória.");
            }

            using var sha256 = SHA256.Create(); // gera um hash SHA256 e devolve em byte[]
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }
    }
}
