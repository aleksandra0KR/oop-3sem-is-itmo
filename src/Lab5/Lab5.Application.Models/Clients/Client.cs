namespace Lab5.Application.Models;

public record Client(long Id, string Login, string Password, ClientRole Access);