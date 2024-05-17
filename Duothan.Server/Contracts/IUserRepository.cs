using AttendanceAdmin.Entities;

namespace AttendanceAdmin.Contracts
{
    public interface IUserRepository
    {
        Task<int> UserIdCount();
        Task AddUser(int count, string firstName, string lastName, string displayName, int empId, int departmentId);
        Task<List<Device>> GetDevices();
        Task<List<Department>> GetDepartments();
        Task<User> GetUserById(int Id);
        Task UpdateUser(int Id, string firstName, string lastName, string displayName, int empId, int departmentId);
        Task<List<DeviceUser>> GetDeviceUser(int Id);
        Task RemoveDeviceUser(int Device, int Id);
        Task AddDeviceUser(int Device, int Id);
    }
}
