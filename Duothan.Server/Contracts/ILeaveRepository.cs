using AttendanceAdmin.Entities;

namespace AttendanceAdmin.Contracts
{
    public interface ILeaveRepository
    {
        Task<List<string>> GetUsernames();
        Task AddLeave(string Username, DateTime? Date, string? Category, string? Comment);
        Task<List<Leave>> GetLeaves();
        Task<List<AttendanceLeave>> GetAttendanceDataByDateRange(DateTime? startDate, DateTime? endDate, string? Username, string? Department);
        Task<List<string>> GetDepartmentNames();
        Task DeleteLeave(int leaveId);
        Task<List<LeaveReport>> FilterLeaves(DateTime? StartDate, DateTime? EndDate, string? Username, string? Category, string? Department);




    }
}
