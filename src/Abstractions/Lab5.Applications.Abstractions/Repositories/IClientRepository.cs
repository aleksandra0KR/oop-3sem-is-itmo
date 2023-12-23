using Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Repositories;

public interface IClientRepository
{
    Client? FindClientById(string login);
    Client? AddClient(string login, string password, ClientAccess access);
    void UpdateClient(Client client);
    void DeleteClientById(long id);
}