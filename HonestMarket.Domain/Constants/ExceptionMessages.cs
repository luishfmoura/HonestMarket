using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Domain.Constants;

public static class ExceptionMessages
{
    public const string NO_CONTENT = "Nenhum registro encontrado";
    public const string NOT_FOUND = "Nenhum registro encontrado";
    public const string INTERNAL_SERVER_ERROR = "Uma falha inesperada aconteceu";
    public const string UNAUTHORIZED = "Usuário ou senha inválidos";
    public const string EXPIRED_USER = "Seu acesso expirou";
}
