using Dapper;
using Microsoft.Data.SqlClient;
using sugar_hills_backend.Configuration;
using sugar_hills_backend.Models.DTOS;
using sugar_hills_backend.Models.SHAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sugar_hills_backend.Data.SHAC
{
    public class SHACRepo : ISHACRepo
    {
        private readonly ConnectionString _connectionString;
        public SHACRepo(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> AddEmployee(CreateEmployeeDTO employee)
        {
            const string query = @"INSERT INTO dbo.SHACEmployees ([Name], [Gender], [Position], [Mobile]) VALUES(@Name, @Gender, @Position, @Mobile)";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.ExecuteAsync(query, employee);
                return result;
            }
        }

        public async Task<int> AddEmployeeToDay(AddToTimeCardDTO employee)
        {
            const string query = @"INSERT INTO dbo.SHACTimeCard ([EmployeeID], [TimeIn], [TimeOut]) VALUES(@EmployeeID, @TimeIn, @TimeOut)";
            using(var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.ExecuteAsync(query, employee);
                return result;
            }
        }

        public async Task<int> EditEmployeeFromDay(EditEmployeeTimeCardDTO Employee)
        {
            const string query = @"UPDATE dbo.SHACTimeCard
                                SET TimeIn = @TimeIn, TimeOut = @TimeOut
                                WHERE EmployeeID = @EmployeeID AND TimeIn = @TimeIn";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.ExecuteAsync(query, Employee);
                return result;
            }
        }

        public async Task<IEnumerable<SHACEmployee>> GetEmployees()
        {
            const string query = @"SELECT * FROM SHACEmployees";

            using(var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.QueryAsync<SHACEmployee>(query);
                return result;
            }
        }

        public async Task<IEnumerable<ShacTimeCardDTO>> GetEmployeesFromDay(GetEmployeesFromDayDTO Date)
        {
            const string query = @"SELECT SHACEmployees.ID, Name, Gender, Mobile, Position, TimeIn, TimeOut 
                                FROM SHACEmployees
                                INNER JOIN
                                SHACTimeCard ON SHACEmployees.ID = SHACTimeCard.EmployeeID
                                WHERE convert(Date, TimeIn) = convert(Date, @TimeIn)";

            using(var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.QueryAsync<ShacTimeCardDTO>(query, Date);
                return result;
            }
        }

        public async Task<int> RemoveEmployee(RemoveEmployeeDTO EmployeeID)
        {
            const string query = @"DELETE FROM SHACTimeCard
                                WHERE EmployeeID = @ID;
                                DELETE FROM SHACEmployees
                                WHERE ID = @ID";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.ExecuteAsync(query, EmployeeID);
                return result;
            }
        }

        public async Task<int> RemoveEmployeeFromDay(RemoveEmployeeFromTimeCardDTO Employee)
        {
            const string query = @"DELETE FROM SHACTimeCard
                                WHERE convert(Date, [TimeIn]) = convert(Date, @TimeIn)
                                AND EmployeeID = @ID";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.ExecuteAsync(query, Employee);
                return result;
            }
        }
    }
}
