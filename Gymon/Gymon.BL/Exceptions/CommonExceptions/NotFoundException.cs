﻿using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Exceptions.CommonExceptions;


public class NotFoundException<T> : Exception, IBaseException
    where T : BaseEntity
{
    public int Code => StatusCodes.Status404NotFound;
    public string ErrorMessage { get; }
    const string _message = "not found";

    public NotFoundException() : base(typeof(T).Name + _message)
    {
        ErrorMessage = typeof(T).Name + _message;
    }
    public NotFoundException(string message) : base(message)
    {
        ErrorMessage = message;
    }
}
