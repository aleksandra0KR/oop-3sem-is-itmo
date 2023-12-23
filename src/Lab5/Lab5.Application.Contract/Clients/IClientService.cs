using Application.Models;
using Application.Models.Result;

namespace Application.Contracts;

public interface IClientService
{
    Result<Client> Login(string login, string password);

    Result<Client> Registration(string login, string password, ClientAccess access);
}