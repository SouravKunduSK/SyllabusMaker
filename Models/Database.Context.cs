//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SyllabusMaker.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SyllabusMakerEntities : DbContext
    {
        public SyllabusMakerEntities()
            : base("name=SyllabusMakerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AssessmentStrategie> AssessmentStrategies { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookType> BookTypes { get; set; }
        public virtual DbSet<CLO> CLOes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseDetail> CourseDetails { get; set; }
        public virtual DbSet<CourseObjective> CourseObjectives { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<LearningPlan> LearningPlans { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<TeachingStrategie> TeachingStrategies { get; set; }
    }
}
