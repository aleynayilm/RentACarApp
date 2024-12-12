using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class BackupController:ControllerBase
    {
        private readonly string connectionString = "your_connection_string";

        // Yedek al
        [HttpPost("backup")]
        public IActionResult BackupDatabase()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("BACKUP DATABASE CarRentalDB TO DISK = 'C:\\Backup\\database_backup.bak'", connection);
                    command.ExecuteNonQuery();
                    return Ok("Database backup completed successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Yedekten dön
        [HttpPost("restore")]
        public IActionResult RestoreDatabase()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("RESTORE DATABASE CarRentalDB FROM DISK = 'C:\\Backup\\database_backup.bak'", connection);
                    command.ExecuteNonQuery();
                    return Ok("Database restored successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
