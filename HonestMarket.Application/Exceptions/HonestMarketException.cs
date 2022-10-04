using HonestMarket.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Application.Exceptions;

public class HonestMarketException : Exception
{
    public HonestMarketException(string message) : base(message) { }
}

public class HonestMarketNocontentException : HonestMarketException
{
    public HonestMarketNocontentException() : base(ExceptionMessages.NO_CONTENT) { }
}
public class HonestMarketNotFoundException : HonestMarketException
{
    public HonestMarketNotFoundException(string? entity = null) : base($"{ExceptionMessages.NOT_FOUND} {(!string.IsNullOrEmpty(entity) ? "(" + entity + ")" : string.Empty)}".Trim()) { }
}
public class HonestMarketUnauthorizedException : HonestMarketException
{
    public HonestMarketUnauthorizedException() : base(ExceptionMessages.UNAUTHORIZED) { }
}
public class HonestMarketExpiredUserException : HonestMarketException
{
    public HonestMarketExpiredUserException() : base(ExceptionMessages.EXPIRED_USER) { }
}
public class HonestMarketInternalServerErrorException : HonestMarketException
{
    public HonestMarketInternalServerErrorException() : base(ExceptionMessages.INTERNAL_SERVER_ERROR) { }
}
