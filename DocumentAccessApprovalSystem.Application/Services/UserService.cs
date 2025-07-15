using DocumentAccessApprovalSystem.Application.Interfaces;
using DocumentAccessApprovalSystem.Domain.Entities;
using DocumentAccessApprovalSystem.Domain.Interfaces;

namespace DocumentAccessApprovalSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccessRequestRepository _accessRequestRepository;

        public UserService(IUserRepository userRepository, IAccessRequestRepository accessRequestRepository)
        {
            _userRepository = userRepository;
            _accessRequestRepository = accessRequestRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(string name, string email, UserRole role)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);

            if (existingUser != null)
            {
                throw new ArgumentException("User with this email already exists", nameof(email));
            }

            var user = new User
            {
                Name = name,
                Email = email,
                Role = role,
                CreatedAt = DateTime.UtcNow
            };

            return await _userRepository.CreateAsync(user);
        }

        public async Task<User?> UpdateUserAsync(int id, string name, string email, UserRole role)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            if (user.Email != email)
            {
                var existingUser = await _userRepository.GetByEmailAsync(email);
                if (existingUser != null)
                {
                    throw new ArgumentException("User with this email already exists", nameof(email));
                }
            }

            user.Name = name;
            user.Email = email;
            user.Role = role;

            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<List<AccessRequest>> GetUserRequestsAsync(int userId)
        {
            return await _accessRequestRepository.GetByUserAsync(userId);
        }
    }
} 
