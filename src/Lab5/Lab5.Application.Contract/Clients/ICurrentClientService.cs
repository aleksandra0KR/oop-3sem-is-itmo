using Application.Models;

namespace Application.Contracts;

public interface ICurrentClientService
{
    Client? Client { get; }
}