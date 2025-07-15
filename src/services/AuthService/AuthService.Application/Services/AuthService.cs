using AuthService.Application.Helper;
using AuthService.Application.Interfaces.Repositories;
using AuthService.Application.Interfaces.Services;
using AuthService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        public async Task<string> RegisterAsync(string name, string email, string password)
        {
            if (await _userRepository.ExistsByEmailAsync(email))
                throw new Exception("E-mail já cadastrado.");

            var user = new User
            {
                Name = name,
                Email = email,
                Password = PasswordHasher.Hash(password)
            };

            await _userRepository.AddAsync(user);

            return _jwtProvider.Generate(user);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || !PasswordHasher.Verify(password, user.Password))
                return null;

            return _jwtProvider.Generate(user);
        }
    }
}
