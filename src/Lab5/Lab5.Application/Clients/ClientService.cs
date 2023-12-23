using Application.Contracts;
using Application.Models;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab5.Repositories;

namespace Application.Clients;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository ?? throw new ValueException("Empty clientRepository");
    }

    public Result<Client> Login(string login, string password)
    {
        Client? client = _clientRepository.FindClientById(login) ?? throw new ValueException("No such Client");
        return client.Password == password ? new Result<Client>(ResultValues.NotFound, client) : throw new ValueException("No such Client");
    }

    public Result<Client> Registration(string login, string password, ClientAccess access)
    {
        Client? client = _clientRepository.FindClientById(login);

        if (client is not null)
        {
            throw new ValueException("Client is already in system");
        }

        client = _clientRepository.AddClient(login, password, access);
        if (client is null) throw new ValueException("Empty client");
        return new Result<Client>(ResultValues.Success, client);
    }
}