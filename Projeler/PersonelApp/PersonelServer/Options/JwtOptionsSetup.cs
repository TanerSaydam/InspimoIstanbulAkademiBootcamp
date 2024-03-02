﻿using Microsoft.Extensions.Options;

namespace PersonelServer.Options;

public sealed class JwtOptionsSetup(
    IConfiguration configuration) : IConfigureOptions<JwtOptions>
{    
    public void Configure(JwtOptions options)
    {        
        configuration.GetSection("Jwt").Bind(options);
    }
}
