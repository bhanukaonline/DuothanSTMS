namespace AttendanceAdmin.Contracts
{
    public interface IFingerprintRepository
    {
        Task<string> AddAttendance(string user_id, string mac_address);
        Task<string> GetDelay();
        Task<string> GetDisplayName(string user_id);
        Task ResetMode(string mac_address, string user_id);
        public Task<string> UpdateStatus(string mac);
        Task<string> ApiLogIn(string apiIn);
        Task<string> ApiLogOut(string apiOut);
        Task RemoveDeviceUser(string mac, string Id);
        Task AddDeviceUser(string mac, string Id);
    }
}
