﻿using DotacionBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(UsuarioEntity usuario);
    }
}
