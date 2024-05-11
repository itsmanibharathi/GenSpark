﻿namespace RequestTrackerModelLibrary
{
    public enum EmployeeRoles
    {
        Admin, Manager, Employee
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public EmployeeRoles Role { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Role: {Role}";
        }
        public virtual bool PasswordCheck(string password)
        {
            return this.Password == password;
        }
        public ICollection<Request> RequestsRaised { get; set; }//No effect on the table
        public ICollection<RequestSolution> SolutionsProvided { get; set; }
        public ICollection<SolutionFeedback> FeedbacksGiven { get; set; }
    }
}
