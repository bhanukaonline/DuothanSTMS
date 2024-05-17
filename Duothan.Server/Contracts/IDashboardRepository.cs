using AttendanceAdmin.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceAdmin.Contracts
{
    public interface IDashboardRepository
    {
        Task<List<AttendanceData>> GetAttendanceDataByDateRange(DateTime? startDate, DateTime? endDate,string? Username,string?Department);
        Task<List<AttendanceLog>> GetAttendanceLogData(DateTime? startDate, DateTime? endDate, string? Username, string? Department);
        Task<List<string>> GetUsernames();
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task DeleteUser(int userid);
        Task UpdateUser(int Id, User UpdateUser);
        Task<List<Device>> GetAllDevices();
        Task<List<string>> GetDepartmentNames();
        Task<List<string>> GetLocations();
        Task AddAttendance(string? Username, DateTime? InDate, string? InLocation, DateTime? OutDate, string? OutLocation);
        Task AddAttendanceManual(string? Username, DateTime? InDate, string? InLocation, DateTime? OutDate, string? OutLocation);
        Task DeleteAttendance(int attendanceId);
        Task UpdateAttendance(int attendanceId, DateTime uinDate, TimeSpan uinTime, int InDevice, DateTime uoutDate, TimeSpan uoutTime, int OutDevice);
        Task ActivateUser(int userid);
    }
}
