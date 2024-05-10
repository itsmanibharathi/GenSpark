﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class RequestTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=J9GCBX3\KIKO;Integrated Security=true;Initial Catalog=dbEmployeeTrackerCF;");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSolution> RequestSolutions { get; set; }
        public DbSet<SolutionFeedback> Feedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId)
                .HasAnnotation("SqlServer:Identity", "1,1");

            modelBuilder.Entity<Request>()
                .HasKey(r => r.RequestNumber)
                .HasAnnotation("SqlServer:Identity", "101,1");
            modelBuilder.Entity<RequestSolution>()
                .HasKey(rs => rs.SolutionId)
                .HasAnnotation("SqlServer:Identity", "1001,1");
            modelBuilder.Entity<SolutionFeedback>()
                .HasKey(sf => sf.FeedbackId)
                .HasAnnotation("SqlServer:Identity", "10001,1");


            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee)
               .WithMany(e => e.RequestsRaised)
               .HasForeignKey(r => r.RequestRaisedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestSolution>()
                .HasOne(rs => rs.RequestRaised)
                .WithMany(r => r.RequestSolutions)
                .HasForeignKey(rs => rs.RequestId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<RequestSolution>()
                .HasOne(rs => rs.SolvedByEmployee)
                .WithMany(e => e.SolutionsProvided)
                .HasForeignKey(rs => rs.SolvedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<SolutionFeedback>()
                .HasOne(sf => sf.Solution)
                .WithMany(s => s.Feedbacks)
                .HasForeignKey(sf => sf.SolutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<SolutionFeedback>()
              .HasOne(sf => sf.FeedbackByEmployee)
              .WithMany(e => e.FeedbacksGiven)
              .HasForeignKey(sf => sf.FeedbackBy)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();
        }

    }
}
