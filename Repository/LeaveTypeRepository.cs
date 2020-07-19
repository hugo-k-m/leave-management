using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leave_management.Repository
{
    /// <summary>
    /// Implements CRUD operations related to the LeaveType data entity model.
    /// </summary>
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns true if the given leave type entity was successfully created
        /// in the database. The method returns false otherwise.
        /// </summary>
        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        /// <summary>
        /// Returns true if the given leave type entity was successfully deleted
        /// from the database. The method returns false otherwise.
        /// </summary>
        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        /// <summary>
        /// Returns all records from the LeaveTypes table in the database.
        /// </summary>
        public ICollection<LeaveType> FindAll()
        {
            List<LeaveType> leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        /// <summary>
        /// Returns the leave type record/row from the LeaveTypes table that
        /// corresponds with the given unique identifier.
        /// </summary>
        public LeaveType FindById(int id)
        {
            LeaveType leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the database contains a record corresponding with
        /// the id input. Returns false otherwise.
        /// </summary>
        public bool isExists(int id)
        {
            bool exists = _db.LeaveTypes.Any(
                q => q.Id == id
            );
            return exists;
        }

        /// <summary>
        /// This method applies entity framework changes to the database records.
        /// If any changes have been made then it returns true. If no changes
        /// were made then it returns false.
        /// </summary>
        public bool Save()
        {
            int changes = _db.SaveChanges();
            return changes > 0;
        }

        /// <summary>
        /// Returns true if the leave type database record record was
        /// successfully updated. The method returns false otherwise.
        /// </summary>
        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}