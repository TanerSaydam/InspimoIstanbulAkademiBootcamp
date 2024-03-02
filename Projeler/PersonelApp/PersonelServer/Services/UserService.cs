using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonelServer.DTOs;
using PersonelServer.Models;
using PersonelServer.Repositories;
using System.Text;

namespace PersonelServer.Services;

public sealed class UserService(
    UserRepository userRepository,
    IUnitOfWork unitOfWork,
    JwtProvider jwtProvider,
    IMapper mapper)
{
    public async Task CreateAsync(CreateUserDto request, CancellationToken cancellationToken = default)
    {
        bool isEmailExists = await userRepository.AnyAsync(p => p.Email == request.Email, cancellationToken);
        if (isEmailExists)
        {
            throw new ArgumentException("Email already using");
        }


        var hmac = new System.Security.Cryptography.HMACSHA512();
        var passwordSalt = hmac.Key;
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

        User user = mapper.Map<User>(request);
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;

        await userRepository.AddAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<string> LoginAsync(LoginDto request, CancellationToken cancellationToken = default)
    {
        User? user = 
            await userRepository
            .GetAll()
            .Where(p => p.Email == request.Email)
            .FirstOrDefaultAsync(cancellationToken);

        if(user is null)
        {
            throw new ArgumentException("User not found");
        }

        var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
        var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        for (int i = 0; i < computeHash.Length; i++)
        {
            if (computeHash[i] != user.PasswordHash[i])
            {
                throw new ArgumentException("Password is wrong");
            }
        }

        string token = jwtProvider.CreateToken(user); 
        return token;
    }
}
