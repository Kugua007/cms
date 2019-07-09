﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SqlKata;
using SS.CMS.Data;
using SS.CMS.Enums;
using SS.CMS.Models;

namespace SS.CMS.Repositories
{
    public partial interface IUserRepository : IRepository
    {
        Task<IEnumerable<UserInfo>> GetAllAsync(Query query);

        Task<int> GetCountAsync(Query query);

        Task<int> GetCountAsync();

        Task<(bool IsSuccess, int UserId, string ErrorMessage)> InsertAsync(UserInfo userInfo);

        Task<(bool IsSuccess, string ErrorMessage)> UpdateAsync(UserInfo userInfo);

        Task<bool> UpdateLastActivityDateAndCountOfFailedLoginAsync(UserInfo userInfo);

        Task<bool> UpdateLastActivityDateAndCountOfLoginAsync(UserInfo userInfo);

        Task UpdateSiteIdCollectionAsync(UserInfo userInfo, string siteIdCollection);

        Task<List<int>> UpdateSiteIdAsync(UserInfo userInfo, int siteId);

        Task<bool> DeleteAsync(UserInfo userInfo);

        Task LockAsync(List<int> userIdList);

        Task UnLockAsync(List<int> userIdList);

        Task<UserInfo> GetByAccountAsync(string account);

        Task<UserInfo> GetByUserIdAsync(int userId);

        Task<UserInfo> GetByUserNameAsync(string userName);

        Task<UserInfo> GetByMobileAsync(string mobile);

        Task<UserInfo> GetByEmailAsync(string email);

        Task<bool> IsUserNameExistsAsync(string userName);

        Task<bool> IsEmailExistsAsync(string email);

        Task<bool> IsMobileExistsAsync(string mobile);

        Task<int> GetCountByAreaIdAsync(int areaId);

        Task<int> GetCountByDepartmentIdAsync(int departmentId);

        /// <summary>
        /// 获取管理员用户名列表。
        /// </summary>
        /// <returns>
        /// 管理员用户名列表。
        /// </returns>
        Task<IEnumerable<string>> GetUserNameListAsync();

        Task<IEnumerable<string>> GetUserNameListAsync(int departmentId);

        Task<(bool IsSuccess, string ErrorMessage)> ChangePasswordAsync(UserInfo userInfo, string password);

        Task<(bool IsSuccess, string UserName, string ErrorMessage)> ValidateAsync(string account, string password, bool isPasswordMd5);

        bool CheckPassword(string password, bool isPasswordMd5, string dbPassword, PasswordFormat passwordFormat, string passwordSalt);
    }
}